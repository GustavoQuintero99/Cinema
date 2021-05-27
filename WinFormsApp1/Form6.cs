using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        Form1 principal;
        public Form6(Form1 principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void login_Click(object sender, EventArgs e)
        {
            string userB = user.Text;
            string passB = password.Text;
            DataBase search = new DataBase();
            Account us=search.AccountExist(userB,passB);
            if (us != null) {

                this.Close();
                principal.open = false;
                principal.Enabled = true;
            }
            else
            {

                MessageBox.Show("DATOS INCORRECTOS");
            }


        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            principal.open = false;
            principal.Enabled = true;
            this.Close();
        }
    }
}
