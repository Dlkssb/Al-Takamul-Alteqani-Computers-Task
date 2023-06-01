using DataAccess.Context;
using DataAccess.Exceptions;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;


namespace DataAccess.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T Entity)
        {
            try
            {
                var R = await _dbSet.AddAsync(Entity);
                _context.SaveChanges();
            }
            catch {

                throw new BadRequestException($"Cant add the {typeof(T)}");
            }
           
        }

        public async Task Delete(T Entity)
        {
             _dbSet.Remove(Entity);
            _context.SaveChanges();
            
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includePro = null)
        {
            try
            {
                IQueryable<T> Entities = _dbSet.AsQueryable<T>();
                if (filter != null)
                {
                    Entities = Entities.Where(filter);
                }

                if (includePro == null)
                    return await Entities.ToListAsync();
                else
                {
                    foreach (var pro in includePro.Split(','))
                    {
                        Entities = Entities.Include(pro);
                    }
                    return await Entities.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includePro)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (includePro != null)
                {
                    foreach (var pro in includePro.Split(','))
                        query = query.Include(pro);
                }
                query = query.Where(filter);


                return await query.FirstOrDefaultAsync();
            }

            catch (Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

      
    }
}
