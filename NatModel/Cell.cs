using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatModel.Entities;
using System.Windows.Forms;

namespace NatModel
{
    public class Cell
    {
        public List<Animal> Animals = new List<Animal>();

        public Cell (Animal animal=null)
        {
            if (animal != null) {
                Animals.Add(animal);
            }
        }

        public void Update()
        {
            foreach (var animal in Animals)
            {
                animal.Update();
            }

        }

        public void LeaveFrom(Animal animal)
        {
            Animals.Remove(animal);
        }

        public void MoveTo(Animal animal, bool add = false)
        {
            Animals.Add(animal);
        }

        public Boolean IsEmpty { get { return Animals.Count() == 0;  } }
    }
}
