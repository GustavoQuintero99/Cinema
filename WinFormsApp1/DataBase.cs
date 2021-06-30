using convert;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        public bool registerMovie(Movie movieInformation, int seats)
        {
            int[] seat = new int[seats];
            byte[] bytesToSave = ObjectToByteArray(seat);
            string srcSeat = "./" + movieInformation.Name + ".txt";
            File.WriteAllBytes(Path.GetFullPath(srcSeat), bytesToSave);
            conection();
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `CineManagement`.`Movies` (`Name`, `Price`, `Synopsis`, `Image`, `Seat`,`Date`) VALUES ('" + movieInformation.Name + "'," + movieInformation.Price + ", '" + movieInformation.Synopsys + "', '" + movieInformation.Image + "', '" + srcSeat + "', '" + movieInformation.Date + "')";
            conn.Open();
            cmd.ExecuteNonQuery();
            try
            {
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return false; }
        }

        public Movie MovieInformation(int ID)
        {

            Movie movieinfo = new Movie();
            conection();
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Movies WHERE ID='" + ID + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            try
            {
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int index = 0;
                    while (reader.Read())
                    {
                        movieinfo.ID1 = reader.GetInt32(0);
                        movieinfo.Name = reader.GetString(1);
                        movieinfo.Price = reader.GetInt32(2);
                        movieinfo.Synopsys = reader.GetString(3);
                        movieinfo.Image = reader.GetString(4);
                        movieinfo.Seat = reader.GetString(5);
                        movieinfo.Date = (DateTime)reader.GetMySqlDateTime(6);
                    }
                    MessageBox.Show("Se armo la machaca");
                }
                else
                {
                    movieinfo = null;
                    MessageBox.Show("Sabe que salio mal krnal");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e + "");
            }

            return movieinfo;
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

        // Convert a byte array to an Object
        private Object ByteArrayToObject(byte[] arrBytes)
        {

            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }


    }
}
    
        


     