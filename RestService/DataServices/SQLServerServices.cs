using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RestService.Util;

namespace RestService.DataServices
{
    // SQLServer Connection Class
    public class SQLServerServices : ISQLServerServices
    {
        private static string connetStr;
        // private static string connetStr = "Server=DESKTOP-39OIQ20\\DATABASESERVER;User Id=sa;Pwd=localhost;DataBase=restdb";
        private SqlConnection connection;

        public SQLServerServices()
        {
            try
            {
                connetStr = "Server=" + XmlUtil.getXmlDBValue("DBServer") + "\\DATABASESERVER;User Id=" + XmlUtil.getXmlDBValue("UserId") + ";Pwd=" + XmlUtil.getXmlDBValue("Pwd") + ";DataBase=" + XmlUtil.getXmlDBValue("Database");
                LogHelper.Info("XML database connection node read success");
                connection = new SqlConnection(connetStr);
            }
            catch(Exception e)
            {
                LogHelper.Error("XML database connection node read failed", e);
            }                
        }

        public bool Query()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool SavaRecord(Record record)
        {
            try
            {
                StringBuilder sql = new StringBuilder("INSERT INTO ");
                sql.Append(XmlUtil.getXmlDBValue("tableName"));
                LogHelper.Info("XML database tableName node read success");
                sql.Append("(id,direction,url,attribution,occurrence_time,status) VALUES('");
                sql.Append(record.id);
                sql.Append("','");
                sql.Append(record.direction);
                sql.Append("','");
                sql.Append(record.url);
                sql.Append("','");
                sql.Append(record.attribution);
                sql.Append("','");
                sql.Append(record.occurrence_time);
                sql.Append("','");
                sql.Append(record.status);
                sql.Append("');");
                //LogHelper.Info("SQL String is " + sql);
                SQLService(sql.ToString());
                return true;
            }
            catch(Exception e)
            {
                LogHelper.Error("XML database tableName node read failed", e);
                return false;
            }          
        }

        // Data operating
        private DataTable SQLService(string StrSql)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            try
            {
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand(StrSql, connection);
                LogHelper.Info("Generate SQL Command Success");
                SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
                LogHelper.Info("Execute SQL Command Success");
                if (sqlDataReader.HasRows)
                {
                    // Put the data into the DataTable
                    DataTable dataTable = new DataTable();
                    // Read SqlDataReader content
                    dataTable.Load(sqlDataReader);
                    // Close object and connetion
                    sqlDataReader.Close();
                    connection.Close();
                    return dataTable;
                }
                return null;
            }
            catch (Exception e)
            {
                LogHelper.Error("SQL operating is failed",e);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
