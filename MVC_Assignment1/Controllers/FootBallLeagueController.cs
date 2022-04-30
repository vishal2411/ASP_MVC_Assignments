using MVC_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class FootBallLeagueController : Controller
    {  

        // ************* Action Method to Create form ******************//
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get_Index()
        {
            return View();
        }

        // ********** Action Method to Get Data from form ************* //

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post_Index()
        {
            try
            {
                FootBallLeague footBallLeague = new FootBallLeague();
                UpdateModel(footBallLeague);

                if (ModelState.IsValid)
                {
                    FootballLeagueDetails footballLeagueDetails = new FootballLeagueDetails();
                    footballLeagueDetails.addMatchDetails(footBallLeague);

                    return RedirectToAction("Display");
                }
            }
            catch (Exception e)
            {
                Response.Write("Something Went Wrong"+ e);
            }
            return View();
        }

        public String Display() {

            return "Details Saved Successfully";
        
        }

    }
}