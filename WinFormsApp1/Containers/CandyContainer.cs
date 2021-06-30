using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CandyContainer : UserControl
    {
        public CandyContainer()
        {
            CandyBar candy = new CandyBar();
            InitializeComponent();
        }

        private string _name;
        private string _price;
        private string _description;
        private string _image;

        [Category("Custom Props")]
        public string Name1
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Category("Custom Props")]
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private void imageBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
