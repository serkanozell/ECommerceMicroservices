namespace Catalog.Application.Features.Category.CreateCategory
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.CreateCategoryDto.Name).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(c => c.CreateCategoryDto.Description).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}