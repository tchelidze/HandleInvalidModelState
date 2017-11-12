using FluentValidation;
using FluentValidation.Attributes;

namespace HandleInvalidModelState.Demo.Models
{
    [Validator(typeof(SimpleViewModelValidator))]
    public class SimpleViewModel
    {
        public string FirstName { get; set; }
    }

    public class SimpleViewModelValidator : AbstractValidator<SimpleViewModel>
    {
        public SimpleViewModelValidator()
        {
            RuleFor(it => it.FirstName)
                .Must(it => false)
                .WithMessage("Invalid Firstname");
        }
    }
}