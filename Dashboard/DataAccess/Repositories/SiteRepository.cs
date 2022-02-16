using Dashboard.Data;
using Dashboard.DataAccess.Interfaces;
using Dashboard.DataAcess.Repositories;
using Dashboard.Models;

namespace Dashboard.DataAccess.Repositories
{
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository
    {
        public SiteRepository(DashboardContext dashboardContext) : base(dashboardContext) { }
    }
}
