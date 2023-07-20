using AutoMapper;
using LibraryWebApp.Domain.Entities.DataTransferObjects;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Updating;
using LibraryWebApp.Domain.Entities.Models;

namespace LibraryWebApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<BookForCreationDto, Book>();
            CreateMap<ReviewForCreationDto, Review>();
            CreateMap<AuthorForUpdateDto, Author>().ReverseMap();
            CreateMap<BookForUpdateDto, Book>().ReverseMap();
            CreateMap<ReviewForUpdateDto, Review>().ReverseMap();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
