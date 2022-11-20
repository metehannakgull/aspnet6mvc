using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class SocialMediaUserPanelController : Controller
    {

        TitleManager tm = new TitleManager(new EFTitleDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        Context c = new Context();

        public ActionResult SocialMediaUserProfile()
        {
            return View();
        }
        public ActionResult MyTitle(string p)//Sosyel medya kullanıcının yazdığı yazıların başlıklarını çekmeye çalışıyorum
        {
            //Yani örneğin id'si 4 olan kullanıcının profilinde kendine ait başlıklar gelecek.
            
         
            p = (string)Session["Email"];
            var socialMediaUserIdInfo = c.SocialMediaUsers.Where(x => x.Email == p).Select(y => y.SocialMediaUserId).FirstOrDefault();
            var values = tm.GetListBySocialMediaUser(socialMediaUserIdInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewTitle()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                              ).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewTitle(Title p)
        {
            p.TitleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SocialMediaUserId = 4;
            p.TitleStatus = true;
            tm.TitleAdd(p);
            return RedirectToAction("MyTitle");
            
        }
        [HttpGet]
        public ActionResult EditTitle(int id)//Veri Güncelleme
        {
            
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                               ).ToList();

            ViewBag.vlc = valuecategory;

            var titlevalue = tm.GetByID(id);
            return View(titlevalue);
        }
        [HttpPost]
        public ActionResult EditTitle(Title p)//Veri Güncelleme
        {
            tm.TitleUpdate(p);
            return RedirectToAction("MyTitle");
        }
        public ActionResult DeleteTitle(int id)
        {
            var Titlevalue = tm.GetByID(id);
            Titlevalue.TitleStatus = false;
            tm.TitleDelete(Titlevalue);
            return RedirectToAction("MyTitle");
        }
    }
}