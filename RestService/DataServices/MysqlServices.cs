using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.DataServices
{
    //MySQL Connection Class
    class MysqlServices
    {
        private MySqlConnection connection = null;
        private string connetStr = "SERVER=localhost;DATABASE=rest_records;UID=root;PASSWORD=rootpassword;";

        public bool OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(connetStr);
            try
            {
                connection.Open();
                LogHelper.Info("MySql connect success");
                this.connection = connection;
                return true;
            }
            catch (MySqlException ex)
            {               
                LogHelper.Error("MySql connect failure", ex);
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                this.connection.Close();
                LogHelper.Info("MySql closed success");
                this.connection = null;
                return true;
            } catch(MySqlException ex)
            {
                LogHelper.Error("MySql closed fail", ex);
                return false;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO rest_records (direction, url, attribution, occurrence_time, request_ip) VALUES('request', '/zd/in/vehicleOutbound/skfjs5cf4s', 'ZD', '"+ new DateTime().ToString() +"', '192.168.1.106')";

            //open connection
            if (this.connection != null)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    LogHelper.Info("MySql closed success");
                }
                catch (MySqlException ex)
                {
                    LogHelper.Error("MySql closed failure", ex);
                }
                
                //close connection
                this.CloseConnection();
            } else
            {
                LogHelper.Info("MySql connection is null, restart now");
                this.OpenConnection();

                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, this.connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    LogHelper.Info("MySql closed success");
                }
                catch (MySqlException ex)
                {
                    LogHelper.Error("MySql closed failure", ex);
                }

                //close connection
                this.CloseConnection();
            }
        }
    }

  

}
