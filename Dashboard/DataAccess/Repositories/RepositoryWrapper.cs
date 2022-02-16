using Dashboard.Data;
using Dashboard.DataAccess.Interfaces;
using Dashboard.DataAccess.Repositories.Interfaces;

namespace Dashboard.DataAccess.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DashboardContext _dashboardContext;
        private IDepartmentRepository _department;
        private IUserRepository _user;
        private IGenderRepository _gender;
        private IRoleRepository _role;
        private ISiteRepository _site;

        public IDepartmentRepository Department
        {
            get 
            {
                if(_department == null)
                {
                    _department = new DepartmentRepository(_dashboardContext);
                }
                return _department;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_dashboardContext);
                }
                return _user;
            }
        }

        public IGenderRepository Gender
        {
            get
            {
                if (_gender == null)
                {
                    _gender = new GenderRepository(_dashboardContext);
                }
                return _gender;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_dashboardContext);
                }
                return _role;
            }
        }

        public ISiteRepository Site
        {
            get
            {
                if (_site == null)
                {
                    _site = new SiteRepository(_dashboardContext);
                }
                return _site;
            }
        }

        public RepositoryWrapper(DashboardContext dashboardContext)
        {
            _dashboardContext = dashboardContext;
        }

        public void Save()
        {
            _dashboardContext.SaveChanges();
        }
    }
}
