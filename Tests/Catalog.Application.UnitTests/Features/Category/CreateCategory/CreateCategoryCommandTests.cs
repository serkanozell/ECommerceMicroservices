using Catalog.Application.Dtos.Category;
using Catalog.Application.Features.Category.CreateCategory;
using MediatR;

namespace Catalog.Application.UnitTests.Features.Category.CreateCategory
{
    //public class CreateCategoryCommandTests() : IClassFixture<CreateCategoryCommand>
    //{      
    //    public CreateCategoryCommandTests(ISender sender, CreateCategoryDto createCategoryDto)
    //    {
    //        sender = IClassFixture
    //    }
    //    private static readonly CreateCategoryDto createCategoryDto = new CreateCategoryDto(Name: "Test1");

    //    [Fact]
    //    public async Task WhenCategoryNameIsNotNull_Should_Added()
    //    {
    //        // Arrange
    //        var command = new CreateCategoryCommand(createCategoryDto);

    //        // Act
    //        var result = await sender.Send(command);

    //        // Assert
    //        Assert.True(result.IsSuccess);
    //    }
    //}
}