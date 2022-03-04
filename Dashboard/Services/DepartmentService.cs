using Dashboard.Configuration;
using Dashboard.Models;
using Dashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Department>> ListDepartments()
        {            
            return await _unitOfWork.Department.All();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _unitOfWork.Department.GetById(id);
        }

        public async Task CreateDepartment(Department department)
        {            
            await _unitOfWork.Department.Add(department);
            await _unitOfWork.CompleteAsync();                                   
        }
    }
}
