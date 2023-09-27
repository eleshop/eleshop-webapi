using Eleshop.Persistance.Dtos.Categories;
using FluentValidation;

namespace Eleshop.Persistance.Validations.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(dto => dto.Name)
            .NotNull().NotEmpty().WithMessage("Name field is required!")
            .Length(3, 50).WithMessage("Name must be between 3 and 50 characters.")
            .Matches("^[A-Za-z\\s'-]+$").WithMessage("Name can only contain letters")
            .Must(ShouldStartWithUpper).WithMessage("Name must start with Uppercase letter.");
        //.Matches(@"[""!@$%^&*(){}:;<>,.?/+\-_=|'[\]~\\]")!.WithMessage("Name must contain one or more special characters.");
    }

    private bool ShouldStartWithUpper(string name)
    {
        if (string.IsNullOrEmpty(name)) return false;
        return char.IsUpper(name[0]);
    }
}
