namespace Application.Results;

public class UserRegisterResult
{
    public Guid UserId { get; init; }

    public UserRegisterResult(Guid userId)
    {
        UserId = userId;
    }
}