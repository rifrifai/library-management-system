using System;
using AutoMapper;
using library_management_system_api.DTOs.Siswa;
using library_management_system_api.Models;

namespace library_management_system_api.Profiles;

public class SiswaProfile : Profile
{
    public SiswaProfile()
    {
        CreateMap<Siswa, SiswaDto>();
        CreateMap<CreateSiswaDto, Siswa>();
        CreateMap<PatchSiswaDto, Siswa>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
