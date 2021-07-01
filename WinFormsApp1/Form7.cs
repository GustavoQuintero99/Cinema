using convert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form7 : Form
    {
        int[] array;
        DataBase information = new DataBase();
        Movie newMovie;
        byte[] seat;
        string srcSeat;
        string seatsBought;
        Form1 info;
        string name;
        int member = 0;
        int bought;
        int total;
        Image image; 
        public Form7(Form1 datosUsuario, int idMovie)
        {

            InitializeComponent();
            newMovie = information.MovieInformation(idMovie);
            image = Image.FromFile("..//..//..//Resources/" + newMovie.Image);
            pictureBox2.Image = image;
            textBox2.Text = newMovie.Name;
            label7.Text = "Precio por boleto: $" + newMovie.Price;
            textBox1.Text = newMovie.Synopsys;
            dateTimePicker1.Value = newMovie.Date;
            dateTimePicker1.Enabled = false;
            textBox1.Enabled = false;
            srcSeat = newMovie.Seat;
            info = datosUsuario;
            name = datosUsuario.Name1;
            member = datosUsuario.Membership;
            if (File.Exists(newMovie.Seat))
            {
                seat = File.ReadAllBytes(srcSeat);
            }
            else
            {
                int[] seat1 = new int[30];
                byte[] bytesToSave = ObjectToByteArray(seat1);
                File.WriteAllBytes(Path.GetFullPath(srcSeat), bytesToSave);
                seat = File.ReadAllBytes(srcSeat);
            }

            button3.Enabled = false;
            button1.Enabled = false;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!Regex.Match(listBox1.GetItemText(listBox1.SelectedItem), "^[D][0-9]*[0-9]*$").Success)
            {
            }
            else
            {
                try
                {
                    this.array[listBox1.SelectedIndex] = 2;
                    listBox1.Items.Insert(listBox1.SelectedIndex, "Seleccionado");
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    button1.Enabled = true;
                }
                catch
                {
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            seat = File.ReadAllBytes(srcSeat);
            button3.Enabled = true;
            this.array = (int[])ByteArrayToObject(seat);
            int index = 0;
            foreach (int value in this.array)
            {
                if (value == 0)
                {
                    listBox1.Items.Add("D" + index);
                }
                else
                {
                    listBox1.Items.Add("Vendido " + index);
                }
                index++;
            }
            button2.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int position = 0;
            position = 0;
            button1.Enabled = false;
            foreach (int value in this.array)
            {
                if (value != 0 && value != 3)
                {
                    try
                    {

                        listBox1.Items.Insert(position, "D" + position);
                        listBox1.Items.RemoveAt(position + 1);
                        array[position] = 0;
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    };

                }
                position++;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                int position = 0;
                foreach (int index in this.array)
                {
                    if (index == 2)
                    {
                        try
                        {
                            seatsBought += " D" + position;
                            this.array[position] = 3;
                            bought++;
                        }
                        catch { MessageBox.Show("Error"); };

                    }
                    position++;
                }

                File.Delete(srcSeat);
                byte[] bytesToSave = ObjectToByteArray(this.array);
                File.WriteAllBytes(Path.GetFullPath(srcSeat), bytesToSave);
                listBox1.Items.Clear();
                button3.Enabled = false;
                button2.Enabled = true;
                button1.Enabled = false;
                int discount = 0;
                checkBox1.Checked = false;
                if (name == null)
                {
                    int total = bought * newMovie.Price;
                    var ticket = new Random();
                    int ticket1 = ticket.Next(1000);
                    MessageBox.Show("Estimado cliente, los asientos que compro son:\n" + seatsBought + "\n por la cantidad de: $" + total + "\n Su folio para recoger los boletos en taquilla es: " + ticket1 + "\nPorfavor, guarde el folio del ticket, ya que sin el no podra recoger sus boletos y ademas este folio ya no se puede volver a conseguir");
                    seatsBought = "";
                    total = 0;
                    bought = 0;
                }
                else
                {

                    if (info.Membership == 1)
                    {
                        total = bought * (newMovie.Price - 3);
                        discount = 3;
                    }
                    else if (info.Membership == 2)
                    {
                        total = bought * (newMovie.Price - 5);
                        discount = 5;
                    }
                    else if (info.Membership == 3)
                    {
                        total = bought * (newMovie.Price - 7);
                        discount = 7;
                    }
                    else if (info.Membership == 4)
                    {
                        total = bought * (newMovie.Price - 10);
                        discount = 10;
                    }

                    var ticket = new Random();
                    int ticket1 = ticket.Next(1000);
                    MessageBox.Show("Estimado " + info.Name1 + ", los asientos que compro son:\n" + seatsBought + "\n por la cantidad de: $" + total + "\nAplicando su descuento de membresia de nivel: " + info.Membership + "\nel cual es de $" + discount + " por boleto comprado. \nSu folio para recoger los boletos en taquilla es: " + ticket1 + " Porfavor, guarde el folio del ticket, ya que sin el no podra recoger sus boletos y ademas este folio ya no se puede volver a conseguir");
                    seatsBought = "";
                    total = 0;
                    bought = 0;
                }
            }
            else
            {
                MessageBox.Show("TIENES QUE ACEPTAR TERMINOS Y CONDICIONES!");
            }

        }

        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        private Object ByteArrayToObject(byte[] arrBytes)
        {

            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            info.openChildForm(new Form7(info, 32));
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}