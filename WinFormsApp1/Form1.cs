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


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int account;
        string name;
        int membership;
        public bool active_session = false;
        public Form activateForm = null;
        public Panel panel;

        public int Account { get => account; set => account = value; }
        public string Name1 { get => name; set => name = value; }
        public string Account1 { get; internal set; }
        public int Membership { get => membership; set => membership = value; }

        public Form1()
        {
            InitializeComponent();
            customizeDesign();
            panel4.Visible = false;
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
            openChildForm(new Form2(this));

            hideSubMenu();
        }

        private void btnBoletos_Click(object sender, EventArgs e)
        {
            openChildForm(new Form7(this, 2));

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


        public void openChildForm(Form childForm)
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

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4());
        }

        private void login_Click(object sender, EventArgs e)
        {
            Form6 login_form;
            if (active_session == false)
            {
                login_form = new Form6(this, this.panel4);
                login_form.Visible = true;
                this.Enabled = false;
            }
            else
            {
                if (activateForm == null)
                {
                    MessageBox.Show("Ha cerrado sesion de manera correcta");
                    active_session = false;
                    account = 0;
                    name = null;
                    membership = 0;
                    login.Text = "Login";
                    panel4.Visible = false;

                }
                else
                {
                    activateForm.Close();
                    MessageBox.Show("Ha cerrado sesion de manera correcta");
                    active_session = false;
                    account = 0;
                    name = null;
                    membership = 0;
                    login.Text = "Login";
                    panel4.Visible = false;

                }

            }

        }

        public void EnableLoguin(Account usuario)
        {
            login.Text = "Log out";
            account = usuario.Id;
            name = usuario.Name;
            membership = usuario.Membership;
            active_session = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form5());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new Form8(this));
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }

}