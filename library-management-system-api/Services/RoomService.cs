using System;
using AutoMapper;
using library_management_system_api.DTOs.Room;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using library_management_system_api.Services.Interfaces;

namespace library_management_system_api.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepo;
    private readonly IMapper _mapper;
    public RoomService(IRoomRepository roomRepo, IMapper mapper)
    {
        _roomRepo = roomRepo;
        _mapper = mapper;
    }
    public async Task<RoomDto> CreateRoomAsync(CreateRoomDto createRoomDto)
    {
        var room = _mapper.Map<Room>(createRoomDto);
        await _roomRepo.CreateAsync(room);

        var result = _mapper.Map<RoomDto>(room);
        return result;
    }

    public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await _roomRepo.GetAllAsync();
        var result = _mapper.Map<IEnumerable<RoomDto>>(rooms);

        return result;
    }

    public async Task<RoomDto?> GetByIdRoomAsync(Guid roomId)
    {
        var room = await _roomRepo.GetByIdAsync(roomId);
        if (room is null) return null;

        var result = _mapper.Map<RoomDto>(room);
        return result;
    }

    public async Task<RoomDto?> PatchRoomAsync(Guid roomId, PatchRoomDto patchRoomDto)
    {
        var room = await _roomRepo.GetByIdAsync(roomId);
        if (room is null) return null;

        if (patchRoomDto.RoomName != null) room.RoomName = patchRoomDto.RoomName;
        if (patchRoomDto.Type != null) room.Type = patchRoomDto.Type;
        if (patchRoomDto.Capacity.HasValue) room.Capacity = patchRoomDto.Capacity.Value;
        if (patchRoomDto.IsAvailable.HasValue) room.IsAvailable = patchRoomDto.IsAvailable.Value;

        await _roomRepo.PatchAsync(room);

        var result = _mapper.Map<RoomDto>(room);
        return result;
    }

    public async Task<bool> DeleteRoomAsync(Guid roomId)
    {
        var room = await _roomRepo.GetByIdAsync(roomId);
        if (room is null) return false;

        await _roomRepo.DeleteAsync(room);
        return true;
    }
}
