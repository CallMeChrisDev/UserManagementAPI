using Application.Commands;
using Application.Queries;
using Application.Results;
using LanguageExt.Common;

namespace Application.Interfaces;

public interface IUserManager
{
    public Task<UserRegisterResult> RegisterUser(UserRegisterCommand command);
    public Task<UserLogInResult> LogInUser(UserLogInQuery query);
}