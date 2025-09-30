using System;
using System.ComponentModel.DataAnnotations;

namespace library_management_system_api.DTOs.Book;

public class CreateBookDto
{
    [Required]
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Genre { get; set; }
    public int Year { get; set; }
    public int Stock { get; set; }
}
