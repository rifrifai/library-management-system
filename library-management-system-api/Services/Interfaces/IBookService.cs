using System;
using library_management_system_api.DTOs.Book;
using library_management_system_api.Models;

namespace library_management_system_api.Services.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync();
    Task<BookDto?> GetBookByIdAsync(Guid id);
    Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
    Task<BookDto?> PatchBookAsync(Guid id, PatchBookDto patchBookDto);
    Task<bool> DeleteBookAsync(Guid id);
}
