using Catalog.Application.Features.Category.CreateCategory;
using Catalog.Application.Repositories;
using FluentAssertions;
using FluentValidation.TestHelper;
using NSubstitute;

namespace Catalog.Application.UnitTests.Features.Category.CreateCategory
{
    public class CreateCategoryCommandTests
    {
        private static readonly CreateCategoryCommand createCategoryCommand = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: "Test Category", Description: "Test description"));
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly IUnitOfWork _unitOfWorkMock;
        private readonly CreateCategoryValidator _validator;
        public CreateCategoryCommandTests()
        {
            _unitOfWorkMock = Substitute.For<IUnitOfWork>();
            _createCategoryCommandHandler = new CreateCategoryCommandHandler(_unitOfWorkMock);
            _validator = new CreateCategoryValidator();
        }
        [Fact]
        public async Task WhenCategoryNameIsNotNull_Should_Added()
        {
            // Arrange

            // Act
            var result = await _createCategoryCommandHandler.Handle(createCategoryCommand, default);

            // Assert
            await _unitOfWorkMock.CategoryRepository.Received(1).AddAsync(Arg.Is<Domain.Entities.Category>(c => c.Name == "Test Category"&&c.Description=="Test description"));
            result.Should().NotBeNull();
            result.Should().BeOfType<CreateCategoryResult>();
            result.Id.Should().NotBeEmpty();
            Assert.IsType<CreateCategoryResult>(result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("", "a")]
        [InlineData("a", "")]
        public async Task WhenCategoryIsNullNotValid_Should_Return_Error(string name, string description)
        {
            // Arrange
            var command = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: name, Description: description));

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveAnyValidationError();
            result.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData("Name", "Category")]
        public async Task WhenCategoryIsValid_ShouldNot_Return_Error(string name, string description)
        {
            // Arrange
            var command = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: name, Description: description));

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
            result.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("TestCategoryNameTestCategoryNameTestCategoryNameTestCategoryNameTestCategoryNameTestCategoryNameTestCategoryName", "TestCategoryDescriptionTestCategoryDescriptionTestCategoryDescriptionTestCategoryDescriptionTestCate")]
        public async Task WhenPropertiesIsBiggerThanMaxLimit_Should_Return_Error(string name, string description)
        {
            // Arrange
            var command = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: name, Description: description));

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveAnyValidationError();
            result.Errors.Should().HaveCountGreaterThan(0);
        }
    }
}