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
        public Form1()
        {
            InitializeComponent();
            var field = new Field(20);

            var rabbit = new Rabbit(field);
            rabbit.Location.Point = field.GetFreePoint();

            field.AddAnimal(rabbit);

            MessageBox.Show(rabbit.Location.Point.ToString());
            field.Update();

            MessageBox.Show(rabbit.Location.Point.ToString());

        }


    }
}
