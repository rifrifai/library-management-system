using System;
using library_management_system_api.Models;

namespace library_management_system_api.Services.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(Guid id);
    Task CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(Guid id);
}
