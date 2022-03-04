using Dashboard.Models;

namespace Dashboard.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> ListDepartments();
        Task<Department> GetDepartmentById(int id);
        Task CreateDepartment(Department department);
    }
}
