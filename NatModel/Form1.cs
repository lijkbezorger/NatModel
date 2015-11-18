using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NatModel.Entities;

namespace NatModel
{
    public partial class Form1 : Form
    {
        Field field;

        public Form1()
        {
            InitializeComponent();

            int size = 20;

            field = new Field(size);
            field.Subscribe(this);

            field.AddAnimal(new Rabbit(field));

            this.Width = size * 30 + 20;
            this.Height = size * 30 + 40;

            timer1.Tick += Timer1_Tick;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            field.Update();
        }

        public void Redraw()
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i <= field.Island.Length; i++)
            {
                g.DrawLine(Pens.Black, i * 30, 0, i * 30, field.Island.Length * 30);
                g.DrawLine(Pens.Black, 0, i * 30, field.Island.Length * 30, i * 30);
            }

            for (int i = 0; i < field.Island.Length; i++)
            {
                for (int j = 0; j < field.Island[0].Length; j++)
                {
                    Animal animal = field.Island[i][j].Animal;
                    if (animal != null)
                    {
                        Rectangle rect = new Rectangle(animal.Location.Point.X * 30 + 2, animal.Location.Point.Y * 30 + 2, 28, 28);
                        g.DrawImage(animal.GetAsset(), rect);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
