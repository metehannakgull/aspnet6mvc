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
    public class SocialMediaUserManager : ISocialMediaUserService
    {
        ISocialMediaUserDal _socialMediaUserDal;

        public SocialMediaUserManager(ISocialMediaUserDal socialMediaUserDal)
        {
            _socialMediaUserDal = socialMediaUserDal;
        }
        public void SocialMediaUserAdd(SocialMediaUser socialMediaUser)//Verileri Ekle
        {
            _socialMediaUserDal.Insert(socialMediaUser);
        }

        public void SocialMediaUserDelete(SocialMediaUser socialMediaUser)//Verileri Sil
        {
            _socialMediaUserDal.Delete(socialMediaUser);
        }

        public SocialMediaUser GetById(int id)//Sadece 1 Social Media User id'sini bulur
        {
            return _socialMediaUserDal.Get(x => x.SocialMediaUserId == id);
        }

        public List<SocialMediaUser> GetList()//Verileri Listele
        {
            return _socialMediaUserDal.List();//Generic Repository'deki List metodu
        }

        public void SocialMediaUserUpdate(SocialMediaUser socialMediaUser)//Verileri güncelle
        {
            _socialMediaUserDal.Update(socialMediaUser);
        }
    }
}
