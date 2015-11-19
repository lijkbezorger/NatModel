using NatModel.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatModel.Entities
{
    class Wolf:Animal
    {
        protected int life = 50;

        protected Animal killedRabbit;

        public override string Name
        {
            get
            {
                return "Wolf";
            }
        }

        protected Boolean DoLifeCycle()
        {
            this.life--;
            return this.life != 0;
        }

        protected Boolean Hunt()
        {
            Cell cell;
            Animal rabbit;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    cell = Field.GetCell(new Point(Location.X + i, Location.Y + j));
                    if (cell != null)
                    {
                        rabbit = cell.Animals.FirstOrDefault(x => (x is Rabbit));
                        if (rabbit != null)
                        {
                            if (i == 0 && j == 0)
                            {
                                killedRabbit = rabbit;
                                return true;
                            }
                            else
                            {
                                Offset(i, j);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public override void Update()
        {
            if (DoLifeCycle())
            {
                if (!Hunt())
                {
                    Move();
                }
            }
        }

        public override void ApplyMove()
        {
            if (killedRabbit != null)
            {
                killedRabbit.Dead();
                life += 10;
                killedRabbit = null;
            }
            else
            {
                base.ApplyMove();
            }

            if (life <= 0)
            {
                Dead();
            }
        }

        public Wolf(Field field) : base(field) {}

        public override Image GetAsset()
        {
            Resources.wolf.MakeTransparent(Color.White);
            return Resources.wolf;
        }
    }
}
