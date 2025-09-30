using System;
using library_management_system_api.Data;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;

namespace library_management_system_api.Services.Interfaces;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepo;
    public BookService(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }
    public Task<List<Book>> GetAllBooksAsync()
    {
    }
    public Task<Book?> GetBookByIdAsync(Guid id)
    {
    }
    public Task CreateBookAsync(Book book)
    {
    }
    public Task UpdateBookAsync(Book book)
    {
    }

    public Task DeleteBookAsync(Guid id)
    {
    }
}
