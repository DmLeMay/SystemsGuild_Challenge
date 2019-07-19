using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contract.Parent;
using Service.SaleInfoMethods;


namespace SGChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly Service.ISalesData _salesData;

        public HomeController(Service.ISalesData SalesData)
        {
            _salesData = SalesData;
        }


        [HttpGet]
        public IActionResult Index()
        {
            SalesAverageReport report = new SalesAverageReport();
            
            return View(report);
        }

        [HttpPost]
        public IActionResult Index(SalesAverageReport Model)
        {
            //Send Model data to validation methods, and set equal to result to hold any error messages
            Model =  DateValidation(Model);
            Model = ZipCodeValidation(Model);

            //If the ModelState is bad return to page without doing anything            
            if(!ModelState.IsValid)
            {
                return View("Index", Model);
            }

            Model.SalesAverageData = _salesData.GetSalesAverages(Model.UserInputs.Zipcode, Model.UserInputs.StartDate, Model.UserInputs.EndDate);

            //TODO: Add code here to take values in from the 
            return View(Model);
        }

        private SalesAverageReport ZipCodeValidation(SalesAverageReport Model)
        {
            if(Model.UserInputs.Zipcode == "" || Model.UserInputs.Zipcode == null)
            {
                ModelState.AddModelError("UserInputs.Zipcode", "The zipcode can not be empty");
            }

            return Model;
        }


        private SalesAverageReport DateValidation(SalesAverageReport Model)
        {            
            //TODO: Add Check to tell user that the End date is before start date
            if(Model.UserInputs.EndDate < Model.UserInputs.StartDate)
            {
                ModelState.AddModelError("UserInputs.EndDate", "End date must be later than start date");
            }

            //Check if the start date is is greater than the end date
            if (Model.UserInputs.StartDate > Model.UserInputs.EndDate)
            {
                ModelState.AddModelError("UserInputs.StartDate", "Start date must be earlier than end date");
            }

            //Check if the start date is a future date     
            if (Model.UserInputs.StartDate > DateTime.Now.Date)
            {
                ModelState.AddModelError("UserInputs.StartDate", "Start date can not be in the future");
            }

            //Check if the start date is a future date     
            if (Model.UserInputs.EndDate > DateTime.Now.Date)
            {
                ModelState.AddModelError("UserInputs.EndDate", "End date can not be in the future");
            }


            return Model;
        }




    }
}
