using System;

namespace library_management_system_api.DTOs.Movie;

public class CreateMovieDto
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public required string Synopsis { get; set; }
    public required DateTime ReleaseDate { get; set; }
    public string? Director { get; set; }
}
