using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iLunch.Dominio;

namespace iLunch.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>, IDisposable
    {
    }
}
