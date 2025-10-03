using System;

namespace library_management_system_api.DTOs.Movie;

public class PatchMovieDto
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public string? Synopsis { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? Director { get; set; }
}
