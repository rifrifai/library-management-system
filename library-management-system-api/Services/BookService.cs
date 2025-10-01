using System;
using AutoMapper;
using library_management_system_api.DTOs.Book;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using library_management_system_api.Services.Interfaces;

namespace library_management_system_api.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepo;
    private readonly IMapper _mapper;
    public BookService(IBookRepository bookRepo, IMapper mapper)
    {
        _bookRepo = bookRepo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await _bookRepo.GetAllAsync();
        var result = _mapper.Map<IEnumerable<BookDto>>(books);
        return result;
    }

    public async Task<BookDto?> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepo.GetByIdAsync(id);
        if (book is null) return null;
        
        var result = _mapper.Map<BookDto>(book);
        return result;
    }
    public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
    {
        var book = _mapper.Map<Book>(createBookDto);
        await _bookRepo.CreateAsync(book);

        var result = _mapper.Map<BookDto>(book);
        return result;
    }

    public async Task<BookDto?> PatchBookAsync(Guid id, PatchBookDto patchBookDto)
    {
        var book = await _bookRepo.GetByIdAsync(id);
        if (book is null) return null;

        // Manual update - hanya update yang tidak null
        if (patchBookDto.Title != null)
            book.Title = patchBookDto.Title;
        
        if (patchBookDto.Author != null)
            book.Author = patchBookDto.Author;
        
        if (patchBookDto.Genre != null)
            book.Genre = patchBookDto.Genre;
        
        if (patchBookDto.Year.HasValue)
            book.Year = patchBookDto.Year.Value;
        
        if (patchBookDto.Stock.HasValue)
            book.Stock = patchBookDto.Stock.Value;
        
        if (patchBookDto.IsDeleted.HasValue)
            book.IsDeleted = patchBookDto.IsDeleted.Value;

        await _bookRepo.UpdateAsync(book);

        var result = _mapper.Map<BookDto>(book);
        return result;
    }

    public Task<bool> DeleteBookAsync(Guid id)
    {
        var result = _bookRepo.SoftDeleteAsync(id);
        return result;
    }
}
