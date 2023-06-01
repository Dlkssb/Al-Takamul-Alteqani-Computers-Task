using AutoMapper;
using DataAccess.ResponseDTOs;
using Models;


namespace DataAccess.Mapping
{
    public class BookMapper: Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookResponse>();
        }
    }
}
