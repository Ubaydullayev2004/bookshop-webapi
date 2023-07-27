using BookShop.Service.Dtos.Categories;
using BookShop.Service.Dtos.Discount;
using FluentValidation;

namespace BookShop.Service.Validators.Discount;

public class CreateDiscountValidator: AbstractValidator<CreateDiscountDto>
{
    public CreateDiscountValidator()
    {
        RuleFor(dto => dto.name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.description).NotNull().NotEmpty().WithMessage("Description field is required!")
          .MinimumLength(10).WithMessage("Description field is required!");

    }
}
