using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iLunch.Dominio
{
    [Serializable]
    public class Meal : Entity
    {
        public virtual string Description { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public virtual decimal Price { get; set; }
    }
}