using Dashboard.DataAcess.Interfaces;
using Dashboard.Models;

namespace Dashboard.DataAccess.Interfaces
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        List<Department> GetAll();
    }
}
