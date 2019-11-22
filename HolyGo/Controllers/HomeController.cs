using Dapper;
using HolyGo.Repository;
using HolyGo.ViewModels;
using Microsoft.AspNet.Identity;
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

        [AllowAnonymous]
        public ActionResult Index()
        {
            //HomeRepository Home = new HomeRepository();
            //var Travel = Home.topTravel().ToString();
            //var Ticket = Home.topTicket().ToString();
            //return View(Travel , Ticket);
            var getTravelData = _hr.topTravel();
            var getTicketData = _hr.topTicket();
            //ViewData["key"] = model物件
            //ViewBag.model = model物件
            ViewData["topTravelData"] = getTravelData;
            ViewData["topTicketData"] = getTicketData;
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}