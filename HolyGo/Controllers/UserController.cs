using HolyGo.Repository;
using HolyGo.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HolyGo.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public readonly UserRepository _ur;

        public UserController()
        {
            _ur = new UserRepository();
        }

        [Authorize]
        public ActionResult Index()
        {
            var user_id = User.Identity.GetUserId();
            var getUserData = _ur.SelectUsers(user_id);
            return View(getUserData);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Index(MemberViewModel memberView)
        {
            MemberViewModel member = new MemberViewModel
            {
                LastName = memberView.LastName,
                FirstName = memberView.FirstName,
                Gender = memberView.Gender,
                Birthday = memberView.Birthday,
                Country = memberView.Country,
                Phone = memberView.Phone
            };
            var user_id = User.Identity.GetUserId();
            _ur.UpdateUsers(member, user_id);
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