using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLinkShortApp.Controllers
{
    public class TemplateController : Controller
    {
        Context c=new Context();
        // GET: Template
        public ActionResult Index()
        {
            var usermail = User.Identity.Name;
            var companyid = c.AppUsers.Where(x => x.Email == usermail).Select(y => y.CompanyId).FirstOrDefault();
            var deger = c.Templates.Where(x => x.CompanyId == companyid).ToList();

            return View(deger);
        }
    }
}