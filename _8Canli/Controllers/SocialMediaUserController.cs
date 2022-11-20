using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using DataAccessLayer.EntityFramework;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace _8Canli.Controllers
{
    public class SocialMediaUserController : Controller
    {
        //SocialMediaUser tablosunu Katmanlı mimari ile çağırmak için öncelikle Business Layer'da 
        //SocialMediaUser Manager'ı çağırmalıyım.

        SocialMediaUserManager sm = new SocialMediaUserManager(new EFSocialMediaUserDal());
        SocialMediaUserValidator smValidator = new SocialMediaUserValidator();

        public ActionResult Index() //verileri listele
        {
            var SocialMediaUserValues = sm.GetList();
            return View(SocialMediaUserValues);
        }
        [HttpGet]
        public ActionResult AddSocialMediaUser()//veri ekleme
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMediaUser(SocialMediaUser p)//veri ekleme
        {
            
            ValidationResult results = smValidator.Validate(p);
            if(results.IsValid)
            {
                sm.SocialMediaUserAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditSocialMediaUser(int id)//veri güncelle
        {
            var smValues = sm.GetById(id);
            return View(smValues);
        }
        [HttpPost]
        public ActionResult EditSocialMediaUser(SocialMediaUser p)//veri güncelle
        {
            ValidationResult results = smValidator.Validate(p);
            if (results.IsValid)
            {
                sm.SocialMediaUserUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}