namespace UserManagement.Contracts;

public class UserLogInRequest
{
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}