using BackendAPI.Database;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly TestWorkDbContext _testWorkDbContext;

        public EmployeesController(TestWorkDbContext testWorkDbContext)
        {
            _testWorkDbContext = testWorkDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _testWorkDbContext.Employee.Where(e => e.InState == true).ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.IdEmployee = 0;
            await _testWorkDbContext.Employee.AddAsync(employeeRequest);
            await _testWorkDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{idEmployee:int}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int idEmployee)
        {
            var employee =
                await _testWorkDbContext.Employee.FirstOrDefaultAsync(e => e.IdEmployee == idEmployee);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPut]
        [Route("{idEmployee:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int idEmployee, [FromBody] Employee updateEmployee)
        {
            var employee =
                await _testWorkDbContext.Employee.FirstOrDefaultAsync(e => e.IdEmployee == idEmployee);
            if (employee == null)
            {
                return NotFound("Сотрудника не существует");
            }

            employee.Surname = updateEmployee.Surname;
            employee.DateOfEmployment = updateEmployee.DateOfEmployment;
            employee.Patronymic = updateEmployee.Patronymic;
            employee.Birthday = updateEmployee.Birthday;
            employee.Name = updateEmployee.Name;
            employee.Departament = updateEmployee.Departament;
            employee.Wages = updateEmployee.Wages;
            await _testWorkDbContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPost]
        [Route("{idEmployee:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int idEmployee)
        {
            var employee =
                await _testWorkDbContext.Employee.FirstOrDefaultAsync(e => e.IdEmployee == idEmployee);
            if (employee == null)
            {
                return NotFound("Сотрудника не существует");
            }

            employee.InState = false;

            await _testWorkDbContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
