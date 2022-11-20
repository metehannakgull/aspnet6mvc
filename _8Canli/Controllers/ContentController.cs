using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class ContentController : Controller
    {

        //Content tablosunu Katmanlı mimari ile çağırmak için öncelikle Business Layer'da 
        //Content Manager'ı çağırmalıyım.
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByTitle(int id)//Seçilen Title'ın id'sine göre Content'leri getirdim.
        {
            var contentvalue = cm.GetListByTitleId(id);
            return View(contentvalue);
        }
    }
}