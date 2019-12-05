﻿using HolyGo.Models;
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
            return View();
        }
        public ActionResult Travel(string result)
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
        public ActionResult CreateTravel(Travel travel)
        {
            Guid Guid = Guid.NewGuid();
            var result = _br.CreateTravel(travel, Guid);
            return RedirectToAction("Travel", new {result = result });
        }
    }
}