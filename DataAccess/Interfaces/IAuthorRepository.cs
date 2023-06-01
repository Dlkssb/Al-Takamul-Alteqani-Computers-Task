using Models;


namespace DataAccess.Interfaces
{
    public interface IAuthorRepository:IRepositoryBase<Author>
    {
        public Task Update(Author obj);
        void Save();
        public Task<List<Author>> GetAuthors();
       
    }
}
