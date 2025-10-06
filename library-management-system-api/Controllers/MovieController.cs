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
        var movies = await _movieService.GetAllMoviesAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetMovie(Guid id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie is null) return NotFound("Movie is not found!");

        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> PostMovie([FromBody] CreateMovieDto createMovieDto)
    {
        var newMovie = await _movieService.CreateMovieAsync(createMovieDto);
        var result = CreatedAtAction(nameof(GetMovie), new { id = newMovie.MovieId }, newMovie);
        return result;
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<MovieDto>> PatchMovie(Guid id, [FromBody] PatchMovieDto patchMovieDto)
    {
        var wasUpdated = await _movieService.PatchMovieAsync(id, patchMovieDto);
        if (wasUpdated is null) return NotFound("Movie is not found!");

        return Ok(wasUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MovieDto>> DeleteMovie(Guid id)
    {
        var wasDeleted = await _movieService.DeleteMovieAsync(id);
        if (!wasDeleted) return NotFound("Movie is not found!");

        return NoContent();
    }
}
