using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class GaleriController : Controller
    {

        ImageFileManager im = new ImageFileManager(new EFImagefileDal());

        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}