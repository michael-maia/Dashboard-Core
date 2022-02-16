using Dashboard.DataAccess.Interfaces;
using Dashboard.DataAccess.Repositories.Interfaces;
using Dashboard.Models;

namespace Dashboard.DataAccess.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IRepositoryWrapper _repoWrapper;

        public DepartmentService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public List<Department> GetAllDepartments()
        {
            var departments = _repoWrapper.Department.FindAll();

            return departments;
        }
    }
}
