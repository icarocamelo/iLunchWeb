using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using iLunch.Dominio;
using iLunch.Repository.Interfaces;

namespace iLunch.Repository.Impl
{
    public class OrderRepository : AbstractRepository<Order>, IOrderRepository
    {
        public OrderRepository(ISession session) : base(session)
        {
        }
    }
}
