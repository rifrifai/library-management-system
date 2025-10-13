using System;
using library_management_system_api.DTOs.Room;
using library_management_system_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllRooms()
    {
        var rooms = await _roomService.GetAllRoomsAsync();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDto>> GetRoom(Guid id)
    {
        var room = await _roomService.GetByIdRoomAsync(id);
        if (room is null) return NotFound("Room is not found!");

        return Ok(room);
    }

    [HttpPost]
    public async Task<ActionResult<RoomDto>> PostRoom([FromBody] CreateRoomDto createRoomDto)
    {
        var newRoom = await _roomService.CreateRoomAsync(createRoomDto);
        var result = CreatedAtAction(nameof(GetRoom), new { id = newRoom.Id }, newRoom);
        return result;
    }

    [HttpPatch]
    public async Task<ActionResult<RoomDto>> PatchRoom(Guid id, [FromBody] PatchRoomDto patchRoomDto)
    {
        var wasUpdated = await _roomService.PatchRoomAsync(id, patchRoomDto);
        if (wasUpdated is null) return NotFound("Room is not found!");

        return Ok(wasUpdated);
    }

    [HttpDelete]
    public async Task<ActionResult<RoomDto>> DeleteRoom(Guid id)
    {
        var wasDeleted = await _roomService.DeleteRoomAsync(id);
        if (!wasDeleted) return NotFound("Room is not found!");

        return NoContent();
    }
}
