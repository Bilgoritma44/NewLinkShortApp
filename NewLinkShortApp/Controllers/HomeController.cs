using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLinkShortApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RedirectLink()
        {
            using (Context context = new Context())
            {
                string url = Request["aspxerrorpath"]?.Replace("/", "");
                if(string.IsNullOrEmpty(url))
                {
                     return RedirectToAction("Index", "Url");
                }
                string longUrl = context.Links.Where(x => x.Code == url).Select(s => s.LongUrl).FirstOrDefault();
                if (string.IsNullOrEmpty(longUrl))
                {
                    return RedirectToAction("Index", "Url");
                }
                return RedirectPermanent(longUrl);
            }

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