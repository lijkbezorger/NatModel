using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatModel.Entities
{
    class Wolf:Animal
    {
        public override string Name
        {
            get
            {
                return "Wolf";
            }
        }

        public override void Update()
        {
            Random rand = new Random();
            int top = rand.Next(3) - 1;
            int left = rand.Next(3) - 1;            

            this.Location.Offset(left, top);
        }

        public Wolf(Field field) : base(field) {}
    }
}
