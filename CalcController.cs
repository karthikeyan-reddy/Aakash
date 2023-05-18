using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.ContentModel;

namespace SampleMVCApp.Controllers
{
    public class CalcController : Controller
    {
        private void getItems()
        {
            var options = new List<SelectListItem>();
            options.Add(new SelectListItem { Text = "Plus" });
            options.Add(new SelectListItem { Text = "Minus" });
            options.Add(new SelectListItem { Text = "Multiply" });
            options.Add(new SelectListItem { Text = "Divide" });
            ViewBag.CalcOptions = options;
        }

        private void tempData()
        {
            var options = new string[]
                {
                    "Plus","Minus","Multiply","Divide"
                };
            TempData["Options"] = options;
        }


        public IActionResult Index()
        {
            tempData();
            TempData.Keep();
            //getItems();
            return View();
        }



        public IActionResult Calculate(IFormCollection controls)
        {
            if (controls != null)
            {
                var firstValue = double.Parse(controls["txtFirstValue"]);
                var SecodValue = double.Parse(controls["txtSecondValue"]);
                var options = controls["Options"];
                var result = 0.0;
                switch (options)
                {
                    case "Plus": result = firstValue + SecodValue; break;
                    case "Minus": result = firstValue + SecodValue; break;
                    case "Multiply": result = firstValue + SecodValue; break;
                    case "Divide": result = firstValue + SecodValue; break;
                    default:
                        break;
                }
                //Send the data to the view
                ViewData["Result"] = result;
            }
            TempData.Keep("options");
            //getItems();
            return View("Index");
        }
    }
}
