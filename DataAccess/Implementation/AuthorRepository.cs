using DataAccess.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;


namespace DataAccess.Implementation
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public void Save()
        {
           _context.SaveChanges();
        }

        public async Task Update(Author author)
        {
            _dbSet.Update(author);
            Save();
        }
        
        public async Task<List<Author>> GetAuthors()
        {
            IQueryable<Author> authors =  _context.Authors.FromSqlRaw($"EXECUTE GetAuthors");
            return authors.ToList();

        }
    }
}
