using BasicExpenseTracker.Data;
using BasicExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using BasicExpenseTracker.Data;
using BasicExpenseTracker.Models;
using System.Linq;

namespace BasicExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();

            // Calculate total spent to show on dashboard
            ViewBag.TotalSpent = expenses.Sum(e => e.Amount);

            return View(expenses);
        }

        // GET: Expenses/Create (Show the form)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create (Save form data to SSMS)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges(); // Saves changes directly to database
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}