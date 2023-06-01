using Models;
using System.Linq.Expressions;


namespace DataAccess.Interfaces
{
    public interface IRepositoryBase<T> where T : BaseModel
    {

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includePro = null);

        public Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includePro = null);

        public Task Delete(T Entity);

        public Task Add(T Entity);


    }
}
