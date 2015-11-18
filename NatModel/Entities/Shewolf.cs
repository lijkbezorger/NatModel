using NatModel.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatModel.Entities
{
    class SheWolf:Wolf
    {
        public override string Name
        {
            get
            {
                return "Shewolf";
            }
        }

        public SheWolf(Field field) : base(field) { }

        public override Image GetAsset()
        {
            return Resources.shewolf;
        }
    }

}
