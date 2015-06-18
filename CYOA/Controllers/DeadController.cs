using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PathsTakenManager;

namespace CYOA.Controllers
{
    public class DeadController : Controller
    {
        private PathsTaken _paths;
        public DeadController(PathsTaken path)
        {
            _paths = path;
        }

        // GET: Dead
        public ActionResult AlwaysSunny()
        {
            InputSessionPath("Died by:  Not Watching Always Sunny");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }

        public ActionResult Hide()
        {
            InputSessionPath("Died by:  Hiding");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }

        public ActionResult IgnoreWarning()
        {
            InputSessionPath("Died by:  Ignoring the Granny");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult Kryptonite()
        {
            InputSessionPath("Died by:  Choosing Kryptonite");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult Katana()
        {
            InputSessionPath("Died by:  Choosing Katana");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult MikeTyson()
        {
            InputSessionPath("Died by:  Choosing Mike Tyson");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult DontShoot()
        {
            InputSessionPath("Died by:  Not Shooting your AK");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult PowerOnCom()
        {
            InputSessionPath("Died by:  Turning on your Computer");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult ComShield()
        {
            InputSessionPath("Died by:  Using your Computer as a shield");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult Dragon()
        {
            InputSessionPath("Died by:  Dragon's Fire");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult Walk()
        {
            InputSessionPath("Died by:  Walking down driveway");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult Unicycle()
        {
            InputSessionPath("Died by:  Trying to Unicycle");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult TooLong()
        {
            InputSessionPath("Died by:  Took Too Long to Choose Answer");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
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