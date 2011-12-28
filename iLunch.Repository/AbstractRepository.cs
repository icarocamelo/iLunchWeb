using System.Collections.Generic;
using iLunch.Dominio;
using iLunch.Repository.Interfaces;
using NHibernate;
using System;

namespace iLunch.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T>, IDisposable where T : Entity
    {
        private readonly ISession _session;

        protected AbstractRepository(ISession session)
        {
            _session = session;
        }

        public T Insert(T obj)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(obj);
                transaction.Commit();
            }
            return obj;
        }

        public T Update(T obj)
        {   
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(obj);
                transaction.Commit();
            }

            return obj;
        }

        public void Delete(T obj)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(obj);
                transaction.Commit();
            }
        }

        public T GetById(long id)
        {
            return (T)_session.Get(typeof(T), id, LockMode.Read);
        }

        public ICollection<T> GetAll()
        {   
            return _session.CreateCriteria(typeof(T)).List<T>();
        }

        public ICollection<T> GetInterval(int start, int max)
        {
            return _session.CreateCriteria(typeof(T))
                .SetMaxResults(max)
                .SetFirstResult(start).List<T>();
           
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _session.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
