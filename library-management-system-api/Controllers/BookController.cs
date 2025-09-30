using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system_api.DTOs.Book;
using library_management_system_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook(Guid id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book is null) return NotFound("book not found!");

        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> PostBook([FromBody] CreateBookDto createBookDto)
    {
        var newBook = await _bookService.CreateBookAsync(createBookDto);

        var result = CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        return result;
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<BookDto>> PatchBook(Guid id, [FromBody] PatchBookDto patchBookDto)
    {
        var wasUpdated = await _bookService.PatchBookAsync(id, patchBookDto);
        if (wasUpdated is null) return NotFound("book not found!");

        return Ok(wasUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(Guid id)
    {
        var wasDeleted = await _bookService.DeleteBookAsync(id);
        if (!wasDeleted) return NotFound("book not found!");

        return Ok("book deleted successfully");
    }
}