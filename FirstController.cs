using Microsoft.AspNetCore.Mvc;
using SampleMVCApp.Models;

namespace SampleMVCApp.Controllers
{
    public class FirstController : Controller
    {
        public string Helloworld() => "Hello World";

        public Employee DisplayDetails() => new Employee
        {
            Address = "NDK",
            EmpId = 123,
            EmpName = "MKR",
            Phone = 8309444929,
            salary = 40000
        };

        public ViewResult DisplayEmployee()
        {
            var model = new Employee
            {
                Address = "NDK",
                EmpId = 123,
                EmpName = "MKR",
                Phone = 8309444929,
                salary = 40000
            };
            return View(model);
        }

        public ViewResult AllEmployees()
        {
            var model = new Employee[]
            {
                 new Employee { EmpName="Sreeja" , Address="HYD" , EmpId = 2 , Phone=9283782361 , salary = 35000} ,
                 new Employee { EmpName="SatyaReddy" , Address="KNL" , EmpId = 3 , Phone=892374927 , salary = 100000},
                 new Employee {EmpName="Akshara" , Address="USA" , EmpId = 4 , Phone=891704637 , salary = 20000},
                 new Employee{EmpName="Mkreddy" , Address="BLR" , EmpId = 5 , Phone=830944939 , salary = 40000}
            };
            return View(model);
        }

    }
}

