using Dashboard.Data;
using Dashboard.DataAccess.Interfaces;
using Dashboard.DataAcess.Repositories;
using Dashboard.Models;

namespace Dashboard.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DashboardContext dashboardContext) : base(dashboardContext) { }
    }
}

//TODO: PESQUISAR SOBRE SERVICES E COMO COLOCAR NESTE PROJETO
