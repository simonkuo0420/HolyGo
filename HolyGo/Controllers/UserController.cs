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
        [ValidateAntiForgeryToken]
        public ActionResult Index(MemberViewModel memberView)
        {
            MemberViewModel member = new MemberViewModel
            {
                LastName = memberView.LastName,
                FirstName = memberView.FirstName,
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
            var user_id = User.Identity.GetUserId();
            DateTime dateTime = DateTime.Now;
            var CurrentTime = dateTime.ToShortDateString();
            var getUsersOrder = _ur.SelectUsersOrder(user_id, CurrentTime);
            var getUsersGoOrder = _ur.SelectUsersGoOrder(user_id, CurrentTime);
            var getCancleOrder = _ur.SelectCancleOrder(user_id);
            ViewBag.getUsersOrder = getUsersOrder;
            ViewBag.getUsersGoOrder = getUsersGoOrder;
            ViewBag.getCancleOrder = getCancleOrder;
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
            var user_id = User.Identity.GetUserId();
            var getFavorite = _ur.SelectFavorite(user_id);
            ViewBag.getFavorite = getFavorite;
            return View();
        }
    }
}