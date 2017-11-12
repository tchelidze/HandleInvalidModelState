using FluentValidation;
using FluentValidation.Attributes;

namespace HandleInvalidModelState.Demo.Models
{
    [Validator(typeof(SimpleViewModelValidator))]
    public class GetDetailsViewModel
    {
        public int EntityId { get; set; }
    }

    public class GetDetailsViewModelValidator : AbstractValidator<GetDetailsViewModel>
    {
        public GetDetailsViewModelValidator()
        {
            RuleFor(it => it.EntityId)
                .Must(it => it > 0);
        }
    }
}