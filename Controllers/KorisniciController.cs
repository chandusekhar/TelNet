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

namespace TelNet.Controllers
{

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

        public ActionResult Chart()
        {
            return View();
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