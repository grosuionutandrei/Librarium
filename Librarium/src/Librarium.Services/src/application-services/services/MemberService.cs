﻿using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.ports;
using models.dto;

namespace Librarium.Services.application_services.services;

public class MemberService(IMemberRepository memberRepository):IMemberService
{
    public  async  Task<List<MemberDto>> GetAllMembers()
    {

        var response = await memberRepository.GetAllMembers();
        return response.ToList();
    }
}