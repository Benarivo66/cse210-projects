
public class CustomException : Exception
{
    public enum ErrorCode
    {
        UserNotFound,
        IdNotFound,
        InvalidInput,
        AdminPriviledge
    }

    public ErrorCode Code { get; }

    public CustomException(ErrorCode code, string message) : base(message)
    {
        Code = code;
    }
}
