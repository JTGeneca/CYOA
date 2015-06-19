using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYOA.Controllers
{
    public class RunController : Controller
    {
        // GET: Run
        public ActionResult Driveway()
        {
            InputSessionPath("Found Waldo");
            return View();
        }
        public ActionResult Troll()
        {
            InputSessionPath("Escape Vehicle:  Car");
            return View();
        }
        public ActionResult Superbounce()
        {
            InputSessionPath("Solved The Riddle");
            return View();
        }
        private void InputSessionPath(string location)
        {
            var pathList = new List<string>();
            pathList = Session["path"] as List<string>;
            pathList.Add(location);
        }

        [HttpPost, ActionName("CheckAns")]
        public ActionResult CheckAns(string ans)
        {
            if (ans.ToLower() == "blt")
            {
                return View("BLT");
            }
            return View("~/Views/Dead/WrongAns.cshtml");
        }
    }
}