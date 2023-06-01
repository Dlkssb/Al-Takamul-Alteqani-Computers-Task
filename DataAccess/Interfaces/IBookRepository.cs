using DataAccess.ResponseDTOs;
using Models;


namespace DataAccess.Interfaces
{
    public interface IBookRepository:IRepositoryBase<Book>
    {
        public Task Update(Book book);
        void Save();
        public Task<List<BookResponse>> GetBooks();
    }
}
