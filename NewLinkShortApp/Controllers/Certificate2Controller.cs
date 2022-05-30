using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLinkShortApp.Controllers
{
    public class Certificate2Controller : Controller
    {
        Context c = new Context();
        // GET: Certificate2
        public ActionResult Index()
        {
            return View();
        }

        private string CertificatePath(string fileName)
        {
            //string path = System.AppContext.BaseDirectory;
            //string path2 = AppDomain.CurrentDomain.BaseDirectory;
            //string path3 = Directory.GetCurrentDirectory();
            //string path4 = Environment.CurrentDirectory;
            //string path5 = this.GetType().Assembly.Location;
            var pat = AppDomain.CurrentDomain.RelativeSearchPath;
            pat = Path.Combine(pat, "Certificates", fileName);

            return pat;
        }
        public ActionResult NewCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCertificate(int id,Certificate p)
        {
            

            var templatePath = c.Templates.Where(x => x.Id == id).Select(y => y.FilePath).FirstOrDefault();

            string fileName = templatePath;

            string text = System.IO.File.ReadAllText(fileName);

            text = text.Replace("{Text1}", p.Name);
            text = text.Replace("{Text2}", p.Surname);
            text = text.Replace("{Text3}", p.Tarih.ToString("s"));

            var certicateName = CertificatePath(DateTime.Now.ToString("ddMMyyyyHHmmss" ) +p.CertificateName+".svg");


            System.IO.File.WriteAllText(certicateName, text);

            NewCertificate certi = new NewCertificate();

            certi.Name = p.CertificateName;
            certi.FilePath = certicateName;
            certi.Code = CertificateCode();
            certi.TemplateId = id;
            c.NewCertificates.Add(certi);
            c.SaveChanges();

            return RedirectToAction("ShowCertificate", "Certificate2", new { certificatePath = certicateName });
        }
        public ActionResult ShowCertificate(string path)
        {
            ViewBag.a = path;
            return View();
        }
        public string CertificateCode()
        {
            Random random = new Random();

            int s1, s2, s3;

            s1 = random.Next(0, 9);
            s2 = random.Next(0, 9);
            s3 = random.Next(0, 9);

            string kod = "S-" + s1.ToString() + s2.ToString() + s3.ToString();
            return kod;

        }
    }
}