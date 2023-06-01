using AutoMapper;
using DataAccess.DTOs;
using DataAccess.Implementation;
using DataAccess.Interfaces;
using DataAccess.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Altkamul_Alteqani_Task.API.Controllers
{
    [ApiController]
    [Route("api/Books")]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
      private readonly  IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
                this.bookRepository = bookRepository;
                  _mapper = mapper;

        }
        [HttpGet(Name = "GetBooks")]
        
        public async Task<IActionResult> GetBooks()
        {
            var books = await bookRepository.GetBooks();
            var booksResponse = _mapper.Map<List<BookResponse>>(books);
            return Ok(booksResponse);
        }

        [HttpPost(Name = "PostBook")]
        public void PostAuthors(BookDTO bookDTO)
        {
            Book book = new Book() { Title= bookDTO.Title,AuthorId=bookDTO.AuthorId,Subcategory=bookDTO.Subcategory,Category=bookDTO.Category};
            if (ModelState.IsValid)
            {
                bookRepository.Add(book);
            }
        }
    }
}

