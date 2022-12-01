using Application.Results;
using UserManagement.Contracts.Responses;

namespace UserManagement.Mapping;

public static class UserAppToApiMapping
{
    public static UserRegisterResponse ToResponse(this UserRegisterResult result)
    {
        return new UserRegisterResponse
        {
            UserId = result.UserId.ToString()
        };
    }

    public static UserLogInResponse ToResponse(this UserLogInResult result)
    {
        return new UserLogInResponse
        {
            UserId = result.UserId.ToString()
        };
    }
}