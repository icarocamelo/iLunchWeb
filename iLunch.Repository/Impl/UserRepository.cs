using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using iLunch.Repository.Interfaces;
using iLunch.Dominio;

namespace iLunch.Repository.Impl
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session)
        {
        }
    }
}
