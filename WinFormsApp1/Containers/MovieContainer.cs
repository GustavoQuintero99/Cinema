using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.Containers
{
    public partial class MovieContainer : UserControl
    {

        public MovieContainer(string _name, string _synopsys, string _image)
        {
            Image image = Image.FromFile("..//..//..//Resources/" + _image);
            MovieInf movie = new MovieInf();
            InitializeComponent();
            this._name = _name;
            this._synopsys = _synopsys;
            this._image = image;
            lblName.Text = this._name;
            lblSynopsys.Text = "Sinopsis: \n" + this._synopsys;
            pictureBox1.Image = this._image;

        }
        private string _name;
        private string _synopsys;
        private Image _image;



        [Category("Custom Props")]
        public string Name1
        {
            get { return _name; }
            set { _name = value; lblName.Text = value; }
        }

        [Category("Custom Props")]
        public string Synopsys
        {
            get { return _synopsys; }
            set { _synopsys = value; lblSynopsys.Text = value; }
        }

        [Category("Custom Props")]
        public Image Image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {

        }
    }
}
