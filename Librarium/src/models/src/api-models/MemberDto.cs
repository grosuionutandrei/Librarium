

namespace models.api_models;

public record MemberDto(string FirstName, string LastName, string Email);
public record MemberWithPhoneNumberDto(Guid MemberId,string FirstName, string LastName, string Email, string PhoneNumber);