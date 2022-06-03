using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLinkShortApp.Controllers
{
    public class FieldValueController : Controller
    {
        Context c = new Context();
        // GET: FieldValue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var usermail = User.Identity.Name;

            var companyid = c.AppUsers.Where(x => x.Email == usermail).Select(x => x.CompanyId).FirstOrDefault();

            List<SelectListItem> template = (from x in c.Templates.Where(a=>a.CompanyId==companyid).ToList()

                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.Id.ToString()

                                              }).ToList();

            ViewBag.t = template;

            return View();
        }
        [HttpPost]
        public ActionResult Add(FieldValue p)
        {
            c.FieldValues.Add(p);
            c.SaveChanges();
            return RedirectToAction("FieldAction","Template");
        }
    }
}