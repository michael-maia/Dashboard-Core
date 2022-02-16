using Dashboard.Models;

namespace Dashboard.DataAccess.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
    }
}
