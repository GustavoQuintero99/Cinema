using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        Form1 principal;
        Panel memership;
        public Form6(Form1 principal, Panel memership)
        {
            InitializeComponent();
            this.principal = principal;
            this.memership = memership;
        }

        #region Moviemiento_Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

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
            Account us = search.AccountExist(userB, passB);
            if (us != null)
            {
                this.principal.EnableLoguin(us);
                this.Close();
                principal.Activate();
                principal.Enabled = true;
                memership.Visible= true;
                if (principal.activateForm == null)
                {

                }
                else
                {
                    principal.activateForm.Close();
                }
                
            }
            else
            {
                MessageBox.Show("DATOS INCORRECTOS");
            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            principal.Enabled = true;
            this.Close();
        }

        private void test(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void register_Click(object sender, EventArgs e)
        {
            Registercs register;

            register = new Registercs(this);
            register.Visible = true;
            this.Enabled = false;

        }
    }
}