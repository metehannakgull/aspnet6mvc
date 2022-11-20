using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList(); //veri listele

        void CategoryAdd(Category category); //veri ekle

        Category GetByID(int id); //Bir kategorinin id'sini getir

        void CategoryDelete(Category category);//veri silme

        void CategoryUpdate(Category category);//veri güncelle

    }
}
