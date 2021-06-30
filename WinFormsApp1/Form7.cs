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
        Movie newMovie = new Movie();
        byte[] seat;
        public Form7()
        {
            InitializeComponent();
            Movie newMovie = information.MovieInformation(29);
            label3.Text = newMovie.Name;
            label2.Text = newMovie.Price + "";
            textBox1.Text = newMovie.Synopsys;
            textBox1.Enabled = false;
            seat = File.ReadAllBytes(newMovie.Seat);
            button3.Enabled = false;

            /*newMovie.Name = "Milton lecter diciendo a";
            newMovie.Price = 15;
            newMovie.Synopsys = "chinga tu madre miltonnaaaaaaaaaaaaaaa";
            newMovie.Image = "/RutaDeImage/";
            newMovie.Date = DateTime.Now;
            information.registerMovie(newMovie, 30);*/

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
                }
                catch
                {
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
        private Object ByteArrayToObject(byte[] arrBytes)
        {

            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int position = 0;
            position = 0;
            foreach (int value in this.array)
            {
                if (value == 2)
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
    }
}
