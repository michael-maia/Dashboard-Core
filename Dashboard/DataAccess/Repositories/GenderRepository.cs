using Dashboard.Data;
using Dashboard.DataAccess.Interfaces;
using Dashboard.DataAcess.Repositories;
using Dashboard.Models;

namespace Dashboard.DataAccess.Repositories
{
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(DashboardContext dashboardContext) : base(dashboardContext) { }
    }
}
