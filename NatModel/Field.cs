using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatModel.Entities;
using System.Drawing;

namespace NatModel
{

    class Field
    {
        protected Cell[][] island;
        protected int size;
        protected List<Animal> animals;
        private Form1 form;

        public void Subscribe(Form1 _form)
        {
            form = _form;
        }

        public Cell[][] Island { get { return island; }  }
        public void Update() {
            var list = new List<Animal>(animals);
            foreach (var animal in list)
            {
                animal.Update();
            }
            form.Redraw();
        }
        public void Clear() { }

        public Field (int size)
        {
            animals = new List<Animal>();
            this.size = size;
            island = new Cell[size][];
            for (int i = 0; i < size; i++)
            {
                Island[i] = new Cell[size];
                for (int j = 0; j < size; j++)
                {
                    Island[i][j] = new Cell();
                }
            }
        }

        public void AddAnimal (Animal animal)
        {
            animals.Add(animal);
            Island[animal.Location.Point.X][animal.Location.Point.X] = new Cell(animal);
        }

        public Point GetFreePoint()
        {
            Random rand = new Random();
            int left;
            int top;
            do
            {
                top = rand.Next(size);
                left = rand.Next(size);
            }
            while (island[left][top].Animal != null);

            return new Point(left, top);
        }
    }
}
