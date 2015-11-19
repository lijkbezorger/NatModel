using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatModel.Entities;
using System.Drawing;

namespace NatModel
{
    public class Field
    {
        protected Cell[][] island;
        protected int size;
        public List<Animal> animals;
        public List<Animal> added = new List<Animal>();
        public List<Animal> removed = new List<Animal>();
        private MainForm form;
        

        public Boolean IsEmpty { get { return animals.Count() == 0; } }

        public int Size { get { return size; } }

        public Cell GetCell(Point location)
        {
            if (IsValidLocation(location))
            {
                return island[location.X][location.Y];
            }
            return null;
        }

        public void Subscribe(MainForm _form)
        {
            form = _form;
        }

        public Cell[][] Island { get { return island; }  }
        public void Update()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Island[i][j].Update();
                }
            }
            ApplyMove();
            form.Refresh();
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

        public void AddAnimal (Animal animal, bool refresh = true)
        {
            animals.Add(animal);
            GetCell(animal.Location).MoveTo(animal);
            if (refresh)
            {
                form.Refresh();
            }
        }

        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
        }
        public void AddAnimalAfter(Animal animal)
        {
            animal.Location = this.GetFreePoint();
            added.Add(animal);
        }

        public void RemoveAnimalAfter(Animal animal)
        {
            removed.Add(animal);
        }

        public Point GetFreePoint()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int left;
            int top;
            do
            {
                top = rand.Next(size);
                left = rand.Next(size);
            }
            while (!island[left][top].IsEmpty);

            return new Point(left, top);
        }

        internal bool IsValidLocation(Point location)
        {
            return (location.X >= 0) && (location.Y >= 0) && (location.X < size) && (location.Y < size);
        }


        internal void ApplyMove()
        {
            foreach (Animal item in animals)
            {
                item.ApplyMove();
            }

            foreach (Animal item in added)
            {
                AddAnimal(item, false);
            }
            foreach (Animal item in removed)
            {
                RemoveAnimal(item);
            }
            added = new List<Animal>();
            removed = new List<Animal>();
        }
    }
}
