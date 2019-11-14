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
            //ViewData["key"] = model物件
            //ViewBag.model = model物件
            ViewData["topTravelData"] = _hr.topTravel();

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
    }
}