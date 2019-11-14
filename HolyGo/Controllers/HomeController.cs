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

namespace HolyGo.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            HomeRepository Home = new HomeRepository();
            var Travel = Home.topTravel().ToList().Take(8);
            return View(Travel);
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