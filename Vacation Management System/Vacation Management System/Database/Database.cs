using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Aguai_Leave_Management_System
{
    public class Database : IDisposable
    {
        // connection to data source		
        private SqlConnection con;
        private readonly string connectionString;

        public Database(string DataSource, string Database, string UserID, string Password)
        {
            DataSource = "Data Source=" + DataSource + ";";
            Database = "Initial Catalog=" + Database + ";";
            UserID = "User ID=" + UserID + ";";
            Password = "Password=" + Password + ";";

            connectionString = DataSource + Database + UserID + Password;
        }

        public Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        }

        public Database(string DataSource, string Database)
        {
            DataSource = "Data Source=" + DataSource + ";";
            Database = "Initial Catalog=" + Database + ";";
            connectionString = DataSource + Database + " Trusted Connection=yes;";
        }

        public SqlTransaction Transaction
        {
            get
            {
                if (con.State == ConnectionState.Open)
                {
                    return con.BeginTransaction();
                }

                return null;
            }
        }



        /// <summary>
        /// Open the connection.
        /// </summary>
        private void Open()
        {
            // open connection
            if (con == null)
            {
                con = new SqlConnection(connectionString);
                con.Open();
            }
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void Close()
        {
            if (con != null)
            {
                con.Close();
                Dispose();
            }
        }

        /// <summary>
        /// Release resources.
        /// </summary>
        public void Dispose()
        {
            // make sure connection is closed
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }

        /// <summary>
        /// Run Sql Query
        /// </summary>
        /// <param name="SQL Query">MySQL query to Execute.</param>
        /// <param name="dataReader">Mysql Datareader</param>
        public void RunQuery(out SqlDataReader dataReader, string sqlQuery)
        {
            try
            {
                Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                dataReader = null;
                Close();
            }
        }

        /// <summary>
        /// Run SQl Command
        /// </summary>
        /// <param name="strCommand">Query to be excecuted</param>
        /// <returns>True if successfull else false</returns>
        public bool RunCommand(string strCommand)
        {
            int returnVal = -1;
            try
            {
                Open();

                SqlCommand cmdDatabase = new SqlCommand(strCommand, con);

                returnVal = cmdDatabase.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Close();
            }

            return returnVal > 0;
        }


        /// <summary>
        /// Execute Scalar 
        /// </summary>
        /// <param name="sqlQuery">SQL query to Execute.</param>
        /// <param name="dataReader">Return result of procedure.</param>
        public long RunScalarQuery(string sqlQuery)
        {
            long ret;

            try
            {
                Open();

                SqlCommand oCommand = con.CreateCommand();

                oCommand.Connection = con;

                oCommand.CommandText = sqlQuery;

                ret = Convert.ToInt64(oCommand.ExecuteScalar());
            }
            catch
            {
                ret = -1;
            }
            finally
            {
                Close();
            }

            return ret;
        }

        /// <summary>
        /// Execute Scalar 
        /// </summary>
        /// <param name="sqlQuery">SQL query to Execute</param>
        public string ExecuteScalarQuery(string sqlQuery)
        {
            string ret;

            try
            {
                Open();

                SqlCommand oCommand = con.CreateCommand();

                oCommand.Connection = con;

                oCommand.CommandText = sqlQuery;

                ret = (string)oCommand.ExecuteScalar();
            }
            catch
            {
                ret = "";
            }
            finally
            {
                Close();
            }

            return ret;
        }


    }
}