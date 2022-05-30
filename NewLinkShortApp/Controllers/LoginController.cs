using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewLinkShortApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        Context c = new Context();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AppUser p)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }

            while (c.AppUsers.Any(x => x.Email == p.Email))
            {
                ViewBag.a = "Zaten Kayıtlı Olan Bir E-mail Adresi...";
                return View("Register");
            }

            p.Role = "User";
            p.CompanyId = 1;
            c.Add(p);
            c.SaveChanges();
            return RedirectToAction("UserLogin");

        }
        public ActionResult UserLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(AppUser p)
        {
            var info = c.AppUsers.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);

            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Email, false);
                Session["Email"] = info.Email.ToString();
                return RedirectToAction("Index", "Url");
            }
            ViewBag.d = "Giriş Bilgileri Hatalı...";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Home", "Url");
        }
        public PartialViewResult Partial1()
        {
            var email = User.Identity.Name;
            var name = c.AppUsers.Where(x => x.Email == email).Select(y => y.Name).FirstOrDefault();
            var surname = c.AppUsers.Where(x => x.Email == email).Select(y => y.Surname).FirstOrDefault();
            ViewBag.Name = name;
            ViewBag.Surname = surname;
            return PartialView();
        }
    }
}