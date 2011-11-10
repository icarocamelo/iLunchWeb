using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using iLunch.Repository.Infrastructure;
using iLunch.Repository.Interfaces;

namespace iLunch.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T>
    {
        public T Insert(T obj)
        {
            using (ISession session = NHibernateUtils.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    transaction.Commit();
                }
            }

            return obj;
        }

        public T Update(T obj)
        {
            using (ISession session = NHibernateUtils.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    transaction.Commit();
                }
            }

            return obj;
        }

        public void Delete(T obj)
        {
            using (ISession session = NHibernateUtils.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(obj);
                    transaction.Commit();
                }
            }
        }

        public T GetById(long id)
        {
            using (ISession session = NHibernateUtils.OpenSession())
            {
                return (T)session.Get(typeof(T), id, LockMode.Read);
            }
        }

        public ICollection<T> GetAll()
        {
            using (ISession session = NHibernateUtils.OpenSession())
            {
                return session.CreateCriteria(typeof(T)).List<T>();
            }
        }

        public ICollection<T> GetInterval(int start, int max)
        {
            using (ISession session = NHibernateUtils.OpenSession())
            {
                return session.CreateCriteria(typeof(T))
                    .SetMaxResults(max)
                    .SetFirstResult(start).List<T>();
            }
        }
    }
}
