using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolyGo.Repository;

namespace HolyGo.Controllers
{
    public class TravelListController : Controller
    {
        public readonly TravelListRepository _tr;

        public TravelListController()
        {
            _tr = new TravelListRepository();
        }

        // GET: TravelList
        public ActionResult Index(string id)
        {
            var getTravelData = _tr.QuerySelectTravel(id);
            return View(getTravelData);
        }

    }
}