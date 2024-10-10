using Catalog.Application.Repositories;

namespace Catalog.Application.Features.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler(IUnitOfWork _unitOfWork) : ICommandHandler<DeleteCategoryCommand, DeleteCategoryResult>
    {
        public async Task<DeleteCategoryResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            
            if (category is null)
                return new DeleteCategoryResult(false);

            await _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.Save();

            return new DeleteCategoryResult(true);
        }
    }
}