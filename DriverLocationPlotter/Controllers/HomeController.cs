using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DriverLocationPlotter.Models;

namespace DriverLocationPlotter.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("ShowRoute");

        }

     
        public ActionResult Drivers()
        {
            return View();

        }

        [Authorize]
        public ActionResult ShowRoute()
        {
            GetAccidentLocation objLocation = new GetAccidentLocation();
            Location Location = objLocation.Get();
            if (Location.Latitude == "NIL" || Location.Longitude == "NIL")
            {
                return View("Index");
            }
            else
            {
                TempData["Location"] = Location.Address;
                TempData["Latitude"] = Location.Latitude;
                TempData["Longitude"] = Location.Longitude;
                return RedirectToAction("Map");
            }
            
        }


        [Authorize]
 
        public ActionResult Map()
        {


            //GetAccidentLocation objLocation = new GetAccidentLocation();
            //string Location = objLocation.Get();

            if (TempData["Location"] == "NIL")
            {
                return RedirectToAction("ShowRoute");
            }
            else
            {
                try
                {
                    ViewBag.Loc = TempData["Location"].ToString();
                    ViewBag.Latitude = TempData["Latitude"].ToString();
                    ViewBag.Longitude = TempData["Longitude"].ToString();
                    return View();
                }
                catch
                {
                    return RedirectToAction("ShowRoute");
                }
               
            }
        
          
        }


        public string ReportAccidentByLoc(string AccLoc)
        {

            GetAccidentLocation objLocation = new GetAccidentLocation();
            string Response = objLocation.ReportAccident(AccLoc);
            return Response;
         }

        public string ReportAccident(string lat,string log)
        {
         
            GetAccidentLocation objLocation = new GetAccidentLocation();
            string Response = objLocation.ReportAccident(log, lat);
            return Response;
        }
    }
}