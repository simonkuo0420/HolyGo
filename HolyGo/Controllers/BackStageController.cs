using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolyGo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BackStageController : Controller
    {
        // GET: BackStage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Travel()
        {
            return View();
        }
        public ActionResult Ticket()
        {
            return View();
        }
        public ActionResult Guide()
        {
            return View();
        }
    }
}