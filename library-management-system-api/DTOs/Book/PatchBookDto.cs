using System;

namespace library_management_system_api.DTOs.Book;

public class PatchBookDto
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Genre { get; set; }
    public int Year { get; set; }
    public int Stock { get; set; }
    public bool IsDeleted { get; set; }
}
