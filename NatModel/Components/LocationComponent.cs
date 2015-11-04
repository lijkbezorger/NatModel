using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NatModel.Components
{
    class LocationComponent
    {
        public Cell Cell;
        public Field Field { get; set; }

        public Point Point { get; set; }

        public void Update() {

        }

        internal void Offset(int left, int top)
        {
            this.Point = new Point(this.Point.X + left, this.Point.Y + top);
        }
    }
}
