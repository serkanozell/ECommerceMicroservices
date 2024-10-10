using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBlocks.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails();
            problemDetails.Instance = httpContext.Request.Path;

            if (exception is ValidationException validationException)
            {
                problemDetails.Title = "Validation Errors";
                problemDetails.Type = "Validation";
                problemDetails.Detail = exception.Message;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);

                List<string> validationErrors = new List<string>();

                foreach (var error in validationException.Errors)
                    validationErrors.Add(error.ErrorMessage);
            }
            else
                problemDetails.Title = exception.Message;

            logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);

            problemDetails.Status = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
