using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLunch.Dominio
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
    }
}
