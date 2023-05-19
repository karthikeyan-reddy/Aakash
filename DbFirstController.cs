using Microsoft.AspNetCore.Mvc;
using SampleMVCApp.Data;
using SampleMVCApp.Models;

namespace SampleMVCApp.Controllers
{
    public class DbFirstController : Controller
    {
        private readonly IDBFirstComponent component;
        public DbFirstController(IDBFirstComponent component)
        {
            this.component = component;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllEmployees()
        {
            var model = component.GetAllEmployees();
            return PartialView(model);
        }
        public IActionResult AddNew()
        {
            var model = new TblEmployee();
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AddNew(TblEmployee postedData) 
        {
            component.AddNewEmployee(postedData);
            return RedirectToAction("Index");
        }
    }
}
