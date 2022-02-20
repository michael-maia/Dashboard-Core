using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DashboardContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Department>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(DepartmentRepository));
                return new List<Department>();
            }
        }

        public override async Task<bool> Update(Department entity)
        {
            try
            {
                var existingUser = await _dbSet.Where(x => x.DepartmentID == entity.DepartmentID).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    return await Add(entity);                    
                }
                existingUser.Name = entity.Name;
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(DepartmentRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await _dbSet.Where(x => x.DepartmentID == id).FirstOrDefaultAsync();
                if(exist == null)
                {
                    return false;
                }
                _dbSet.Remove(exist);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(DepartmentRepository));
                return false;
            }
        }
    }
}
