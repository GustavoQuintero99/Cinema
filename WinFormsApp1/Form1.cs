using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        #region PanelHiding
        private void customizeDesign()
        {

            panelPeliculas.Visible = false;
        }

        private void hideSubMenu()
        {

            if (panelPeliculas.Visible == true)
                panelPeliculas.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #endregion
        #region Moviemiento_Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void arrastrarVentana(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        #region WindowConfig
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
        }

        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(4, 28, 100);
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Transparent;
        }
        #endregion

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPeliculas);
        }

        private void btnCartelera_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());

            hideSubMenu();
        }

        private void btnBoletos_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());

            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                activateForm.Close();
            panelContainer.BringToFront();
            panelContainer.Show();
            hideSubMenu();
        }
        private Form activateForm = null;
        private void openChildForm(Form childForm)
        {

            if (activateForm != null)
                activateForm.Close();
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }




}

/*
             string query = "SELECT * FROM Movies";
            string connection_string = "datasource=database-1.cx1u3ws4yndt.us-east-2.rds.amazonaws.com;port=3306;username=cutrebirth;password=rebirth2021;database=CineManagement;";
            MySqlConnection connection = new MySqlConnection(connection_string);
            MySqlCommand comm = new MySqlCommand(query, connection);
            comm.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                connection.Open();
                reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show(reader.GetString(1));

                    }

                }
                else
                {
                    MessageBox.Show("No contiene informacion");
                }
                
                connection.Close();
            }
            catch(Exception c)
            {
                MessageBox.Show(c.Message);
            }
*/