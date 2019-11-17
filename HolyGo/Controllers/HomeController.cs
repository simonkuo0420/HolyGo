using Dapper;
using HolyGo.Repository;
using HolyGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace HolyGo.Controllers
{
    public class HomeController : Controller
    {
        public readonly HomeRepository _hr;

        public HomeController()
        {
            _hr = new HomeRepository();
        }

        public ActionResult Index()
        {
            var getTravelData = _hr.topTravel();
            var topTicketData = _hr.topTicket();
            //ViewData["key"] = model物件
            //ViewBag.model = model物件
            ViewData["topTravelData"] = _hr.topTravel();
            ViewData["topTicketData"] = _hr.topTicket();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Member()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Favorite()
        {
            return View();
        }
    }
}