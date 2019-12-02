using HolyGo.Models;
using HolyGo.Repository;
using Microsoft.AspNet.Identity;
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
            var getTravelCombo = _tr.SelectCombo(Guid);
            ViewBag.getTravel = getTravel;
            ViewBag.getTravelCombo = getTravelCombo;
            return View();
        }

        [HttpPost]
        public void AddToCart(Guid tGuid)
        {
            Guid fGuid = Guid.NewGuid();
            var user_id = User.Identity.GetUserId();
            if (Request.IsAuthenticated)
            {
                _tr.AddCart(fGuid, user_id, tGuid);
            }
        }
    }
}