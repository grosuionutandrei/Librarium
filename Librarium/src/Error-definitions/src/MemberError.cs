namespace Error_definitions;

/// <summary>
/// Represents an error state for member-related operations.
/// Simple data holder for error code and message.
/// </summary>
public class MemberError
{
    public string Code { get; set; }
    public string Message { get; set; }

    public MemberError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Common member error codes
    /// </summary>
    public static class Codes
    {
        public const string InvalidEmail = "MEMBER_INVALID_EMAIL";
        public const string InvalidFirstName = "MEMBER_INVALID_FIRST_NAME";
        public const string InvalidLastName = "MEMBER_INVALID_LAST_NAME";
        public const string MemberNotFound = "MEMBER_NOT_FOUND";
        public const string DuplicateEmail = "MEMBER_DUPLICATE_EMAIL";
        public const string InvalidMemberState = "MEMBER_INVALID_STATE";
    }
}