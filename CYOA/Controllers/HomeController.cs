using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYOA.Controllers
{
    public class HomeController : Controller
    {
        private static string[] _shows = {"parks and recreation", "seinfeld", "south park", "breaking bad", "archer", "the office", "30 rock", "silicon valley", "entourage", "game of thrones", "true detective"};

        public ActionResult Index()
        {
            Session["path"] = new List<string>() {"Woke Up"};
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
             return View();
        }
        public ActionResult FamilyRoom()
        {
            InputSessionPath("Watched Always Sunny");
            return View();
        }
        public ActionResult PhoneCall()
        {
            InputSessionPath("Answered Phone");
            return View();
        }

        public ActionResult Kitchen()
        {
            InputSessionPath("Decided to fight Granny");
            return View();
        }

        public ActionResult WheresWaldo()
        {
            InputSessionPath("Decided to Run");
            return View();
        }

        [HttpPost, ActionName("CheckShow")]
        public ActionResult CheckShow(string ans)
        {
            foreach (var s in _shows)
            {
                if (ans.ToLower() == s)
                {
                    return View("/Views/Home/FamilyRoom.cshtml");
                }
            }
            return View("/Views/Dead/AlwaysSunny.cshtml");
        }

        private void InputSessionPath(string location)
        {
            var pathList = new List<string>();
            pathList = Session["path"] as List<string>;
            pathList.Add(location);
        }
    }
}