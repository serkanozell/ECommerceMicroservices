﻿using BuildingBlocks.CQRS;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        (IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationRules = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationRules.Where(e => e.Errors.Any())
                                          .SelectMany(e => e.Errors)
                                          .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return await next();
        }
    }
}