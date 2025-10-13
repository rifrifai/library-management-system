using System;
using library_management_system_api.DTOs.Room;

namespace library_management_system_api.Services.Interfaces;

public interface IRoomService
{
    Task<RoomDto> CreateRoomAsync(CreateRoomDto createRoomDto);
    Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
    Task<RoomDto?> GetByIdRoomAsync(Guid roomId);
    Task<RoomDto?> PatchRoomAsync(Guid roomId, PatchRoomDto patchRoomDto);
    Task<bool> DeleteRoomAsync(Guid roomId);
}
