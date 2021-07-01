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
        
        public CandyContainer(string _name, string _price, string _description,string _image)
        {
            Image image = Image.FromFile("..//..//..//Resources/" + _image);

            CandyBar candy = new CandyBar();
            InitializeComponent();
            this._name = _name;
            this._price = _price;
            this._description = _description;
            this._image = image;
            lblDescription.Text = this._description;
            lblName.Text = this._name;
            label2.Text = "Precio: $" + this._price;
            pictureBox1.Image = this._image;
        }

        private string _name;
        private string _price;
        private string _description;
        private Image _image;



        [Category("Custom Props")]
        public string Name1
        {
            get { return _name; }
            set { _name = value; lblName.Text = value; }
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set { _price = value; label2.Text = value; }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; lblDescription.Text = value; }
        }

        [Category("Custom Props")]
        public Image Image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }

        private void imageBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compraste este producto exitosamente!");
        }
    }
}
