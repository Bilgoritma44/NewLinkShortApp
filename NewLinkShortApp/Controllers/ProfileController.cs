using Microsoft.EntityFrameworkCore;
using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewLinkShortApp.Controllers
{
    public class ProfileController : Controller
    {
        Context db = new Context();
        // GET: Profile
        public ActionResult UpdateProfile()
        {
            var email = User.Identity.Name;
            var userid = db.AppUsers.Where(x => x.Email == email).Select(y => y.Id).FirstOrDefault();
            var deger = db.AppUsers.Find(userid);

            return View(deger);
        }
        [HttpPost]
        public ActionResult UpdateProfile(AppUser p)
        {
            var deger = db.AppUsers.Find(p.Id);

            var deger2 = deger.Email;

            deger.Name = p.Name;
            deger.Surname = p.Surname;
            deger.Email = p.Email;
            db.SaveChanges();

            if (deger2 != p.Email)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Index", "Url");
            }

            return RedirectToAction("Index", "Url");
        }
        public ActionResult PasswordChange()
        {
            var email = User.Identity.Name;
            var userid = db.AppUsers.Where(x => x.Email == email).Select(y => y.Id).FirstOrDefault();
            var deger = db.AppUsers.Find(userid);

            return View(deger);
        }
        [HttpPost]
        public ActionResult PasswordChange(AppUser p)
        {
            var deger = db.AppUsers.Find(p.Id);

            deger.Password = p.Password;
            db.SaveChanges();

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Url");

        }
        public ActionResult MyCertificate()
        {
            var useremail = User.Identity.Name;
            var userid= db.AppUsers.Where(x=>x.Email==useremail).Select(y=>y.Id).FirstOrDefault();

            var deger = db.NewCertificates.Where(x => x.AppUserId == userid).Include(y=>y.Template).ToList();

            return View(deger);
        }
        [HttpPost]
        public ActionResult MyCertificate(string kod)
        {
            var certificate = db.NewCertificates.ToList();


            foreach (var b in certificate)
            {

                if (b.Code == kod)
                {
                    var deger = db.NewCertificates.Where(x => x.Code == kod).Include(y => y.Template).ToList();
                    return View(deger);
                }
            }

            ViewBag.a = "Aramış Olduğunuz Sertifika Bulunamamaktadır. Lüften Tekrar Deneyiniz.";

            var useremail = User.Identity.Name;
            var userid = db.AppUsers.Where(x => x.Email == useremail).Select(y => y.Id).FirstOrDefault();
            var deger2 = db.NewCertificates.Where(x => x.AppUserId == userid).Include(y => y.Template).ToList();

            return View(deger2);
        }
        public ActionResult ShowCert(int id)
        {
            var deger = db.NewCertificates.Where(x => x.Id == id).Select(y => y.FilePath2).FirstOrDefault();

            return View(deger);
        }
    }
}
