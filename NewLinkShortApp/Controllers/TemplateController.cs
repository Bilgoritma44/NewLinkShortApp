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
        Context c = new Context();
        // GET: Template
        public ActionResult Index()
        {
            var usermail = User.Identity.Name;
            var companyid = c.AppUsers.Where(x => x.Email == usermail).Select(y => y.CompanyId).FirstOrDefault();

            var templateList = c.Templates.Where(x => x.CompanyId == companyid).ToList();

            foreach (var x in templateList)
            {


                var fieldCount = c.FieldValues.Where(y => y.TemplateId == x.Id).Count();

                x.FieldCount=fieldCount;

            }
                Class2 cs = new Class2();
                

                cs.Deger1 = c.Templates.Where(x => x.CompanyId == companyid).ToList();

                cs.Deger2 = c.FieldValues.ToList();

                return View(cs);
            
        }
        public ActionResult FieldAction()
        {
            return RedirectToAction("Add","FieldValue");
        }
        public ActionResult TemplateField(int id)
        {
            var deger = c.FieldValues.Where(x => x.TemplateId == id).ToList();

            return View(deger);
        }
    }
}