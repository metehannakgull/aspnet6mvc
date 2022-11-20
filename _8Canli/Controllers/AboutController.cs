using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutDal());


        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial() //PARTİAL VİEW KULLANDIM
        {
            return PartialView();
        }
    }
}