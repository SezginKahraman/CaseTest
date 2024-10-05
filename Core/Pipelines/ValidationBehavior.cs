using Core.CrossCuttingConcerns.Exceptions.Types;
using FluentValidation;
using MediatR;


namespace Core.Application.Pipelines.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            IEnumerable<ValidationExceptionModel> errors = _validators
                .Select(async validator => await validator.ValidateAsync(context, cancellationToken))
                .SelectMany(result => result.Result.Errors)
                .Where(failure => failure != null)
                .GroupBy(
                    keySelector: p => p.PropertyName,
                    resultSelector: (propertyName, errors) =>
                        new ValidationExceptionModel { Property = propertyName, Errors = errors.Select(e => e.ErrorMessage) })
                .ToList();

            if (errors.Any())
            {
                throw new Core.CrossCuttingConcerns.Exceptions.Types.ValidationException(errors);
            }
            TResponse response = await next();
            return response;
        }
    }
}
