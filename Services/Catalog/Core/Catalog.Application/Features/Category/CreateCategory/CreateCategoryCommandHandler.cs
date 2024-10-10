using Catalog.Application.Features.Category.CreateCategory;
using Catalog.Application.Repositories;

namespace Catalog.Application
{
    public sealed class CreateCategoryCommandHandler(IUnitOfWork _unitOfWork) : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
    {
        public async Task<CreateCategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.CreateCategoryDto.Name,
                IsActive = true,
                IsDeleted = false
            };

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.Save();

            return new CreateCategoryResult(category.Id);
        }
    }
}