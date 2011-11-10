using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLunch.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Insert(T obj);
        T Update(T obj);
        void Delete(T obj);
        T GetById(long id);
        ICollection<T> GetAll();
        ICollection<T> GetInterval(int start, int max);
    }
}
