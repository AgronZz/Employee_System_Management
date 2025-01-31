using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using System.Linq;
using System.Security.Claims;
using EmployeeManagementSystem.Data;


namespace EmployeeManagementSystem.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
                
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.ErrorMessage = "Only non-registered users (guests/customers) can add reviews.";
                return View();
            }
           
        
            ViewBag.Employees = _dbContext.Employees
                .Where(e => e.isActive)
                .Select(e => new { Id = e.Id, FullName = e.Name + " " + e.Surname })
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ReviewModel model)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.ErrorMessage = "Only non-registered users (guests/customers) can add reviews.";
                return View(model);
            }

            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == model.EmployeeId);

            if (employee == null || !employee.isActive)
            {
                ViewBag.ErrorMessage = "You cannot add a review for an inactive employee.";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                _dbContext.Reviews.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Employees = _dbContext.Employees
                .Where(e => e.isActive)
                .Select(e => new { e.Id, FullName = $"{e.Name} {e.Surname}" })
                .ToList();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EmployeeReviews()
        {
            var reviews = _dbContext.Reviews
                .Include(r => r.Employee)
                .ToList();

            // Calculate average rating for each employee
            var employeeRatings = reviews
                .GroupBy(r => r.EmployeeId)
                .Select(g => new
                {
                    EmployeeId = g.Key,
                    EmployeeName = g.First().Employee.Name + " " + g.First().Employee.Surname,
                    AverageRating = g.Average(r => r.Rating)
                })
                .ToList();

            ViewBag.EmployeeRatings = employeeRatings;

            return View(reviews);
        }

    }
}
