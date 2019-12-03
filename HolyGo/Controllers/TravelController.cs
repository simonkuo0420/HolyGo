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
            var user_id = User.Identity.GetUserId();
            var getTravel = _tr.SelectTravel(Guid);
            var getTravelCombo = _tr.SelectCombo(Guid);

            bool check = _tr.CheckFavorite(Guid, user_id);
            if (check == true)
            {
                ViewBag.Check = 1;
            }
            else
            {
                ViewBag.Check = 0;
            }
            ViewBag.getTravel = getTravel;
            ViewBag.getTravelCombo = getTravelCombo;
            return View();
        }

        public ActionResult AddToCart(Guid t_guid)
        {
            Guid guid = Guid.NewGuid();
            var user_id = User.Identity.GetUserId();
            var getTravel = _tr.SelectTravel(t_guid);
            bool check = _tr.CheckFavorite(t_guid, user_id);
            if (check == false)
            {
                _tr.AddCart(guid, user_id, t_guid);
                return RedirectToAction("Index", new {Guid = t_guid});
            }
            return RedirectToAction("Index", new { Guid = t_guid });
        }
    }
}