using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLunch.Dominio
{
    public abstract class Entity
    {
        public virtual long Id { get; set; }
    }
}
