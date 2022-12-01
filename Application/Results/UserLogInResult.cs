namespace Application.Results;

public class UserLogInResult
{
    public Guid UserId { get; init; }

    public UserLogInResult(Guid userId)
    {
        UserId = userId;
    }
}