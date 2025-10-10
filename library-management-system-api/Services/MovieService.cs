using System;
using AutoMapper;
using library_management_system_api.DTOs.Movie;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using library_management_system_api.Services.Interfaces;

namespace library_management_system_api.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepo;
    private readonly IMapper _mapper;
    public MovieService(IMovieRepository movieRepo, IMapper mapper)
    {
        _movieRepo = movieRepo;
        _mapper = mapper;
    }
    public async Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto)
    {
        var movie = _mapper.Map<Movie>(createMovieDto);
        await _movieRepo.CreateAsync(movie);

        var result = _mapper.Map<MovieDto>(movie);
        return result;
    }
    public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
    {
        var movies = await _movieRepo.GetAllAsync();
        var result = _mapper.Map<IEnumerable<MovieDto>>(movies);
        return result;
    }

    public async Task<MovieDto?> GetMovieByIdAsync(Guid movieId)
    {
        var movie = await _movieRepo.GetByIdAsync(movieId);
        if (movie is null) return null;

        var result = _mapper.Map<MovieDto>(movie);
        return result;
    }
    public async Task<MovieDto?> PatchMovieAsync(Guid movieId, PatchMovieDto patchMovieDto)
    {
        var movie = await _movieRepo.GetByIdAsync(movieId);
        if (movie is null) return null;

        // manual update, hanya update yang tidak null!
        if (patchMovieDto.Title != null) movie.Title = patchMovieDto.Title;
        if (patchMovieDto.Genre != null) movie.Genre = patchMovieDto.Genre;
        if (patchMovieDto.Synopsis != null) movie.Synopsis = patchMovieDto.Synopsis;
        if (patchMovieDto.ReleaseDate.HasValue) movie.ReleaseDate = patchMovieDto.ReleaseDate.Value;
        if (patchMovieDto.Director != null) movie.Director = patchMovieDto.Director;

        await _movieRepo.UpdateAsync(movie);
        var result = _mapper.Map<MovieDto>(movie);
        return result;
    }

    public async Task<bool> DeleteMovieAsync(Guid movieId)
    {
        var result = await _movieRepo.SoftDeleteAsync(movieId);
        return result;  
    }

}
