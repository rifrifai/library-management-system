using System;
using library_management_system_api.Models;

namespace library_management_system_api.Repositories.Interfaces;

public interface IRoomRepository
{
    Task CreateAsync(Room room);
    Task<IEnumerable<Room>> GetAllAsync();
    Task<Room?> GetByIdAsync(Guid roomId);
    Task<bool> PatchAsync(Room room);
    Task<bool> DeleteAsync(Room room);
}
