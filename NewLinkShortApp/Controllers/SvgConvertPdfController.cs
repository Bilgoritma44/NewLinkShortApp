using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using NewLinkShortApp.Models;

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
        [HttpPost]
        public ActionResult Index(Certificate p)
        {

            string fileName = @"C:\Users\erkan.caliskan\source\repos\NewLinkShortApp\NewLinkShortApp\Text\certificate.txt";
            
            //string text = File.ReadAllText(fileName);
            
            //text = text.Replace("some text", p.Name);
            //text = text.Replace("some text", p.Surname);
            //text = text.Replace("some text", p.Tarih.ToLongDateString());
            
            //File.WriteAllText(fileName, text);


            //string text = "";

            //using (StreamReader streamReader = new StreamReader(fileName, Encoding.ASCII, true))
            //{
            //    text = File.ReadAllText(fileName);
            //    Console.WriteLine(text);
            //}



            return RedirectToAction("SvgPdf", "SvgConvertPdf");
        }
        public ActionResult SvgPdf()
        {
            return View();
        }

        public void FindAndReplace()
        {

        }
    }
}