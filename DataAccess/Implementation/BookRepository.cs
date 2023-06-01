using DataAccess.Context;
using DataAccess.Exceptions;
using DataAccess.Interfaces;
using DataAccess.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using Models;


namespace DataAccess.Implementation
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Save()
        {
           _context.SaveChanges();
        }

        public async Task Update(Book book)
        {
            try
            {
                _dbSet.Update(book);
                Save();
            }
            catch {

                throw new BadRequestException("Can't update the current book");
            }
        }

        public async Task<List<BookResponse>> GetBooks()
        {
            try
            {
                List<BookResponse> books = _context.bookResponses.FromSqlRaw("EXEC GetAllBookAuthors;").ToList();
                return books;
            }
            catch (Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }
           
        }
    }
}
