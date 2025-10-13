using System;
using library_management_system_api.Data;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_management_system_api.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly LibraryContext _context;
    public RoomRepository(LibraryContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Room room)
    {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        var rooms = await _context.Rooms.AsNoTracking().ToListAsync();
        return rooms;
    }

    public async Task<Room?> GetByIdAsync(Guid roomId)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);
        return room;
    }

    public async Task<bool> PatchAsync(Room room)
    {
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Room room)
    {
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return true;
    }
}
