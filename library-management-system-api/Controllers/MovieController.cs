using System;
using library_management_system_api.DTOs.Movie;
using library_management_system_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;
    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
    {
        try
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }
        catch (Exception)
        {
            throw new Exception("Something wrong in GetAllMovies");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetMovie(Guid id)
    {
        try
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie is null) return NotFound("Movie is not found!");

            return Ok(movie);
        }
        catch (Exception)
        {
            throw new Exception("Something wrong in GetMovie");
        }
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> PostMovie([FromBody] CreateMovieDto createMovieDto)
    {
        try
        {
            var newMovie = await _movieService.CreateMovieAsync(createMovieDto);
            var result = CreatedAtAction(nameof(GetMovie), new { id = newMovie.MovieId }, newMovie);
            return result;
        }
        catch (Exception)
        {
            throw new Exception("Something wrong in Create Movie");
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<MovieDto>> PatchMovie(Guid id, [FromBody] PatchMovieDto patchMovieDto)
    {
        try
        {
            var wasUpdated = await _movieService.PatchMovieAsync(id, patchMovieDto);
            if (wasUpdated is null) return NotFound("Movie is not found!");

            return Ok(wasUpdated);
        }
        catch (Exception)
        {
            throw new Exception("Something wrong in Edit Movie!");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MovieDto>> DeleteMovie(Guid id)
    {
        try
        {
            var wasDeleted = await _movieService.DeleteMovieAsync(id);
            if (!wasDeleted) return NotFound("Movie is not found!");

            return Ok("Movie deleted successfully");
        }
        catch (Exception)
        {
            throw new Exception("Something wrong in Delete movie!");
        }
    }
}
