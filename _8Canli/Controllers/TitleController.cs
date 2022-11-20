using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class TitleController : Controller
    {
        //Title tablosunu Katmanlı mimari ile çağırmak için öncelikle Business Layer'da 
        //Title Manager'ı çağırmalıyım.

        TitleManager tm = new TitleManager(new EFTitleDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());//Amacım başlık ekleme işlemi gerçekleştirirken, o başlığa ait Category listesini getirmek
        SocialMediaUserManager sm = new SocialMediaUserManager(new EFSocialMediaUserDal());
        public ActionResult Index()
        {
            var titlevalues = tm.GetList();

            return View(titlevalues);
        }
        [HttpGet]
        public ActionResult AddTitle()//veri ekleme
        {
            //Burdaki amacım başlık ekleme işlemi gerçekleştirirken, o başlığa ait Category listesini getirmek
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryId.ToString()
                                                  }
                                                ).ToList();
            //Value number: Seçmiş olduğun değerin id'si. ÖRN:CategorId. Value, value numberdır.
            //Display Number:Seçmiş olduğun değerin görünür kısmı, kendisi. ÖRN:CategoryName. Text, display number'dır.
            ViewBag.vlc = valuecategory;


            List<SelectListItem> valueSocialMediaUser =(from x in sm.GetList()
                                                        select new SelectListItem
                                                        {
                                                            Text=x.Name+" "+x.Surname,
                                                            Value=x.SocialMediaUserId.ToString()
                                                         }).ToList();

            ViewBag.vls = valueSocialMediaUser;
            return View();
        }
        [HttpPost]
        public ActionResult AddTitle(Title p)//veri ekleme
        {
            p.TitleDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            tm.TitleAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditTitle(int id)//Veri Güncelleme
        {
            //Her başlığın bir kategorisi vardır. Seçilen başlığın editlenmesi iin aşağıdaki kod lazım
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
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTitle(int id)
        {
            var Titlevalue = tm.GetByID(id);
            Titlevalue.TitleStatus = false;
            tm.TitleDelete(Titlevalue);
            return RedirectToAction("Index");
        }



    }
}