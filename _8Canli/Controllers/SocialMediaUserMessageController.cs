using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class SocialMediaUserMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox() //Gelen kutusu  
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox() //Gelen kutusu  
        {
            var messageList = mm.GetListSendBox();
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id) //id'sine göre gelen kutusundaki mesaj detaylarına ulaşıcam
        {
            var values = mm.GetByID(id);

            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id) //id'sine göre giden kutusundaki mesaj detaylarına ulaşıcam
        {
            var values = mm.GetByID(id);

            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "admin@gmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
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

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
       
    }
}