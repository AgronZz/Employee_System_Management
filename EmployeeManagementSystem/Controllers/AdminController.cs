using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        public ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Calendar()
        {
            
            var nonWorkingDays = _dbContext.NonWorkingDays.ToList();
            return View(nonWorkingDays);
        }

        public IActionResult AddNonWorkingDay()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNonWorkingDay(NonWorkingDay nonWorkingDay)
        {
            if (ModelState.IsValid)
            {
                _dbContext.NonWorkingDays.Add(nonWorkingDay);
                _dbContext.SaveChanges();
                return RedirectToAction("Calendar"); // Make sure 'Calendar' is the correct action name.
            }

            return View(nonWorkingDay); // This ensures the view is returned with the validation errors.
        }

        public IActionResult DeleteNonWorkingDay(int id)
        {
            var nonWorkingDay = _dbContext.NonWorkingDays.FirstOrDefault(n => n.Id == id);
            if (nonWorkingDay == null)
            {
                return NotFound();
            }

            return View(nonWorkingDay);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteNonWorkingDayConfirmed(int id)
        {
            var nonWorkingDay = _dbContext.NonWorkingDays.FirstOrDefault(n => n.Id == id);
            if (nonWorkingDay != null)
            {
                _dbContext.NonWorkingDays.Remove(nonWorkingDay);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Calendar");
        }


        public IActionResult Main(string search)
        {
            var employees = string.IsNullOrEmpty(search)
                ? _dbContext.Employees.ToList()
                : _dbContext.Employees.Where(e => (e.Name + " " + e.Surname).Contains(search) ||
                                             e.Name.Contains(search) || e.Surname.Contains(search)).ToList();

            ViewBag.Search = search;
            return View(employees);
        }


        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddEmployee(Models.EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();

                return RedirectToAction("Main");
            }

            return View(employee);
        }


        public IActionResult Update(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(t => t.Id == id);

            if(employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Models.EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _dbContext.Employees.FirstOrDefault(t => t.Id == employee.Id);

                if(existingEmployee == null)
                {
                    return NotFound();
                }


                existingEmployee.Name = employee.Name;
                existingEmployee.Surname = employee.Surname;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.ContractSigned = employee.ContractSigned;
                existingEmployee.ContractExpired = employee.ContractExpired;
                existingEmployee.isActive = employee.isActive;

                _dbContext.SaveChanges();

                return RedirectToAction("Main");

            }

            return View(employee);
        }



        public IActionResult Delete(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(t => t.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(t => t.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();


            return RedirectToAction("Main");

        }
    }


   
}
