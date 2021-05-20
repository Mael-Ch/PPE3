using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Linq;
using System.Net;

namespace Model.Data
{
    public class Dbal
    {
        #region CONNECTION BDD

        private MySqlConnection _connection;

        //Constructor
        public Dbal(string database, string server = "localhost", string uid = "root", string password = "5MichelAnnecy")
        {
            Initialize(
                server,
                database,
                uid,
                password
            );
        }

        //Initialize values
        private void Initialize(string server, string database, string uid, string password)
        {
            string connectionString = "";
            connectionString += "SERVER=" + server + ";";
            connectionString += "UID=" + uid + ";";
            connectionString += "PASSWORD= " + password + ";"; 
            connectionString += "DATABASE=" + database + ";";

            try
            {
                _connection = new MySqlConnection(connectionString);
            }
            catch (MySqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
                throw;
            }
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.ForegroundColor = ConsoleColor.Red;
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                Console.ResetColor();
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }
        }

        #endregion
        
        #region INSERT / UPDATE / DELETE / ...
        public void Query(string query)
        {
            Console.WriteLine(query);
            if (OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.ResetColor();
                }
                CloseConnection();
            }
        }
        /// <summary>
        /// Result of example: INSERT INTO tableinfo (name, age) VALUES('John Smith', '33'),(Jean Luc, '43')
        /// </summary>
        /// <param name="table">Example: tableinfo (name, age)</param>
        /// <param name="values">Example: ('John Smith', '33'),(Jean Luc, '43')</param>
        public void Insert(string table, Dictionary<string, dynamic> values)
        {
            string query = "INSERT INTO " + table + " (";
            foreach (var val in values)
            {
                query += val.Key;
                if (values.Last().Key != val.Key) query += ",";
            }
            query += ") VALUES (";
            foreach (var val in values)
            {
                if (val.Value is string) query += "'" + val.Value + "'";
                else if (val.Value is DateTime) query += "'" + val.Value.ToString("yyyy-M-d") + "'";
                else if (val.Value is TimeSpan) query += "'" + val.Value + "'";
                else if (val.Value is bool)
                {
                    if (val.Value) query += "1";
                    else query += "0";
                }
                else if (val.Value is double) query += val.Value.ToString().Replace(',','.');
                else query += val.Value;
                if (values.Last().Key != val.Key) query += ",";
            }
            query += ")";
            Query(query);
        }

        //Update statement
        public void Update(string table, Dictionary<string, dynamic> values, string where)
        {
            string query = "UPDATE " + table + " SET ";
            foreach (var val in values)
            {
                query += val.Key + " = ";
                if (val.Value is string) query += "'" + val.Value + "'";
                else if (val.Value is DateTime) query += "'" + val.Value.ToString("yyyy-M-d") + "'";
                else if (val.Value is bool)
                {
                    if (val.Value) query += "1";
                    else query += "0";
                }
                else query += val.Value;
                if (values.Last().Key != val.Key) query += ",";
            }
            query += " WHERE " + where;
            Query(query);
        }

        //Delete statement
        public void Delete(string table, string where)
        {
            Query("DELETE FROM " + table + " WHERE " + where);
        }
        
        #endregion

        #region SELECT
        public DataSet RQuery(string query)
        {
            Console.WriteLine(query);
            DataSet dataset = new DataSet();
            if (OpenConnection())
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
                    adapter.Fill(dataset);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.ResetColor();
                }
                CloseConnection();
            }
            return dataset;
        }
        public DataTable Select(string table, string where = null, string champs = "*")
        {
            string query = "select " + champs + " from " + table;
            if (where != null) query += " where " + where;
            return RQuery(query).Tables[0];
        }
        public DataTable SelectOrderBy(string table, string champ,string order = "ASC",string limit ="1000")
        {
            return RQuery("select * from " + table + " order by " + champ+" "+order+" LIMIT "+limit).Tables[0];
        }

        public DataRow SelectLast(string table)
        {
            return RQuery("select * from " + table + " order by id desc limit 1").Tables[0].Rows[0];
        }
        
        public DataRow SelectById(string table, int id)
        {
            return RQuery("select * from " + table + " where id = " + id).Tables[0].Rows[0];
        }
        
        #endregion

        #region INITIALISATION BDD

        public void DBinit()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/SIO2-PPE/EGCManager/main/COMMUN/scripte.sql");
            StreamReader reader = new StreamReader(stream);
            String sqlFile = reader.ReadToEnd();

            try
            {
                MySqlScript script = new MySqlScript(_connection, sqlFile);
                script.Execute();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
                throw;
            }
        }

        public void DBhydrate()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/SIO2-PPE/EGCManager/main/COMMUN/hydratation.sql");
            StreamReader reader = new StreamReader(stream);
            String sqlFile = reader.ReadToEnd();

            try
            {
                MySqlScript script = new MySqlScript(_connection, sqlFile);
                script.Execute();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
                throw;
            }
        }

        #endregion
    }
}
