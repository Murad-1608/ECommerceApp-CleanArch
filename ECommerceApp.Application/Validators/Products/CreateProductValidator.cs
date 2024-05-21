using ECommerceApp.Application.ViewModels.Products;
using FluentValidation;

namespace ECommerceApp.Application.Validators.Products
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Name is required").MaximumLength(150).MinimumLength(3).WithMessage("Please, input between 3 and 150");
            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Stock is required").Must(s => s >= 0).WithMessage("Must be greater than 0");
            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Price is required").Must(s => s >= 0).WithMessage("Must be greater than 0");
        }
    }
}
