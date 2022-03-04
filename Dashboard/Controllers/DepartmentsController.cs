#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Configuration;
using Dashboard.Services.Interfaces;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DashboardContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentService _service;
        private readonly ILogger _logger;

        public DepartmentsController(IUnitOfWork unitOfWork, DashboardContext context, IDepartmentService service, ILogger<DepartmentsController> logger)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _service = service;
            _logger = logger;
        }

        // GET: api/Departments
        // Retrieve all data stored
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            _logger.LogInformation($"[{DateTime.Now}] LOG: Executing GET api/Departments");
            try
            {
                var departments = await _service.ListDepartments();
                if (departments.Count() == 0)
                {
                    _logger.LogInformation($"[{DateTime.Now}] LOG: Nothing was found");
                    return StatusCode(StatusCodes.Status404NotFound);                    
                }
                _logger.LogInformation($"[{DateTime.Now}] LOG: Returning data found");
                return StatusCode(StatusCodes.Status200OK, departments);                
            }
            catch (Exception e)
            {
                _logger.LogError($"[{DateTime.Now}] ERROR: {e}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Departments/{ID}
        // Retrieve data stored based on ID passed as parameter
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            _logger.LogInformation($"[{DateTime.Now}] LOG: Executing GET api/Departments/{{id}}");
            try
            {
                var department = await _service.GetDepartmentById(id);                

                if (department == null)
                {
                    _logger.LogInformation($"[{DateTime.Now}] LOG: Nothing was found.");
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                _logger.LogInformation($"[{DateTime.Now}] LOG: Returning data found");
                return StatusCode(StatusCodes.Status200OK, department);
            }
            catch (Exception e)
            {
                _logger.LogError($"[{DateTime.Now}] ERROR: {e}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DepartmentID)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // Create a new department
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {            
            _logger.LogInformation($"[{DateTime.Now}] LOG: Executing POST api/Departments");
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.CreateDepartment(department);
                    _logger.LogInformation($"[{DateTime.Now}] LOG: Department created!");
                    return StatusCode(StatusCodes.Status201Created, department);
                }
                _logger.LogInformation($"[{DateTime.Now}] LOG: Request body is missing information");
                return StatusCode(StatusCodes.Status400BadRequest);               
            }
            catch (Exception e)
            {
                _logger.LogError($"[{DateTime.Now}] ERROR: {e}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }
    }
}
