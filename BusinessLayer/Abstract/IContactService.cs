using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList(); //veri listele

        void ContactAdd(Contact contact); //veri ekle

        Contact GetByID(int id); //Bir contact'in id'sini getir

        void ContactDelete(Contact contact);//veri silme

        void ContactUpdate(Contact contact);//veri güncelle
    }
}
