using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatModel.Components;
using System.Drawing;
using System.Windows.Forms;

namespace NatModel.Entities
{
    public abstract class Animal
    {
        protected static Random rand = new Random(DateTime.Now.Millisecond);
        public abstract String Name { get;}
        public abstract void Update();

        public override string ToString()
        {
            return String.Format("{0}: [{1},{2}]", Name, Location.X, Location.Y);
        }

        public Field Field { get; set; }

        public Point Location { get; set; }
        public Point newLocation { get; set; }

        public Animal(Field field)
        {
            this.Field = field;
        }

        protected void Move()
        {            
            int top = rand.Next(3) - 1;
            int left = rand.Next(3) - 1;

            this.Offset(left, top);
        }

        internal void Offset(int left, int top)
        {
            newLocation = new Point(this.Location.X + left, this.Location.Y + top);
        }

        public abstract Image GetAsset();

        internal void Dead()
        {
            Field.GetCell(this.Location).LeaveFrom(this);
            Field.RemoveAnimalAfter(this);
        }

        public virtual void ApplyMove()
        {
            if (Field.IsValidLocation(newLocation))
            {
                Field.GetCell(this.Location).LeaveFrom(this);
                this.Location = newLocation;
                Field.GetCell(this.Location).MoveTo(this);
            }
        }
    }
}
