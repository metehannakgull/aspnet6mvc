using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)//dependency injection
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)//Verileri Ekle
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)//Veri Sil
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)//Veri Güncelle
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)//Sadece bir kategorinin id'sini bul
        {
            return _categoryDal.Get(x => x.CategoryId==id);
        }

        public List<Category> GetList()//Verileri Listele
        {
            return _categoryDal.List();//Generic Repository'deki List metodu
        }



       

    }
}
