using Dashboard.Data;
using Dashboard.DataAccess.Interfaces;
using Dashboard.DataAcess.Repositories;
using Dashboard.Models;

namespace Dashboard.DataAccess.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DashboardContext dashboardContext) : base(dashboardContext) { }
    }
}
