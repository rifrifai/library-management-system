using System;

namespace library_management_system_api.Models;

public class Room
{
    public Guid Id { get; set; }
    public required string RoomName { get; set; }
    public required string Type { get; set; }   //single, double, suite
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
