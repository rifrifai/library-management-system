using System;
using AutoMapper;
using library_management_system_api.DTOs.Book;
using library_management_system_api.Models;

namespace library_management_system_api.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, Book>();
    }
}
