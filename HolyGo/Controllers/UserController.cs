using HolyGo.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolyGo.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public readonly UserRepository _hr;
        public ApplicationUserManager _userManager;

        public UserController()
        {
            _hr = new UserRepository();
        }

       [Authorize]
        public ActionResult Index()
        {
            var user_id = User.Identity.GetUserId();
            var getUserData = _hr.SelectUsers(user_id);
            ViewData["getUserData"] = getUserData;
            return View();
        }

        [Authorize]
        public ActionResult Order()
        {
            return View();
        }

        [Authorize]
        public ActionResult Message()
        {
            return View();
        }

        [Authorize]
        public ActionResult Favorite()
        {
            return View();
        }
    }
}