namespace Application.Queries;

public class UserLogInQuery
{
    public string UserName { get; init; }
    public string Password { get; init; }

    public UserLogInQuery(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}