using LibraryWebApp.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryWebApp.Infrastructure.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext AppDbContext;
        protected RepositoryBase(AppDbContext dbContext) => AppDbContext = dbContext;

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              AppDbContext.Set<T>()
                .AsNoTracking() :
              AppDbContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
                AppDbContext.Set<T>()
                    .Where(expression)
                    .AsNoTracking() :
                AppDbContext.Set<T>()
                    .Where(expression);
        public void Create(T entity) => AppDbContext.Set<T>().Add(entity);
        public void Update(T entity) => AppDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => AppDbContext.Set<T>().Remove(entity);
    }
}
