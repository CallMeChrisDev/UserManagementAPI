using FluentValidation;

namespace Application.Validation;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string?> MustNotBeNullOrEmptyOrWhiteSpace<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder
            .Must(property => !string.IsNullOrWhiteSpace(property))
            .WithMessage("{PropertyName} must not be null, empty or have only white spaces.");
    }
}