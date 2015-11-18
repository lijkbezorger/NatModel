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

            this.Width = size * 30 + 20;
            this.Height = size * 30 + 40;

            timer1.Tick += Timer1_Tick;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            field.Update();
            Graphics g = CreateGraphics();
            for (int i = 0; i <= field.Island.Length; i++)
            {
                g.DrawLine(Pens.Black, i * 30, 0, i * 30, field.Island.Length * 30);
                g.DrawLine(Pens.Black, 0, i * 30, field.Island.Length * 30, i * 30);
            }
        }

        public void Redraw()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
