using NewLinkShortApp.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLinkShortApp.Controllers
{
    public class UrlController : Controller
    {
        Context c = new Context();

        [AllowAnonymous]
        public ActionResult Home()
        {
            var userid = 4;

            var lastRecordId = c.Links.Where(x => x.AppUserId == userid).OrderByDescending(y => y.Id).Take(1).Select(m=>m.Id).FirstOrDefault();

            ViewBag.d = lastRecordId;

            var deger = c.Links.Where(x => x.AppUserId == userid).OrderByDescending(y => y.Id).Take(3).ToList();

            return View(deger);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Home(Link p)
        {
            var deger = c.Links.Where(x => x.AppUserId == 1).OrderByDescending(y => y.Id).Take(3).ToList();

            if (!ModelState.IsValid)
            {
                ViewBag.a = "Geçersiz Bir Link...";
                return View(deger);
            }

            if (p.LongUrl.Length < 31)
            {
                ViewBag.a = "Girmiş Olduğunuz Uzun Link Kısa Link'ten Kısa Olamaz.";
                return View(deger);
            }

            string kod = RandomCode();

            while (c.Links.Any(x => x.Code == kod))
            {
                kod = RandomCode();
            }

            p.ShortUrl = "https://localhost:44367/" + kod;
            p.Code = kod;
            p.AppUserId = 4;
            c.Add(p);
            c.SaveChanges();
            return RedirectToAction("Home");
        }
        public ActionResult Index()
        {
            var usermail = User.Identity.Name;
            var userid = c.AppUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            var lastRecordId = c.Links.Where(x => x.AppUserId == userid).OrderByDescending(y => y.Id).Take(1).Select(m => m.Id).FirstOrDefault();
            ViewBag.d = lastRecordId;

            var deger = c.Links.Where(x=>x.AppUserId==userid).OrderByDescending(x=>x.Id).ToList();
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index(Link p)
        {
            var usermail = User.Identity.Name;
            var userid = c.AppUsers.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            var deger = c.Links.Where(x => x.AppUserId == userid).OrderByDescending(x => x.Id).ToList();

            if (!ModelState.IsValid)
            {
                ViewBag.a = "Geçersiz Bir Link...";
                return View(deger);
            }

            if(p.LongUrl.Length < 31)
            {
                ViewBag.a = "Girmiş Olduğunuz Uzun Link Kısa Link'ten Kısa Olamaz.";
                return View(deger);
            }

            while(c.Links.Where(x=>x.AppUserId==userid).Any(x=>x.LongUrl==p.LongUrl))
            {
                ViewBag.a = "Kısaltmış Olduğunuz Uzun Linki Silmeden Tekrar Kısaltamazsınız..";
                return View(deger);
            }

            string kod = RandomCode();

            while(c.Links.Any(x=>x.Code==kod))
            {
                kod = RandomCode();
            }
            
            p.ShortUrl = "https://localhost:44367/" + kod;
            p.Code = kod;
            p.AppUserId = userid;
            c.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult QRCode()
        {
            return View();

        }

        [HttpPost]
        public ActionResult QRCode(int id)
        {
            var deger = c.Links.Where(x => x.Id == id).Select(s => s.ShortUrl).FirstOrDefault();
            ViewBag.d = deger;

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(deger, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();

        }
        public string RandomCode()
        {
            Random random = new Random();
            string[] karakter = { "A", "B", "C", "D" };
            int k1, k2, k3, s1, s2, s3;

            k1 = random.Next(0, 4);
            k2 = random.Next(0, 4);
            k3 = random.Next(0, 4);
            s1 = random.Next(0, 9);
            s2 = random.Next(0, 9);
            s3 = random.Next(0, 9);

            string kod = s1.ToString() + karakter[k1] + s2.ToString() + karakter[k2] + s3.ToString() + karakter[k3];

            return kod;
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var link = c.Links.Find(id);
            if(link!=null)
            {
                c.Links.Remove(link);
                c.SaveChanges();
                return Json(new { result = true });
            }
            return Json(new { result = false });

        }



    }
}