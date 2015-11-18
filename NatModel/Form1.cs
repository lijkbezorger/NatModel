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

            field = new Field(20);
            field.Subscribe(this);
        }

        public void Redraw()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
