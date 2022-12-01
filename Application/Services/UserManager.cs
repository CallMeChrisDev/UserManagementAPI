using Application.Commands;
using Application.Interfaces;
using Application.Queries;
using Application.Results;
using Application.Validation;
using Domain;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserRegisterResult> RegisterUser(UserRegisterCommand command)
    {
        UserRegisterCommandValidator validator = new();
        ValidationResult validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // TODO: Use password hashing service
        User? user = await _userRepository.GetUser(command.UserName);
        if (user is not null)
        {
            throw new Exception("User name already exists.");
        }

        var userId = Guid.NewGuid();

        await _userRepository.AddUser(new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            PasswordHash = command.Password,
            UserId = userId,
            UserName = command.UserName
        });

        return new UserRegisterResult(userId);
    }

    public async Task<UserLogInResult> LogInUser(UserLogInQuery query)
    {
        UserLogInQueryValidator validator = new();
        ValidationResult validationResult = await validator.ValidateAsync(query);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        User? user = await _userRepository.GetUser(query.UserName);
        if (user is null)
        {
            throw new Exception("User doesn't exist.");
        }

        // TODO: Use password hashing service
        if (user.PasswordHash != query.Password)
        {
            throw new Exception("Password is incorrect.");
        }

        return new UserLogInResult(user.UserId);
    }
}