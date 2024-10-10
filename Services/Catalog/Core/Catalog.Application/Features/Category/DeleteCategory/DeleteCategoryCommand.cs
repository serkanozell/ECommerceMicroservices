namespace Catalog.Application.Features.Category.DeleteCategory
{
    public record DeleteCategoryCommand(Guid Id) : ICommand<DeleteCategoryResult>;
    public record DeleteCategoryResult(bool IsSuccess);
}
