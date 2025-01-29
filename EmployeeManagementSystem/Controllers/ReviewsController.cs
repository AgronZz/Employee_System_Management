using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.Employees = _dbContext.Employees
                .Select(e => new { Id = e.Id, FullName = e.Name + " " + e.Surname })
                .ToList();

            return View();
        }


        [HttpPost]
        public IActionResult Create(ReviewModel model)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Reviews.Add(model);
                var changes = _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }




            ViewBag.Employees = _dbContext.Employees.Select(e => new { e.Id, FullName = $"{e.Name} {e.Surname}" }).ToList();
            return View(model);
        }



        public IActionResult EmployeeReviews()
        {
            var reviews = _dbContext.Reviews
                .Include(r => r.Employee)
                .ToList();

            return View(reviews);
        }
    }
}
