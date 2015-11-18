using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NatModel.Properties;

namespace NatModel.Entities
{
    class Rabbit:Animal
    {
        public override string Name
        {
            get
            {
                return "Rabbit";
            }
        }

        public override void Update()
        {
            Random rand = new Random();
            int top = rand.Next(3)-1;
            int left = rand.Next(3)-1;
            
            if (rand.Next(5) == 1)
            {
                var rabbit = new Rabbit(Location.Field);
                rabbit.Location.Point = this.Location.Field.GetFreePoint();
                this.Location.Field.AddAnimal(rabbit);
            }

            this.Location.Offset(left, top);
        }

        public Rabbit(Field field) : base(field) { }

        public override Image GetAsset()
        {
            return Resources.rabbit;
        }
    }
}
