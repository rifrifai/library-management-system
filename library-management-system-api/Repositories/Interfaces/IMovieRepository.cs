using System;
using library_management_system_api.Models;

namespace library_management_system_api.Repositories.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(Guid movieId);
    Task CreateAsync(Movie movie);
    Task<bool> UpdateAsync(Movie movie);
    Task<bool> SoftDeleteAsync(Guid movieId);
}
