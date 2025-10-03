using System;

namespace library_management_system_api.DTOs.Movie;

public class MovieDto
{
    public Guid MovieId { get; set; }
    public string Title { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string Synopsis { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
    public string? Director { get; set; }
}
