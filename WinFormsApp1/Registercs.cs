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
    public partial class Registercs : Form
    {
        #region Moviemiento_Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        Form6 parent;
        public Registercs(Form6 form)
        {
            parent = form;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            if(user_box.TextLength > 3 && password_box.TextLength > 3 && mail_box.TextLength > 5 && phone_box.TextLength > 3)
            {
                DataBase data = new DataBase();

                if(data.RegisterAccount(user_box.Text,password_box.Text,phone_box.Text,mail_box.Text))
                {
                    MessageBox.Show("Registrado de manera correcta");
                    parent.Enabled = true;
                    this.Close();
                }
                else
                {
                    user_box.Text = "";
                    password_box.Text = "";
                    phone_box.Text = "";
                    mail_box.Text = "";
                    MessageBox.Show("Fallo el registro");
                }

            }
            else
            {
                MessageBox.Show("Los datos no cumplen los requerimientos");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            parent.Enabled = true;
            this.Close();
        }

        private void test(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
