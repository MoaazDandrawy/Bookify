using Bookify.Application.Abstractions.Messaging;
using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace Bookify.Application.Abstractions.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>// IPipeLineBehavior da 3lshan y2ool en el class da haikon part mn el MediatR PipeLine
        where TRequest : IBaseCommand //howa 3aml implement l IBaseCommand 3lshan hai3ml logging l el Commands Bas
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            /*
             User sends ReserveBookingCommand
                ↓
            MediatR pipeline
                ↓
            ValidationBehavior runs
                ↓
            ReserveBookingCommandValidator gets applied
                ↓
            If any rule fails → throw ValidationException
                ↓
            Else → go to ReserveBookingCommandHandler
             */


            // law m3ndish ai validaor f el Command (ya3ny mafish ai 7aga a3ml 3aleha check) da roo7 nafz el Command yala
            if (!_validators.Any())
            {
                return await next();
            }
            //tayb lw fih validator b2a.....⤵
            var context = new ValidationContext<TRequest>(request);

            var validationErrors = _validators
            .Select(validator => validator.Validate(context))// leh hena m3mlsh Validate(request) ==> 3lshan fih details aktar hatroo7 lma ab3t el context zai el meta data masln
            .Where(validationResult => validationResult.Errors.Any())
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new Bookify.Application.Exceptions.ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

            if(validationErrors.Any())
            {
                throw new Bookify.Application.Exceptions.ValidationException(validationErrors);
            }
            return await next();
        }
    }
}
