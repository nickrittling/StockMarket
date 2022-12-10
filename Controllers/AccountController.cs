using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< Updated upstream
=======
using System.Web.Security;
using Stock_Market.Models;
>>>>>>> Stashed changes

namespace Stock_Market.Controllers
{
    public class AccountController : Controller
    {
<<<<<<< Updated upstream
=======
        MarketEntities entity = new MarketEntities();
>>>>>>> Stashed changes
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
<<<<<<< Updated upstream
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Signout()
        {
            return View();
        }
=======

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = entity.Users.Any(x => x.Email == credentials.Email && x.Password == credentials.Password);
            User u = entity.Users.FirstOrDefault(x => x.Email == credentials.Email && x.Password == x.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.FirstName, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email or Password is wrong");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User userinfo)
        {
            entity.Users.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
>>>>>>> Stashed changes
    }
}