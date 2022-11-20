using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _8Canli.Controllers
{                     //Admin admin girişini, Yazar ise kullanıcı giriş bilgilerini girerek proje sistemine erişim sağlayacak.
    [AllowAnonymous] //BU KOMUT SAYESİNDE Login Controller'daki işlemlerim genel filtrelemen muaf oldu. Yani proje sistemine ulaşmak için önce bu sayfalardaki giriş işlemleri gerçekleştirilmelidir
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if(adminInfo!=null) //admin girişi doğruysa AdminCategory'e erişime izin ver
            {
                FormsAuthentication.SetAuthCookie(adminInfo.AdminUserName,false);
                Session["AdminUserName"] = adminInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult SocialMediaUserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SocialMediaUserLogin(SocialMediaUser p)
        {
            Context c = new Context();
            var socialMediaUserInfo = c.SocialMediaUsers.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (socialMediaUserInfo != null) //admin girişi doğruysa AdminCategory'e erişime izin ver
            {
                FormsAuthentication.SetAuthCookie(socialMediaUserInfo.Email, false);
                Session["Email"] = socialMediaUserInfo.Email;
                return RedirectToAction("MyContent", "SocialMediaUserContent");
            }
            else
            {
                return RedirectToAction("SocialMediaUserLogin");
            }
        }
    }
}