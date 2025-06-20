using AutoMapper;
using BookReadingManager.Application.DTOs;
using BookReadingManager.Domain.Entities;
using BookReadingManager.Domain.Enums;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingManager.Application.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
        }
    }
}
