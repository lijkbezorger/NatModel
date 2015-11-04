using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatModel.Components;

namespace NatModel.Entities
{
    abstract class Animal
    {
        public abstract String Name { get;}
        public abstract void Update();
        public LocationComponent Location;

        public Animal(Field field)
        {
            this.Location = new LocationComponent() { Field = field };
        }
    }
}
