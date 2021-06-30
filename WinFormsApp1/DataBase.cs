using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class DataBase
    {
        public MySqlConnectionStringBuilder builder;


        public DataBase()
        {
            this.builder = new MySqlConnectionStringBuilder();
        }

        public void conection()
        {
            builder.Server = "database-1.cx1u3ws4yndt.us-east-2.rds.amazonaws.com";
            builder.Port = 3306;
            builder.UserID = "cutrebirth";
            builder.Password = "rebirth2021";
            builder.Database = "CineManagement";
        }


        public DataTable SearchMovies()
        {
            DataGridView dataGridView1 = new DataGridView();
            DataTable table = new DataTable();
            conection();
            try
            {
                MySqlConnection conn = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "";
                conn.Open();
                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT * from Movies";
                MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
                MyDA.Fill(table);
                conn.Close();
            }
            catch (System.Exception) { MessageBox.Show("a"); }
            return table;

        }

        public DataTable SearchAccount()
        {
            DataGridView dataGridView1 = new DataGridView();
            DataTable table = new DataTable();
            conection();
            try
            {
                MySqlConnection conn = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "";
                conn.Open();
                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT * from Account";
                MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
                MyDA.Fill(table);
                conn.Close();
            }
            catch (System.Exception) { MessageBox.Show("a"); }
            return table;

        }

        public DataTable SearchCandys()
        {
            DataGridView dataGridView1 = new DataGridView();
            DataTable table = new DataTable();
            conection();
            try
            {
                MySqlConnection conn = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "";
                conn.Open();
                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT * from Candys";
                MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
                MyDA.Fill(table);
                conn.Close();
            }
            catch (System.Exception) { MessageBox.Show("a"); }
            return table;

        }


        public CandyBar CandyInfortamiton(int ID) {

            CandyBar candyinfo = new CandyBar();
            conection();
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Candys WHERE ID='" + ID + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            try
            {
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        candyinfo.Id = reader.GetInt32(0);
                        candyinfo.Name = reader.GetString(1);
                        candyinfo.Price = reader.GetInt32(2);
                        candyinfo.Description = reader.GetString(3);
                        candyinfo.Image = reader.GetString(4);

                    }
                    MessageBox.Show("Hecho con exito");
                }
                else
                {
                    candyinfo = null;
                    MessageBox.Show("Algo salio mal");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e + "");
            }

            return candyinfo;

        }

        public DataTable SearchMembership()
        {
            DataGridView dataGridView1 = new DataGridView();
            DataTable table = new DataTable();
            conection();
            try
            {
                MySqlConnection conn = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "";
                conn.Open();
                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT * from Membership";
                MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
                MyDA.Fill(table);
                conn.Close();
            }
            catch (System.Exception) { MessageBox.Show("a"); }
            return table;

        }

        public Account AccountExist(string user, string pass) {
            
            Account account= new Account();

            conection();
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Account WHERE Email='" + user + "' AND Password ='" + pass + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            try
            {
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        account.Id = reader.GetInt32(0);
                        account.Name = reader.GetString(1);
                    }
                    MessageBox.Show("Bienvenido " + account.Name + " ");
                }
                else {
                    account = null;
                }

            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return account;
        }

        public bool RegisterAccount(string user,string password,string phone,string mail)
        {
            conection();
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `CineManagement`.`Account` (`Name`, `Phone`, `Email`, `Password`, `Membership`) VALUES ('"+user+"',"+phone+", '"+mail+"', '"+password+"', '4')";
            conn.Open();
            cmd.ExecuteNonQuery();
            try
            {
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e) { MessageBox.Show(e.Message);  return false; }
        }


    }
}
    
        


     