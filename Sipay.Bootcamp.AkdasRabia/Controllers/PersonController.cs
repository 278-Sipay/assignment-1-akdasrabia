using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Sipay.Bootcamp.AkdasRabia;
using Sipay.Bootcamp.AkdasRabia.ValidationRules.FluentValidation;
using FluentValidation.Results;

namespace Sipay.Bootcamp.AkdasRabia.Controllers;

public class ApiResponse<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public ApiResponse(T Data)
    {
        this.Data = Data;
        this.Success = true;
        this.Message = string.Empty;
    }
}


[ApiController]
[Route("sipy/api/[controller]")]
public class PersonController : ControllerBase
{
    public PersonController() { }

    [HttpPost]
    public IActionResult Post(Person person)
    {
        PersonValidator personValidator = new PersonValidator();
        var result = personValidator.Validate(person);

        if (result.Errors.Count > 0)
        {
            //var errors = new List<string>();
            //result.Errors.ForEach(error =>
            //{
            //    errors.Add(error.ErrorMessage);
            //}
            //);

            //var errors = result.Errors.Select(e => e.ErrorMessage);
            var errors = result.Errors.Select(e => e.ErrorMessage);
            return BadRequest(errors);


        }


        return Ok();
    }


}