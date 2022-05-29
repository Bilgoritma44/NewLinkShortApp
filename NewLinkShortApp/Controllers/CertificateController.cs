using Aspose.Words;
using NewLinkShortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using Document = Aspose.Words.Document;
using PdfImage = Syncfusion.Pdf.Graphics.PdfImage;
using Word = Microsoft.Office.Interop.Word;

namespace NewLinkShortApp.Controllers
{
    [AllowAnonymous]
    public class CertificateController : Controller
    {
        // GET: Certificate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCertificate(Certificate p)

        {

            //Find and Replace Method
            void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
            {
                object matchCase = true;
                object matchWholeWord = true;
                object matchWildCards = false;
                object matchSoundLike = false;
                object nmatchAllforms = false;
                object forward = true;
                object format = false;
                object matchKashida = false;
                object matchDiactitics = false;
                object matchAlefHamza = false;
                object matchControl = false;
                object read_only = false;
                object visible = true;
                object replace = 2;
                object wrap = 1;

                wordApp.Selection.Find.Execute(ref ToFindText,
                    ref matchCase, ref matchWholeWord,
                    ref matchWildCards, ref matchSoundLike,
                    ref nmatchAllforms, ref forward,
                    ref wrap, ref format, ref replaceWithText,
                    ref replace, ref matchKashida,
                    ref matchDiactitics, ref matchAlefHamza,
                    ref matchControl);
            }

            //Creeate the Doc Method
            void CreateWordDocument(object filename, object SaveAs)
            {
                Word.Application wordApp = new Word.Application();
                object missing = Missing.Value;
                Word.Document myWordDoc = null;

                if (System.IO.File.Exists((string)filename))
                {
                    object readOnly = true;
                    object isVisible = true;
                    wordApp.Visible = true;

                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);
                    myWordDoc.Activate();

                    //find and replace
                    FindAndReplace(wordApp, "<name>", p.Name);
                    FindAndReplace(wordApp, "<firstname>", p.Surname);
                    FindAndReplace(wordApp, "<birthday>", p.Tarih.ToShortDateString());
                    FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());
                }
                else
                {
                    MessageBox.Show("File not Found!");
                }

                //Save as
                myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);



                myWordDoc.Close();
                wordApp.Quit();
                //  MessageBox.Show("File Created!");
            }



            CreateWordDocument(@"C:\Users\erkan.caliskan\source\repos\Deneme\Deneme\word\temp.docx", @"C:\Users\erkan.caliskan\source\repos\Deneme\Deneme\word\new.docx");

            Document doc = new Document(@"C:\Users\erkan.caliskan\source\repos\Deneme\Deneme\word\new.docx");
            doc.Save(@"C:\Users\erkan.caliskan\source\repos\Deneme\Deneme\Photo\s4.jpg", SaveFormat.Png);



            return RedirectToAction("WordImage", "Certificate");
        }

        public ActionResult WordImage()
        {
            return View();
        }


    }
}