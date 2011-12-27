using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLunch.Dominio
{
    public class Ingredient : Entity
    {
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
    }
}
