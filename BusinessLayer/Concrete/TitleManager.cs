using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TitleManager : ITitleService
    {
        ITitleDal _titleDal;
        public TitleManager(ITitleDal titleDal)//dependency injection
        {
            _titleDal = titleDal;
        }
        public Title GetByID(int id)//Sadece 1 title'ın id'sini bulur
        {
            return _titleDal.Get(x => x.TitleId == id);
        }

        public List<Title> GetList()//verileri listele
        {
            return _titleDal.List();
        }

        public List<Title> GetListBySocialMediaUser(int id)//ŞARTLI LİSTELEME
        {
            return _titleDal.List(x => x.SocialMediaUserId == id);
        }

        public void TitleAdd(Title title)//Veri ekle
        {
            _titleDal.Insert(title);
        }

        public void TitleDelete(Title title)
        {
            //DELETE İÇERİSİND SİLME DEĞİLDE STATUS GÜNCELLEME YAPILMASI MANTIKLIDIR.
            
            _titleDal.Update(title);
        }

        public void TitleUpdate(Title title)
        {
            _titleDal.Update(title);
        }
    }
}
