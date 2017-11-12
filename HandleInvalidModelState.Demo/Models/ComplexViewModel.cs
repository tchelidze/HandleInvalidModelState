using FluentValidation;
using FluentValidation.Attributes;
using HandleInvalidModelState.ActionFilters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HandleInvalidModelState.Demo.Models
{
    [Validator(typeof(SimpleViewModelValidator))]
    public class ComplexViewModel
    {
        public string FirstName { get; set; }

        public int Age { get; set; }

        public IEnumerable<SelectListItem> AgeSelectListItems { get; set; }
    }

    public class ComplexViewModelValidator : AbstractValidator<ComplexViewModel>
    {
        public ComplexViewModelValidator()
        {
            RuleFor(it => it.FirstName)
                .Must(it => false)
                .WithMessage("Invalid Firstname");
        }
    }

    public class ComplexViewModelInitializer : IViewModelInitializer
    {
        public object Initialize(object viewModel)
        {
            var alwaysInvalidComplexViewModel = (ComplexViewModel)viewModel;
            alwaysInvalidComplexViewModel.AgeSelectListItems = new List<SelectListItem>
            {
                new SelectListItem {Value = 1.ToString(), Text = 1.ToString()},
                new SelectListItem {Value = 2.ToString(), Text = 2.ToString()},
                new SelectListItem {Value = 3.ToString(), Text = 3.ToString()},
                new SelectListItem {Value = 4.ToString(), Text = 4.ToString()},
                new SelectListItem {Value = 5.ToString(), Text = 5.ToString()},
            };

            return alwaysInvalidComplexViewModel;
        }
    }
}