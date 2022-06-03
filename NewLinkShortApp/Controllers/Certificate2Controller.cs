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
            string path = System.AppContext.BaseDirectory;

            //string path2 = AppDomain.CurrentDomain.BaseDirectory;
            //string path3 = Directory.GetCurrentDirectory();
            //string path4 = Environment.CurrentDirectory;
            //string path5 = this.GetType().Assembly.Location;
            //var path = AppDomain.CurrentDomain.RelativeSearchPath;
            //var path = @"C:\Users\erkan.caliskan\source\repos\NewLinkShortApp\NewLinkShortApp\";
            //var path = @"C:\Users\erkan.caliskan\source\repos\NewLinkShortApp\NewLinkShortApp\";
            path = Path.Combine(path, "Certificates", fileName);

            return path;
        }
        public ActionResult NewCertificate(int id)
        {
            var fieldValue = c.FieldValues.Where(x => x.TemplateId == id).ToList();
            int sayac = 1;
            
            foreach (var x in fieldValue)
            {
                x.Text_1 = "Text_"+sayac;
                sayac++;
            }

            return View(fieldValue);

        }
        [HttpPost]
        public ActionResult NewCertificate(int id,FieldValue p)
        {
            var email = User.Identity.Name;
            var userid = c.AppUsers.Where(x => x.Email == email).Select(y => y.Id).FirstOrDefault();

            var fieldValue = c.FieldValues.Where(x => x.TemplateId == id).ToList();

            var templatePath = c.Templates.Where(x => x.Id == id).Select(y => y.FilePath).FirstOrDefault();

            string fileName = templatePath;

            string text = System.IO.File.ReadAllText(fileName);
            int sayac = 1;
            //foreach (var x in fieldValue)
            //{
            //    x.Text_1 = "Text_" + sayac;

            //    //var deger = Convert.ToString("Text_"+ sayac);

            //    var input = "{Text" + sayac + "}";
            //    text = text.Replace(input, p.Text_1);
            //    sayac++;
            //}
           
            if (p.Text_1 == null)
            {
                p.Text_1 = "";
            }
            text = text.Replace("{Text1}", p.Text_1);
            if(p.Text_2==null)
            {
                p.Text_2 = "";
            }
            text = text.Replace("{Text2}", p.Text_2);
            if(p.Text_3==null)
            {
                p.Text_3 = "";
            }
            text = text.Replace("{Text3}", p.Text_3);
            if(p.Text_4==null)
            {
                p.Text_4 = "";
            }
            text = text.Replace("{Text4}", p.Text_4);
            if(p.Text_5==null)
            {
                p.Text_5 = "";
            }
            text = text.Replace("{Text4}", p.Text_5);

            var certicateName = CertificatePath(DateTime.Now.ToString("ddMMyyyyHHmmss" ) /*+p.CertificateName*/+".svg");


            System.IO.File.WriteAllText(certicateName, text);

            NewCertificate certi = new NewCertificate();

            //certi.Name = p.CertificateName;
            certi.FilePath = certicateName;

            string[] shortFilePath = certicateName.Split('\\');
            string databasePath="../"+shortFilePath[7]+"/"+shortFilePath[8];
            certi.FilePath2= databasePath;
            certi.Code = CertificateCode();
            certi.TemplateId = id;
            certi.AppUserId = userid;
            c.NewCertificates.Add(certi);
            c.SaveChanges();

            return RedirectToAction("ShowCertificate", "Certificate2", new { certificatePath = databasePath });
        }
        public ActionResult ShowCertificate(string certificatePath)
        {
            ViewBag.a = certificatePath;

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
        public ActionResult Detail(int id)
        {
            var deger = c.NewCertificates.Where(x => x.Id == id).Select(y => y.FilePath).FirstOrDefault();

            ViewBag.path = deger;

            return View();
        }
        
    }
}