using HolyGo.Models;
using HolyGo.Repository;
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
        public readonly BackStageRepository _br;

        public BackStageController()
        {
            _br = new BackStageRepository();
        }

        // GET: BackStage
        public ActionResult Index()
        {
            ViewBag.UserData = _br.QueryGetUserData();
            var getUserData = _br.QueryGetUserData();
            return View(getUserData);
        }
        public ActionResult Travel(string result)
        {
            var SelectTravel = _br.SelectTravel();
            ViewBag.SelectTravel = SelectTravel;
            ViewBag.CreateTravel = result;
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

        public ActionResult Travel_Combo(Guid Guid)
        {
            var SelectTravelCombo = _br.SelectTravelCombo(Guid);
            ViewBag.SelectTravelCombo = SelectTravelCombo;
            ViewBag.tGuid = Guid;
            return View();
        }

        public ActionResult CreateTravel(Travel travel)
        {
            Guid Guid = Guid.NewGuid();
            var result = _br.CreateTravel(travel, Guid);
            return RedirectToAction("Travel", new { result = result });
        }

        public ActionResult CreateTravelCombo(string tGuid, string title, string content, string cost)
        {
            Guid tcGuid = Guid.NewGuid();
            _br.CreateTravelCombo(tcGuid, tGuid, title, content, cost);
            return RedirectToAction("Travel_Combo");
        }
    }
}