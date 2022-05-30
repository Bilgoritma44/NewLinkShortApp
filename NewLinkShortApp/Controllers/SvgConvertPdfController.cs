using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using NewLinkShortApp.Models;
using System.IO;

namespace NewLinkShortApp.Controllers
{
    [AllowAnonymous]
    public class SvgConvertPdfController : Controller
    {
        // GET: WordConvertPdf

        public ActionResult Index()
        {
            return View();
        }

        private string TemplatePath()
        {
            string path = System.AppContext.BaseDirectory;
            path=Path.Combine(path, "Templates\\deneme.svg");
            return path;
        }
        private string CertificatePath(string fileName)
        {
            string path = System.AppContext.BaseDirectory;
            //string path2 = AppDomain.CurrentDomain.BaseDirectory;
            //string path3 = Directory.GetCurrentDirectory();
            //string path4 = Environment.CurrentDirectory;
            //string path5 = this.GetType().Assembly.Location;
            //var pat = AppDomain.CurrentDomain.RelativeSearchPath;
            path =Path.Combine(path, "Certificates",fileName);
            
            return path;
        }
        [HttpPost]
        public ActionResult Index(Certificate p)
        {

            //string fileName = @"C:\Users\erkan.caliskan\source\repos\NewLinkShortApp\NewLinkShortApp\Templates\deneme.svg";
            string fileName = TemplatePath();

  

            string text = System.IO.File.ReadAllText(fileName);

            text = text.Replace("{Text1}", p.Name);
            text = text.Replace("{Text2}", p.Surname);
            text = text.Replace("{Text3}", p.Tarih.ToString("s"));

            var certicateName = CertificatePath(DateTime.Now.ToString("ddMMyyyyHHmmss") +".svg");


            System.IO.File.WriteAllText(certicateName,text);



            return RedirectToAction("SvgPdf","SvgConvertPdf", new { certificatePath = certicateName });
        }
        public ActionResult SvgPdf(string certificatePath)
        {
            ViewBag.certificate=certificatePath;

            return View();
        }
    }
}