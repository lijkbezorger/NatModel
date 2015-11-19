using NatModel.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatModel.Entities
{
    class Wolf : SheWolf
    {
        protected Animal newWolf;
        public override string Name
        {
            get
            {
                return "Wolf";
            }
        }

        protected override bool Hunt()
        {
            if (!base.Hunt())
            {
                Cell cell;
                Animal tmp;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        cell = Field.GetCell(new Point(Location.X + i, Location.Y + j));
                        if (cell != null)
                        {
                            tmp = cell.Animals.FirstOrDefault(x => ((x is SheWolf) && (x != this)));
                            if (tmp != null)
                            {
                                if (i == 0 && j == 0)
                                {
                                    if ((new Random()).Next(2) == 1)
                                    {
                                        newWolf = new Wolf(Field);
                                    }
                                    else
                                    {
                                        newWolf = new SheWolf(Field);
                                    }
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
            return true;
        }

        public override void ApplyMove()
        {
            if (newWolf != null)
            {
                Field.AddAnimalAfter(newWolf);
                newWolf = null;
            }
            base.ApplyMove();
        }
        public Wolf(Field field) : base(field) { }

        public override Image GetAsset()
        {
            Resources.wolf.MakeTransparent(Color.White);
            return Resources.wolf;
        }
    }
}
