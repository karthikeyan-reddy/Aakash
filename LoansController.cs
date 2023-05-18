using Microsoft.AspNetCore.Mvc;
using SampleMVCApp.Models;
using System.Drawing.Text;

namespace SampleMVCApp.Controllers
{
    public class LoansController : Controller
    {

        private readonly ILoanComponent component;
        public LoansController(ILoanComponent component)
        {
            this.component = component;
        }
        public ViewResult GetAll()
        {
            var model = component.GetApplications();
            return View(model);
        }
        public ViewResult eligible()
        {
            var model = component.FindAllEligibleApplications();
            return View(model);
        }
        public ViewResult OnAddNew()
        {
            var loantypes = Enum.GetValues(typeof(LoanType));
            ViewBag.Loantypes = loantypes;
            var model = new LoanApp();
            return View(model);
        }
        [HttpPost]
        public IActionResult OnAddNew(LoanApp postbackdata) 
        {
            try
            {
                component.AddNewLoanApplicant(postbackdata);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IActionResult OnEdit(int id)
        {
            var data=component.GetApplications();
            var found = data.Find(p=>p.Id == id);
            return View(found);
        }
        [HttpPost]
        public RedirectToActionResult OnEdit(LoanApp app)
        {
            try
            {
                component.UpdateLoanApplicant(app);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("GetAll");

            }
        }
    }
}
