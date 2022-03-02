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
    }
}
