using System;
using library_management_system_api.DTOs.Movie;
using library_management_system_api.Models;

namespace library_management_system_api.Services.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    Task<MovieDto?> GetMovieByIdAsync(Guid movieId);
    Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto);
    Task<MovieDto?> PatchMovieAsync(Guid movieId, PatchMovieDto patchMovieDto);
    Task<bool> DeleteMovieAsync(Guid movieId);
}
