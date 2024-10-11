using Catalog.Application.Features.Category.CreateCategory;
using Catalog.Application.Repositories;
using FluentAssertions;
using FluentValidation.TestHelper;
using NSubstitute;

namespace Catalog.Application.UnitTests.Features.Category.CreateCategory
{
    public class CreateCategoryCommandTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateCategoryValidator _validator;
        public CreateCategoryCommandTests()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _validator = new CreateCategoryValidator();
        }
        [Fact]
        public async Task WhenCategoryNameIsNotNull_Should_Added()
        {
            // Arrange
            var command = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: "name"));
            var handler = new CreateCategoryCommandHandler(_unitOfWork);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);


            // Assert
            result.Id.Should().NotBeEmpty();
            result.Should().BeOfType<CreateCategoryResult>();
        }

        [Fact]
        public async Task WhenCategoryNameIsNull_Should_Return_Error()
        {
            // Arrange
            var command = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: ""));

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveAnyValidationError();
            result.ShouldHaveValidationErrorFor(c => c.CreateCategoryDto.Name);
        }

        [Fact]
        public async Task WhenCategoryNameIsNotNull_ShouldNot_Return_Error()
        {
            // Arrange
            var command = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: "test"));

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task WhenCategoryNameIsBiggerThanMaxLimit_Should_Return_Error()
        {
            // Arrange
            var command = new CreateCategoryCommand(new Dtos.Category.CreateCategoryDto(Name: "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest"));

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveAnyValidationError();
            result.ShouldHaveValidationErrorFor(c => c.CreateCategoryDto.Name);
        }
    }
}