using DbFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DbFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmpContext _db;

        public HomeController(ILogger<HomeController> logger, EmpContext db)
        {
            _logger = logger;
            _db = db;   
        }

        public IActionResult Index()
        {
            List<Employee> employee = _db.Employees.ToList();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Update(int id)
        {
            if(id == null || id <= 0 ) 
            {
                return NotFound();
            }

            Employee emp = _db.Employees.FirstOrDefault(u => u.Id == id);
            if(emp == null)
            {
                return NotFound();
            }
            
            return View(emp);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Employee emp = _db.Employees.FirstOrDefault(u => u.Id == id);
            _db.Employees.Remove(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
