using Application.Commands;
using FluentValidation;

namespace Application.Validation;

public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
{
    public UserRegisterCommandValidator()
    {
        RuleFor(command => command.FirstName)
            .MustNotBeNullOrEmptyOrWhiteSpace();

        RuleFor(command => command.LastName)
            .MustNotBeNullOrEmptyOrWhiteSpace();

        RuleFor(command => command.UserName)
            .MustNotBeNullOrEmptyOrWhiteSpace();

        RuleFor(command => command.Password)
            .MustNotBeNullOrEmptyOrWhiteSpace();
    }
}