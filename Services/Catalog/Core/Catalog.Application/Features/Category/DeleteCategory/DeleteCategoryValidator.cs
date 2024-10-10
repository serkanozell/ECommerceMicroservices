namespace Catalog.Application.Features.Category.DeleteCategory
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull();
        }
    }
}