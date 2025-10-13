using System;
using AutoMapper;
using library_management_system_api.DTOs.Room;
using library_management_system_api.Models;

namespace library_management_system_api.Profiles;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomDto>();
        CreateMap<CreateRoomDto, Room>();
        CreateMap<PatchRoomDto, Room>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
