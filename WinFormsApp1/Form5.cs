using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            customizeDesign();
            DataBase dataConn = new DataBase();
        }

        private void customizeDesign()
        {
            panelPalomitas.Visible = false;
            panelDulces.Visible = false;
            panelBebidas.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelPalomitas.Visible == true)
                panelPalomitas.Visible = false;
            if (panelDulces.Visible == true)
                panelDulces.Visible = false;
            if (panelBebidas.Visible == true)
                panelBebidas.Visible = false;
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



        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPalomitas);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnPalomitas.FlatAppearance.BorderColor = Color.FromArgb(40, 108, 252);
            btnPalomitas.ForeColor = Color.FromArgb(40, 108, 252);
            btnPalomitas.FlatAppearance.BorderSize = 1;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnPalomitas.FlatAppearance.BorderColor = Color.Black;
            btnPalomitas.ForeColor = Color.Black;
            btnPalomitas.FlatAppearance.BorderSize = 0;
        }

        private void btnBebidas_MouseEnter(object sender, EventArgs e)
        {
            btnBebidas.FlatAppearance.BorderColor = Color.FromArgb(40, 108, 252);
            btnBebidas.ForeColor = Color.FromArgb(40, 108, 252);
            btnBebidas.FlatAppearance.BorderSize = 1;
        }

        private void btnBebidas_MouseLeave(object sender, EventArgs e)
        {
            btnBebidas.FlatAppearance.BorderColor = Color.Black;
            btnBebidas.ForeColor = Color.Black;
            btnBebidas.FlatAppearance.BorderSize = 0;
        }

        private void btnDulces_MouseEnter(object sender, EventArgs e)
        {
            btnDulces.FlatAppearance.BorderColor = Color.FromArgb(40, 108, 252);
            btnDulces.ForeColor = Color.FromArgb(40, 108, 252);
            btnDulces.FlatAppearance.BorderSize = 1;
        }

        private void btnDulces_MouseLeave(object sender, EventArgs e)
        {
            btnDulces.FlatAppearance.BorderColor = Color.Black;
            btnDulces.ForeColor = Color.Black;
            btnDulces.FlatAppearance.BorderSize = 0;
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBebidas);
        }

        private void btnDulces_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDulces);
        }

        private void gradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}