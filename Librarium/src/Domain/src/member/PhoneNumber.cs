using Error_definitions;

namespace Domain.member;

public class PhoneNumber
{
    public string Number { get; }

    public PhoneNumber(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            throw new MemberInvalid("Phone number cannot be null or empty.");
        }

        Number = number;
    }
    public override string ToString() => Number;
}