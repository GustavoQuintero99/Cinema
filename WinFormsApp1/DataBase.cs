using MySql.Data.MySqlClient;
using System.Data;
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


    }
}
    
        


     