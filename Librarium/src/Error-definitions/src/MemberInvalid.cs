namespace Error_definitions;

/// <summary>
/// Exception thrown when a Member is in an invalid state.
/// Used to represent domain validation errors for member-related operations.
/// </summary>
public class MemberInvalid : Exception
{
    public MemberInvalid(string message) : base(message)
    {
    }

    public MemberInvalid(string message, Exception innerException) : base(message, innerException)
    {
    }
}


