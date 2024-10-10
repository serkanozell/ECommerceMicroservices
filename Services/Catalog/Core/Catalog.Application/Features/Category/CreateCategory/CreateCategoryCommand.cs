using Catalog.Application.Dtos.Category;

namespace Catalog.Application.Features.Category.CreateCategory
{
    public record CreateCategoryCommand(CreateCategoryDto CreateCategoryDto) : ICommand<CreateCategoryResult>;

    public record CreateCategoryResult(Guid Id);
}