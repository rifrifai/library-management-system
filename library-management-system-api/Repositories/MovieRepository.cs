using System;
using library_management_system_api.Data;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_management_system_api.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly LibraryContext _context;
    public MovieRepository(LibraryContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        var result = await _context.Movies.Where(m => !m.IsDeleted).AsNoTracking().ToListAsync();
        return result;
    }

    public async Task<Movie?> GetByIdAsync(Guid movieId)
    {
        var result = await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == movieId && !m.IsDeleted);
        return result;
    }
    public async Task CreateAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();

    }
    public async Task<bool> UpdateAsync(Movie movie)
    {
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SoftDeleteAsync(Guid movieId)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == movieId && !m.IsDeleted);
        if (movie is null) return false;

        movie.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
