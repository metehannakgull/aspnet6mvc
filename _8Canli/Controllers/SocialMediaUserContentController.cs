using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class SocialMediaUserContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult MyContent(string p)
        {
            Context c = new Context();

           
            p = (string)Session["Email"]; //SocialMediaUser'ın Email sütunu tutuyorum. Buna göre filtreleme yapıp, kayıtlı kullanıcıların login olmasını sağlayacağım.
            var socialMediaUserIdInfo = c.SocialMediaUsers.Where(x => x.Email == p).Select(y=>y.SocialMediaUserId).FirstOrDefault(); //SESSION KULLANIMI

            
            var contentvalue = cm.GetListBySocialMediaUser(socialMediaUserIdInfo);
            return View(contentvalue);
        }
    }
}