using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PathsTakenManager;

namespace CYOA.Controllers
{
    public class AliveController : Controller
    {
        private PathsTaken _paths;
        public AliveController(PathsTaken path)
        {
            _paths = path;
        }

        // GET: Alive
        public ActionResult ThrowCom()
        {
            InputSessionPath("Alive:  Threw computer at Granny");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult ShootAK()
        {
            InputSessionPath("Alive:  Shot Granny with AK");
            _paths.AddPath(Session["path"] as List<string>, (int)Session["Id"]);
            return View();
        }
        public ActionResult DriveAway()
        {
            InputSessionPath("Alive:  Drove away in your car");
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