using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITitleService
    {
        List<Title> GetList(); //veri listele
        List<Title> GetListBySocialMediaUser(int id);//ŞARTLI LİSTELEME

        void TitleAdd(Title title); //veri ekle

        Title GetByID(int id); //Bir title'ın id'sini getir

        void TitleDelete(Title title);//veri silme

        void TitleUpdate(Title title);//veri güncelle
    }
}
