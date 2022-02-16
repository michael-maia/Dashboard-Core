using Dashboard.Data;
using Dashboard.DataAccess.Interfaces;
using Dashboard.DataAcess.Repositories;
using Dashboard.Models;

namespace Dashboard.DataAccess.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DashboardContext dashboardContext) : base(dashboardContext) { }
    }
}
