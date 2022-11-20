using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList(); //veri listele

        void AboutAdd(About about); //veri ekle

        About GetByID(int id); //Bir about id'sini getir

        void AboutDelete(About about);//veri silme

        void AboutUpdate(About about);//veri güncelle
    }
}
