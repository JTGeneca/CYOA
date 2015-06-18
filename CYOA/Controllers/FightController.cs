using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYOA.Controllers
{
    public class FightController : Controller
    {
        // GET: Fight
        public ActionResult AK47()
        {
            InputSessionPath("Weapon of Choice:  AK47");
            return View();
        }
        public ActionResult Computer()
        {
            InputSessionPath("Weapon of Choice:  Computer");
            return View();
        }

        public ActionResult MikeTyson()
        {
            InputSessionPath("Weapon of Choice:  Mike Tyson");
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