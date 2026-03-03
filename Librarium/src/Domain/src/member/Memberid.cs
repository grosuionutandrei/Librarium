using Error_definitions;

namespace Domain.member;

public class MemberId
{
    public Guid Id { get; }

    public MemberId(Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString()))
        {
            throw new MemberInvalid("Id can not be empty ");
        }

        Id = id;
    }
}