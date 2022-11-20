using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISocialMediaUserService
    {
        List<SocialMediaUser> GetList(); //veri listele
        void SocialMediaUserAdd(SocialMediaUser socialMediaUser);//veri ekleme
        void SocialMediaUserDelete(SocialMediaUser socialMediaUser);//veri silme
        void SocialMediaUserUpdate(SocialMediaUser socialMediaUser);//veri güncelleme

        SocialMediaUser GetById(int id);//bir social media user'ın id'sini getir

    }
}
