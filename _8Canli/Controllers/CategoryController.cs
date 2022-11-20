using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using System.Web.Mvc;

namespace _8Canli.Controllers
{
    public class CategoryController : Controller
    {
        //Categori tablosunu Katmanlı mimari ile çağırmak için öncelikle Business Layer'da 
        //Categori Manager'ı çağırmalıyım.

        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        // GET: Category
      
       
        public ActionResult GetCategoryList() //Category veri listeleme
        {
            var categoryValues = cm.GetList();//veri listeleme metodumu çağırdım. Category Manager'dan
            return View(categoryValues);
        }
            [HttpGet] //Sayfa yüklendiği zaman çalışacak attribute'dür.
        public ActionResult AddCategory()
        {
            return View();
            //HttpGet ve HttpPost metotları sayesinde sayfa yüklendiğinde veri girişinin önüne geçmiş oldum.
        }

        [HttpPost] //Sayfadaki butona tıkladğında yani post edildiğinde çalış
        public ActionResult AddCategory(Category p) //Category veri ekleme
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if(results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
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