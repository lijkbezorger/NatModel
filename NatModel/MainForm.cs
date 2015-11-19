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
    public partial class MainForm : Form
    {
        int hash = 0;
        Field field;

        public MainForm()
        {
            InitializeComponent();

            int size = 20;

            field = new Field(size);
            field.Subscribe(this);


            this.Width = size * 30 + 20 + 200;
            this.Height = size * 30 + 40;

            timer1.Tick += Timer1_Tick;

            DoubleBuffered = false;

            // timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            field.Update();
        }

        public void Redraw(Graphics g)
        {
            g.Clear(Color.White);
            for (int i = 0; i <= field.Size; i++)
            {
                g.DrawLine(Pens.Black, i * 30, 0, i * 30, field.Size * 30);
                g.DrawLine(Pens.Black, 0, i * 30, field.Size * 30, i * 30);
            }
            foreach (var item in field.animals)
            {
                if (item is Rabbit)
                {
                    Rectangle rect = new Rectangle(
                        item.Location.X * 30 + 2,
                        item.Location.Y * 30 + 2,
                        28, 28);
                    var img = item.GetAsset();
                    g.DrawImage(img, rect);
                }
            }
            foreach (var item in field.animals)
            {
                if (!(item is Rabbit))
                {
                    Rectangle rect = new Rectangle(
                        item.Location.X * 30 + 2,
                        item.Location.Y * 30 + 2,
                        28, 28);
                    var img = item.GetAsset();
                    g.DrawImage(img, rect);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            field.Update();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Redraw(CreateGraphics());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            field.AddAnimal(new SheWolf(field) { Location = field.GetFreePoint() });
        }

        private void button5_Click(object sender, EventArgs e)
        {

            field.AddAnimal(new Wolf(field) { Location = field.GetFreePoint() });
        }

        private void button6_Click(object sender, EventArgs e)
        {

            field.AddAnimal(new Rabbit(field) { Location = field.GetFreePoint() });
        }
    }
}
