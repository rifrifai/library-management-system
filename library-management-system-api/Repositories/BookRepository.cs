using System;
using library_management_system_api.Data;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_management_system_api.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;
    public BookRepository(LibraryContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var getAll = await _context.Books.Where(b => !b.IsDeleted).ToListAsync();
        return getAll;
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        var getById = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        return getById;
    }
    public async Task CreateAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Book book)
    {
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        if (book is null)
        {
            return false;
        }
        book.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
