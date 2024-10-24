using Catalog.Application.Features.Category.CreateCategory;
using Catalog.Application.Repositories;

namespace Catalog.Application
{
    public sealed class CreateCategoryCommandHandler(IUnitOfWork _unitOfWork) : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
    {
        public async Task<CreateCategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = Category.Create(request.CreateCategoryDto.Name, request.CreateCategoryDto.Description);

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.Save();

            return new CreateCategoryResult(category.Id);
        }
    }
}