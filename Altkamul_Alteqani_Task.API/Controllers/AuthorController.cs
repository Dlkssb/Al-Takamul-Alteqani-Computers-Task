using DataAccess.DTOs;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Altkamul_Alteqani_Task.API.Controllers
{
    [ApiController]
    [Route("api/Authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [HttpGet(Name ="GetAuthors")]
      
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await authorRepository.GetAuthors());
        }

        [HttpPost(Name ="PostAuthor")]
        public void PostAuthors(AuthorDTO authorDTO) {
            Author author = new Author() { Name=authorDTO.Name};
            if(ModelState.IsValid)
            {
                authorRepository.Add(author);
            }
        }
    }
}
