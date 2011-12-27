using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLunch.Dominio
{
    [Serializable]
    public class Order : Entity
    {
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
