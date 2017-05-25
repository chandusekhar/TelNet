using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TelNet.ViewModels;
namespace TelNet.Controllers
{
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

        [HttpPost]
        public ActionResult Contact([Bind(Include = "ime,email,naslov,poruka")]
        MailData podaci)
        {
            podaci = new MailData();
            podaci.ime = String.Format("{0}", Request.Form["name"]);
            podaci.email = String.Format("{0}", Request.Form["email"]);
            podaci.naslov = String.Format("{0}", Request.Form["subject"]);
            podaci.poruka = String.Format("{0}", Request.Form["message"]);
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(podaci.email);
                mail.To.Add("huskic.emina@gmail.com");
                mail.Subject =podaci.naslov;
                mail.Body = podaci.poruka;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("huskic.emina@gmail.com", "Kristal1$");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
               }

           return View();
        }
       
    }
}