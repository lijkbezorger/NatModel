using System;
using System.Collections.Generic;
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

    }

}
