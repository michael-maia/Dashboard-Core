using Dashboard.Models;

namespace Dashboard.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> ListDepartments();
    }
}
