using HolyGo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolyGo.Controllers
{
    public class TravelController : Controller
    {
        public readonly TravelRepository _tr;

        public TravelController()
        {
            _tr = new TravelRepository();
        }

        // GET: Travel
        [AllowAnonymous]
        public ActionResult Index(Guid Guid)
        {
            var getTravel = _tr.SelectTravel(Guid);
            ViewBag.getTravel = getTravel;
            return View();
        }
    }
}