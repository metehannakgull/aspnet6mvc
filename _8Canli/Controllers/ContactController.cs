using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers 
{
    public class ContactController : Controller
    {

        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();


        public ActionResult Index()
        {
            var contactvalues = cm.GetList();

            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id) //id'sine göre ileşitim mesajlaşan sosyal medya kullanıcılarını bulmak için
        {
            var contactvalues = cm.GetByID(id);

            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu() //PARTİAL VİEW oluşturdum
        {
            return PartialView();
        }
    }
}