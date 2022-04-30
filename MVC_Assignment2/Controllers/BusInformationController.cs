using MVC_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment2.Controllers
{
    public class BusInformationController : Controller
    {
        // GET: BusInformation
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get_Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post_Index() {

            BusInformation busInformation = new BusInformation();

            // Model Binding, i.e. used to get the data from form and set the values
            UpdateModel(busInformation);

            if (ModelState.IsValid)
            {
                BusInformationDetails busInformationDetails = new BusInformationDetails();
                busInformationDetails.AddBusInformation(busInformation);

                return RedirectToAction("Index");
            }
            return View();

        }
        
    }
}