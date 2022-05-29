using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace NewLinkShortApp.Controllers
{
    [AllowAnonymous]
    public class EmailController : Controller
    {
        Context c = new Context();
        // GET: Email
        public ActionResult SendPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendPassword(AppUser p)
        {
            var password = c.AppUsers.Where(x => x.Email == p.Email).Select(y => y.Password).FirstOrDefault();
            var name = c.AppUsers.Where(x => x.Email == p.Email).Select(y => y.Name).FirstOrDefault();
            var surname = c.AppUsers.Where(x => x.Email == p.Email).Select(y => y.Surname).FirstOrDefault();

            SmtpClient smtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();

            var tarih = DateTime.Now.ToLongDateString();
            var message = "Sayın " + name + " " + surname + " Bizden " + tarih + " tarihinde Şifremi Unuttum Talebinde Bulundunuz." + "\n" + "Parolanız: " + password + " \nİyi Günler...";
            var smtpMail = "sistem@indata.com.tr";
            var smtpPass = "Ind2019!*";

            smtpServer.Credentials = new NetworkCredential(smtpMail, smtpPass);

            smtpServer.Port = 587;
            smtpServer.Host = "smtp.office365.com";
            smtpServer.EnableSsl = true;

            mail.From = new MailAddress(smtpMail);
            mail.To.Add(p.Email);
            mail.Subject = "Şifre Hatırlatması Hakkında";
            mail.Body = message;

            smtpServer.Send(mail);



            return RedirectToAction("UserLogin", "Login");
        }
    }
}