using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignments_Project.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            Models.Product p = new Models.Product();

            //pass a list of products to the view
            return View(p.GetProducts());
        }
    }
}