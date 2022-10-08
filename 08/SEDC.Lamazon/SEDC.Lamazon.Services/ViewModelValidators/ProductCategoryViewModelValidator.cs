using FluentValidation;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.ViewModelValidators
{
    public class ProductCategoryViewModelValidator : AbstractValidator<ProductCategoryViewModel>
    {
        public ProductCategoryViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(255);
        }
    }
}
