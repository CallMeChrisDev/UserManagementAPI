namespace Application.Commands;

public class UserRegisterCommand
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }

    public UserRegisterCommand(string firstName, string lastName, string userName, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Password = password;
    }
}