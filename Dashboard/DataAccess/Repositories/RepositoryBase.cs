using Dashboard.Data;
using Dashboard.DataAcess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dashboard.DataAcess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DashboardContext DashboardContext { get; set; }
        public RepositoryBase(DashboardContext repositoryContext)
        {
            this.DashboardContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.DashboardContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.DashboardContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.DashboardContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.DashboardContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.DashboardContext.Set<T>().Remove(entity);
        }
    }
}
