using EmployeeManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize(Roles = "Employee, Admin")]
    public class EmployeeController : Controller
    {
        ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Main(string search)
        {
            var employees = string.IsNullOrEmpty(search)
                ? _dbContext.Employees.ToList()
                : _dbContext.Employees
                    .Where(e => (e.Name + " " + e.Surname).Contains(search) ||
                                e.Name.Contains(search) ||
                                e.Surname.Contains(search))
                    .ToList();

            ViewBag.Search = search;
            return View(employees);
        }


        public IActionResult Details(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(t => t.Id == id);

            if(employee == null)
            {
                return NotFound();
            }

            var totalContractPayment = (employee.ContractExpired - employee.ContractSigned).Days * employee.Salary;

            ViewBag.TotalContractPayment = totalContractPayment;

            return View(employee);
        }
    }
}
