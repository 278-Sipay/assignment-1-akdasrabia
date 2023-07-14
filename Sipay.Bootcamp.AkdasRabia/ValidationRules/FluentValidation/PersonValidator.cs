using FluentValidation;
using System.Xml.Linq;
using System;

namespace Sipay.Bootcamp.AkdasRabia.ValidationRules.FluentValidation
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithName("Staff person name").Length(5, 100);
            RuleFor(p => p.Name).NotEmpty().WithName("Staff person lastname").Length(5, 100);
            RuleFor(p => p.Lastname).NotEmpty().Length(5, 100);
            RuleFor(p => p.Phone).NotEmpty().WithMessage("Staff person phone number").Matches("^[0-9]");
            RuleFor(p => p.AccessLevel).NotEmpty().WithMessage("Staff person access level to system").LessThan(6).GreaterThan(0);
            RuleFor(p => p.Salary).NotEmpty().WithName("Staff person salary").LessThan(50001).GreaterThan(4999)
                .Must((person, salary) => SalaryValidate(person.AccessLevel, salary))
                .WithMessage((person, salary) => 
                person.AccessLevel == 1 || person.AccessLevel == 2 || person.AccessLevel == 3 || person.AccessLevel == 4
                ? string.Format("Salary cannot be greater then {0}", (person.AccessLevel)*10000 )
                    : "Salary cannot invalid"
                );

        }


        private bool SalaryValidate(int level, decimal salary)
        {
            bool isValid;
            switch (level)
            {
                case 1:
                    isValid = salary > 10000 ? false : true;
                    return isValid;
                case 2:
                    isValid = salary > 20000 ? false : true;
                    return isValid;
                case 3:
                    isValid = salary > 30000 ? false : true;
                    return isValid;
                case 4:
                    isValid = salary > 40000 ? false : true;
                    return isValid;
                default:
                    return false;
            }
        }

    }
}
