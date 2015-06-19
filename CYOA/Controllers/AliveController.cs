using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYOA.Controllers
{
    public class AliveController : Controller
    {
        private PathsTakenRepo.PathsTakenRepo _paths;
        public AliveController(PathsTakenRepo.PathsTakenRepo path)
        {
            _paths = path;
        }

        // GET: Alive
        public ActionResult ThrowCom()
        {
            InputSessionPath("Alive:  Threw computer at Granny");
            _paths.AddPath(Session["path"] as List<string>);
            return View();
        }
        public ActionResult ShootAK()
        {
            InputSessionPath("Alive:  Shot Granny with AK");
            _paths.AddPath(Session["path"] as List<string>);
            return View();
        }
        public ActionResult DriveAway()
        {
            InputSessionPath("Alive:  Drove away in your car");
            _paths.AddPath(Session["path"] as List<string>);
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