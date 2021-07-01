﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Containers;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        DataBase dataConn = new DataBase();
        MovieInf newMovie = new MovieInf();
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<MovieInf> movieInfs = dataConn.allMovies();
            if (flowLayoutPanel1.Controls.Count > 0)
            {
            }
            else
            {
                foreach (MovieInf content in movieInfs)
                {
                    flowLayoutPanel1.Controls.Add(new MovieContainer(content.Name, content.Synopsys, content.Image));

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
