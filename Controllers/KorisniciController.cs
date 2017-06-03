using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TelNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telNet.Models;
using TelNet.DAL;
using Codaxy.WkHtmlToPdf;
using EvoPdf;
using System.Web.SessionState;

namespace TelNet.Controllers
{
    [SessionState(SessionStateBehavior.ReadOnly)]
    public class KorisniciController : Controller
    {
        private TelNetContext db = new TelNetContext();

        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";
                ViewBag.Manager = "No";
                ViewBag.Employee = "No";
                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                if (isEmployeeUser())
                {
                    ViewBag.Employee = "Yes";
                }
                if (isManagerUser())
                {
                    ViewBag.Manager = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }

        public void toPDF()
        {
            /*var htmlContent = String.Format("<body>Hello world: {0}</body>",
         DateTime.Now);
            var pdfBytes = new NReco.PdfGenerator.HtmlToPdfConverter().GeneratePdfFromFile("http://localhost:58499/Korisnici/Narudzbe", null);
            Response.ContentType = "application/pdf";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AddHeader("Content-Disposition", "Inline; filename=TEST.pdf");
            Response.BinaryWrite(pdfBytes);
            Response.Flush();
            Response.End();*/
            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            
                // Select the HTML element to convert
                string htmlElementSelector = ".services";
                htmlToPdfConverter.RenderedHtmlElementSelector = htmlElementSelector;
            

            // Convert the HTML page to a PDF document in a memory buffer
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl("http://telnet20170525114130.azurewebsites.net/Korisnici/Narudzbe");

            // Send the PDF as response to browser

            // Set response content type
            Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Narudzbe.pdf; size={0}", outPdfBuffer.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            Response.BinaryWrite(outPdfBuffer);

            // End the HTTP response and stop the current page processing
            Response.End();
        }
        public void toPDFPaketi()
        {
            var htmlContent = String.Format("<body>Hello world: {0}</body>",
         DateTime.Now);
            var pdfBytes = new NReco.PdfGenerator.HtmlToPdfConverter().GeneratePdfFromFile("http://localhost:58499/Korisnici/NarudzbePaketa", null);
            Response.ContentType = "application/pdf";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AddHeader("Content-Disposition", "Inline; filename=TEST.pdf");
            Response.BinaryWrite(pdfBytes);
            Response.Flush();
            Response.End();
        }
        public ActionResult Narudzbe(string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending naziv" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByNarudzbe = sort == "Narudzbe" ? "descending narudzbe" : "Narudzbe";
            ViewBag.SortByTip = sort == "Tip" ? "descending tip" : "Tip";
            var records = db.Usluge.AsQueryable();

            switch (sort)
            {

                case "descending naziv":
                    records = records.OrderByDescending(x => x.nazivUsluge);
                    break;

                case "descending narudzbe":
                    records = records.OrderByDescending(x => x.narudzbeUsluga.Count);
                    break;

                case "Tip":
                    records = records.OrderBy(x => x.tipUsluge);
                    break;
                case "descending tip":
                    records = records.OrderByDescending(x => x.tipUsluge);
                    break;

                case "Narudzbe":
                    records = records.OrderBy(x => x.narudzbeUsluga.Count);
                    break;

                default:
                    records = records.OrderBy(x => x.nazivUsluge);
                    break;

            }
            return View(records.ToList());
        }
        public ActionResult NarudzbePDF(string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending naziv" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByNarudzbe = sort == "Narudzbe" ? "descending narudzbe" : "Narudzbe";
            ViewBag.SortByTip = sort == "Tip" ? "descending tip" : "Tip";
            var records = db.Usluge.AsQueryable();

            switch (sort)
            {

                case "descending naziv":
                    records = records.OrderByDescending(x => x.nazivUsluge);
                    break;

                case "descending narudzbe":
                    records = records.OrderByDescending(x => x.narudzbeUsluga.Count);
                    break;

                case "Tip":
                    records = records.OrderBy(x => x.tipUsluge);
                    break;
                case "descending tip":
                    records = records.OrderByDescending(x => x.tipUsluge);
                    break;

                case "Narudzbe":
                    records = records.OrderBy(x => x.narudzbeUsluga.Count);
                    break;

                default:
                    records = records.OrderBy(x => x.nazivUsluge);
                    break;

            }
            return View(records.ToList());
        }
        public ActionResult NarudzbePaketa(string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending naziv" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByNarudzbe = sort == "Narudzbe" ? "descending narudzbe" : "Narudzbe";
           var records = db.Paketi.AsQueryable();

            switch (sort)
            {

                case "descending naziv":
                    records = records.OrderByDescending(x => x.nazivPaketa);
                    break;

                case "descending narudzbe":
                    records = records.OrderByDescending(x => x.narudzbePaketa.Count);
                    break;

              

                case "Narudzbe":
                    records = records.OrderBy(x => x.narudzbePaketa.Count);
                    break;

                default:
                    records = records.OrderBy(x => x.nazivPaketa);
                    break;

            }
            return View(records.ToList());
        }
        public ActionResult NarudzbePaketaPDF(string sort)
        {

            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending naziv" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByNarudzbe = sort == "Narudzbe" ? "descending narudzbe" : "Narudzbe";
            var records = db.Paketi.AsQueryable();

            switch (sort)
            {

                case "descending naziv":
                    records = records.OrderByDescending(x => x.nazivPaketa);
                    break;

                case "descending narudzbe":
                    records = records.OrderByDescending(x => x.narudzbePaketa.Count);
                    break;



                case "Narudzbe":
                    records = records.OrderBy(x => x.narudzbePaketa.Count);
                    break;

                default:
                    records = records.OrderBy(x => x.nazivPaketa);
                    break;

            }
            return View(records.ToList());
        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s.Count > 0 && s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public Boolean isEmployeeUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s.Count > 0 && s[0].ToString() == "Employee")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public Boolean isManagerUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s.Count > 0 && s[0].ToString() == "Manager")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    } }