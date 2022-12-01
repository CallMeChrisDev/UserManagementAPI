using Application.Queries;
using FluentValidation;

namespace Application.Validation;

public class UserLogInQueryValidator : AbstractValidator<UserLogInQuery>
{
    public UserLogInQueryValidator()
    {
        RuleFor(query => query.UserName)
            .MustNotBeNullOrEmptyOrWhiteSpace();
        
        RuleFor(query => query.UserName)
            .MustNotBeNullOrEmptyOrWhiteSpace();
    }   
}