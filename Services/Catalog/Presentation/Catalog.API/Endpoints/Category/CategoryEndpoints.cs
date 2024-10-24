using Catalog.API.Requests.Category;
using Catalog.API.Responses.Category;
using Catalog.Application.Dtos.Category;
using Catalog.Application.Features.Category.CreateCategory;
using Catalog.Application.Features.Category.DeleteCategory;
using MediatR;

namespace Catalog.API.Endpoints.Category
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var category = app.MapGroup("/category");

            category.MapPost("/", async (ISender sender, CreateCategoryRequest createCategoryRequest) =>
            {
                var command = new CreateCategoryCommand(CreateCategoryDto: new CreateCategoryDto(Name: createCategoryRequest.Name,
                                                                                                 Description: createCategoryRequest.Description));

                var result = await sender.Send(command);

                var response = new CreateCategoryResponse(result.Id);

                return Results.Ok(response);
            });

            category.MapDelete("/{id}", async (ISender sender, Guid id) =>
            {
                var command = new DeleteCategoryCommand(Id: id);

                var result = await sender.Send(command);

                var response = new DeleteCategoryResponse(result.IsSuccess);

                return Results.Ok(response);
            });
        }
    }
}
