using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NatModel.Properties;
using System.Windows.Forms;

namespace NatModel.Entities
{
    class Rabbit:Animal
    {
        protected Random bornRandom = new Random(DateTime.Now.Millisecond);

        public override string Name
        {
            get
            {
                return "Rabbit";
            }
        }

        public override void Update()
        {
            Move();
        }
        public override void ApplyMove()
        {
            base.ApplyMove();
            var n = bornRandom.Next(5);

            if (n == 1)
            {
                var rabbit = new Rabbit(Field);
                rabbit.Location = this.Field.GetFreePoint();
                this.Field.AddAnimalAfter(rabbit);
            }            
        }

        public Rabbit(Field field) : base(field) { }

        public override Image GetAsset()
        {
            Resources.wolf.MakeTransparent(Color.White);
            return Resources.rabbit;
        }
    }
}
