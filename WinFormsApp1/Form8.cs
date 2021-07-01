using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form8 : Form
    {
        Image image;
        public int num;
        public Form1 info;
        DataBase update;
        public Form8(Form1 info)
        {
            InitializeComponent();
            num = info.Membership;
            image = Image.FromFile("..//..//..//Resources/" + num + ".png");
            pictureBox5.Image = image;
            label3.Text += num;
            this.info = info;
            update = new DataBase();



            if (num == 1)
            {

            }
            else if (num == 2)
            {
                pictureBox2.Enabled = false;
                label4.Text += "\n(NOTA, USTED NO PUEDE SELECCIONAR LA MEMBRESIA 2 PORQUE USTED YA LA TIENE)";
                button1.Enabled = false;
            }
            else if (num == 3)
            {
                pictureBox3.Enabled = false;
                label4.Text += "\n(NOTA, USTED NO PUEDE SELECCIONAR LA MEMBRESIA 3 PORQUE USTED YA LA TIENE)";
                button2.Enabled = false;
            }
            else if (num == 4)
            {
                label4.Text += "\n(NOTA, USTED NO PUEDE SELECCIONAR LA MEMBRESIA 4 PORQUE USTED YA LA TIENE)";
                pictureBox4.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (num== 1)
            {
                MessageBox.Show("POR EL SIMPLE HECHO DE TENER UNA CUENTA EN NUESTRO SISTEMA USTED CUENTA CON ESTOS DESCUENTOS:\nMEMBRESIA DE NIVEL 1\n CUENTA CON DESCUENTO DE: \n-3 PESOS POR BOLETO\n-UN BOLETO GRATIS AL MES A CUALQUIER PELICULA");

            }
            else if (num == 2)
            {
                MessageBox.Show("MEMBRESIA DE NIVEL 2\n CUENTA CON DESCUENTO DE: \n-5 PESOS POR BOLETO\n-UN BOLETO GRATIS AL MES A CUALQUIER PELICULA\n-DESCUENTOS ESPECIALES EN TAQUILLA PRESENCIAL");
            }
            else if (num == 3)
            {
                MessageBox.Show("MEMBRESIA DE NIVEL 3\n CUENTA CON DESCUENTO DE: \n-7 PESOS POR BOLETO\n-DOS BOLETOS GRATIS AL MES A CUALQUIER PELICULA\n-DESCUENTOS ESPECIALES EN TAQUILLA PRESENCIAL\n-Refill por 2 veces");
            }
            else if (num == 4)
            {
                MessageBox.Show("MEMBRESIA DE NIVEL 4\n CUENTA CON DESCUENTO DE: \n-10 PESOS POR BOLETO\n-TRES BOLETOS GRATIS AL MES A CUALQUIER PELICULA\n-DESCUENTOS ESPECIALES EN TAQUILLA PRESENCIAL\n-Palomitas grandes a precio de chicas\n-Refill ilimitado");
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MEMBRESIA DE NIVEL 2\n CUENTA CON DESCUENTO DE: \n-5 PESOS POR BOLETO\n-UN BOLETO GRATIS AL MES A CUALQUIER PELICULA\n-DESCUENTOS ESPECIALES EN TAQUILLA PRESENCIAL");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MEMBRESIA DE NIVEL 3\n CUENTA CON DESCUENTO DE: \n-7 PESOS POR BOLETO\n-DOS BOLETOS GRATIS AL MES A CUALQUIER PELICULA\n-DESCUENTOS ESPECIALES EN TAQUILLA PRESENCIAL\n-Refill por 2 veces");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MEMBRESIA DE NIVEL 4\n CUENTA CON DESCUENTO DE: \n-10 PESOS POR BOLETO\n-TRES BOLETOS GRATIS AL MES A CUALQUIER PELICULA\n-DESCUENTOS ESPECIALES EN TAQUILLA PRESENCIAL\n-Palomitas grandes a precio de chicas\n-Refill ilimitado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update.updateMemership(info.Account, 2);
            info.Account = 2;
            num = 2;
            info.Membership = 2;
            MessageBox.Show("Membresia comprada!");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            update.updateMemership(info.Account, 3);
            info.Account = 3;
            num = 3;
            info.Membership = 3;
            MessageBox.Show("Membresia comprada!");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update.updateMemership(info.Account, 4);
            info.Account = 4;
            info.Membership = 4;
            MessageBox.Show("Membresia comprada!");
            this.Close();
        }
    }
}
