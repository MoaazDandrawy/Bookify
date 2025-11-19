using FluentValidation;

namespace Bookify.Application.Users.RegisterUser
{
    internal sealed class ReisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public ReisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}
