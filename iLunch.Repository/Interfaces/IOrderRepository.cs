
using System;
using iLunch.Dominio;

namespace iLunch.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>, IDisposable
    {
    }
}
