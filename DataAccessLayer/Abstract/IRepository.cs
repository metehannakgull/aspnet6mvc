using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        //İnterface'de CRUD işlemleri gerçekleştirecem.
        List<T> List(); //verileri listele

        void Insert(T p); //veri ekle
        void Update(T p);//veri güncelle
        void Delete(T p);//veri sil

        List<T> List(Expression<Func<T, bool>> filter); //Şartlı Listeleme

        T Get(Expression<Func<T, bool>> filter);
    }
}
