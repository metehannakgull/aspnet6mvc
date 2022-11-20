using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object; //T değerine karşılık gelen class'ı tanımlayacam

        public GenericRepository()
        {
            _object = c.Set<T>();// T değerine karşılık gelen class'ı tanımladım.
        }

        public void Delete(T p) //Veri Sil
        {
            var deleteEntity = c.Entry(p); //Silme işlemini EntityState ile yaptım
            deleteEntity.State = EntityState.Deleted; //Silme işlemini EntityState ile yaptım

            _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);//Bir dizide veya listede sadece 1 değer döndürmek için SingleOrDefault kullanılır.
        }

        public void Insert(T p)//Veri Ekle
        {
            var addEntity = c.Entry(p);//Ekleme işlemini EntityState ile yaptım
            addEntity.State = EntityState.Added; //Ekleme işlemini EntityState ile yaptım

           // _object.Add(p);
            c.SaveChanges(); //değişiklikleri kaydet
        }

        public List<T> List() //Verileri listele
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter) //Şartlı Listeleme
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)//Veri güncelle
        {
            var updateEntity = c.Entry(p);//Güncelleme işlemini EntityState ile yaptım
            updateEntity.State = EntityState.Modified;//Güncelleme işlemini EntityState ile yaptım
            c.SaveChanges();
        }
    }
}
