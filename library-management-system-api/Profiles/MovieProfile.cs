using System;
using AutoMapper;
using library_management_system_api.DTOs.Book;
using library_management_system_api.DTOs.Movie;
using library_management_system_api.Models;

namespace library_management_system_api.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        // memetakan dari Model movie ke MovieDto
        CreateMap<Movie, MovieDto>();
        // memetakan dari CreateMovieDto ke Model movie
        CreateMap<CreateMovieDto, Movie>();
        // memetakan untuk operasi PATCH
        CreateMap<PatchMovieDto, Movie>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
