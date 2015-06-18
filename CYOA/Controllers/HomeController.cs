using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PathsTakenManager;
using PathsTakenRepo = PathsTakenRepo.PathsTakenRepo;

namespace CYOA.Controllers
{
    public class HomeController : Controller
    {
        private PathsTaken _paths;

        public HomeController(PathsTaken path)
        {
            _paths = path;
        }
        public ActionResult Index()
        {
            Session["path"] = new List<string>() {"Woke Up"};
            if (Session["Id"] == null)
            {
                Session["Id"] = 0;
            }
            else
            {
                Session["Id"] = (int?)Session["Id"] + 1;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FamilyRoom()
        {
            ViewBag.Message = "You have entered the family room.";
            InputSessionPath("Watched Always Sunny");
            return View();
        }
        public ActionResult PhoneCall()
        {
            ViewBag.Message = "You answered your phone.";
            InputSessionPath("Answered Phone");
            return View();
        }

        public ActionResult Kitchen()
        {
            ViewBag.Message = "You have entered the kitchen.";
            InputSessionPath("Decided to fight Granny");
            return View();
        }

        private void InputSessionPath(string location)
        {
            var pathList = new List<string>();
            pathList = Session["path"] as List<string>;
            pathList.Add(location);
        }
    }
}