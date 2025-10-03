using System;

namespace library_management_system_api.Models;

public class Movie
{
    public Guid MovieID { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public required string Synopsis { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? Director { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}
