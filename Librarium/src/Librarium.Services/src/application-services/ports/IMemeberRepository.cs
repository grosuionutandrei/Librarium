﻿

using Domain.member;
using models.api_models;

namespace Librarium.Services.application_services.ports;

public interface IMemberRepository
{
    Task <IEnumerable<MemberDto>> GetAllMembers();
    Task <IEnumerable<Member>>  GetAllMembersWithPhoneNumber();
}