﻿

using models.dto;

namespace Librarium.Services.application_services.ports;

public interface IMemberRepository
{
    Task <IEnumerable<MemberDto>> GetAllMembers();
}