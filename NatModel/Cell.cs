using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatModel.Entities;

namespace NatModel
{
    class Cell
    {
        public Animal Animal;
        public Cell (Animal animal=null)
        {
            Animal = animal;
        }
    }
}
