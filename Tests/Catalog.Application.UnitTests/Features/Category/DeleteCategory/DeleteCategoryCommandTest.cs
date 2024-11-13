using Catalog.Application.Features.Category.DeleteCategory;
using Catalog.Application.Repositories;
using NSubstitute;

namespace Catalog.Application.UnitTests.Features.Category.DeleteCategory
{
    public class DeleteCategoryCommandTest
    {
        public static readonly DeleteCategoryCommand deleteCategoryCommand = new DeleteCategoryCommand(Guid.NewGuid());
        private readonly DeleteCategoryCommandHandler _deleteCategoryCommand;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DeleteCategoryValidator _validator;
        public DeleteCategoryCommandTest()
        {
            _unitOfWork=Substitute.For<IUnitOfWork>();
            _deleteCategoryCommand = new DeleteCategoryCommandHandler(_unitOfWork);
            _validator = new DeleteCategoryValidator();
        }
    }
}