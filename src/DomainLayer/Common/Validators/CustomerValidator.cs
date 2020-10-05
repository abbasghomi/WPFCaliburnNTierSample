using FluentValidation;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using System;

namespace WPFCaliburnNTierSample.DomainLayer.Common.Validators
{
    /// <summary>
    /// Customer validator using Fluentvalidation
    /// </summary>
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(ent => ent.FirstName)
                .NotNull().WithMessage("First name should not be empty")
                .NotEmpty().WithMessage("First name should not be empty")
                .MaximumLength(30).WithMessage("First name maximum length is 30 characters");
            RuleFor(ent => ent.LastName)
                .NotNull().WithMessage("Last name should not be empty")
                .NotEmpty().WithMessage("Last name should not be empty")
                .MaximumLength(30).WithMessage("Last name maximum length is 30 characters");
            RuleFor(ent => ent.Address1)
                .NotNull().WithMessage("Address1 should not be empty")
                .NotEmpty().WithMessage("Address1 should not be empty")
                .MaximumLength(40).WithMessage("Address1 maximum length is 30 characters");
            RuleFor(ent => ent.State)
                .NotNull().WithMessage("State should not be empty")
                .NotEmpty().WithMessage("State should not be empty")
                .Length(2).WithMessage("State maximum length is 2 characters");
            RuleFor(ent => ent.City)
                .NotNull().WithMessage("City should not be empty")
                .NotEmpty().WithMessage("City should not be empty")
                .MaximumLength(50).WithMessage("City maximum length is 50 characters");
            RuleFor(ent => ent.Zip)
                .NotNull().WithMessage("Zip should not be empty")
                .NotEmpty().WithMessage("Zip should not be empty")
                .MaximumLength(10).WithMessage("Zip maximum length is 10 characters");
            RuleFor(ent => ent.Age)
                .Must(BeValidAge).WithMessage("Age should be greater than 0");
        }

        private bool BeValidAge(int? arg)
        {
            bool result = true;
            if (arg != null && arg<1)
            {
                result = false;
            }
            return result;
        }
    }
}
