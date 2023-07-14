using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Sipay.Bootcamp.AkdasRabia;

namespace Sipay.Bootcamp.AkdasRabia
{
    public class Person
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public int AccessLevel { get; set; }
        public decimal Salary { get; set; }
    }
}

//public class SalaryAttribute : ValidationAttribute
//{
//    public SalaryAttribute()
//    {

//    }

//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        var person = (Person)validationContext.ObjectInstance;
//        decimal salary = (decimal)value;
//        ValidationResult? message = ValidationResult.Success;
//        switch (person.AccessLevel)
//        {
//            case 1:
//                message = salary > 10000 ? new ValidationResult("Salary cannot be greater then 10000") : ValidationResult.Success;
//                return message;
//            case 2:
//                message = salary > 20000 ? new ValidationResult("Salary cannot be greater then 20000") : ValidationResult.Success;
//                return message;
//            case 3:
//                message = salary > 30000 ? new ValidationResult("Salary cannot be greater then 30000") : ValidationResult.Success;
//                return message;
//            case 4:
//                message = salary > 40000 ? new ValidationResult("Salary cannot be greater then 40000") : ValidationResult.Success;
//                return message;
//            default:
//                message = new ValidationResult("Salary cannot invalid");
//                break;
//        }
//        return message;
//    }
//}