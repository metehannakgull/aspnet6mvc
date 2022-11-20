using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(); //veri listele ŞARTLI. gelen mesajlar
        List<Message> GetListSendBox(); //veri listele ŞARTLI. göncerilen mesajlar

        void MessageAdd(Message message); //veri ekle

        Message GetByID(int id); //Bir message'ın id'sini getir

        void MessageDelete(Message message);//veri silme

        void MessageUpdate(Message message);//veri güncelle
    }
}
