using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system_api.DTOs.Book;

public class BookDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Genre { get; set; }
    public int Year { get; set; }
    public int Stock { get; set; }
    public bool IsDeleted { get; set; } 
    // public required string Username { get; set; }
}