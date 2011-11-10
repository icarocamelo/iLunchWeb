using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace iLunch.Dominio.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Login);
            Map(x => x.Password);
        }
    }
}
