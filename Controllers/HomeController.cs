using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032_Task2.Models;
using FIT5032_Task2.Utils;


namespace FIT5032_Task2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model, HttpPostedFileBase
postedFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    ModelState.Clear();
                    var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
                    var imageFilePath = myUniqueFileName;
                    string serverPath = Server.MapPath("~/Uploads/");
                        string fileExtension = Path.GetExtension(postedFile.FileName);
                        string filePath = imageFilePath + fileExtension;
                    imageFilePath = filePath;
                        postedFile.SaveAs(serverPath + imageFilePath);
                     
                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents, imageFilePath);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}