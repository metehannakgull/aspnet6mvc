using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(); //veri listele

        void ContentAdd(Content content); //veri ekle

        Content GetByID(int id); //Bir content'in id'sini getir

        void ContentDelete(Content content);//veri silme

        void ContentUpdate(Content content);//veri güncelle

        List<Content> GetListByTitleId(int id);//ŞARTLI LİSTELEME. id'ye göre liste istiyorum

        List<Content> GetListBySocialMediaUser(int id);//ŞARTLI LİSTELEME. Socialmediauser'ların kendi içeriklerini kendisine getir.
    }
}
