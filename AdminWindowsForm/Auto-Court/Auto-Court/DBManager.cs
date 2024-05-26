using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Auto_Court
{
    public static class DBManager
    {
        private static readonly string MyConString= "Server=127.0.0.1;port=3306;Database=courtautomation;Trusted_connection=;Uid=root;Pwd=PHW#12#joach";

        public static DataTable ExecuteQueryWithParameters(string query,params MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                using(MySqlCommand cmd=new MySqlCommand(query,connection))
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                    DataTable dt = new DataTable();
                    try 
                    {
                        connection.Open();
                        using (MySqlDataReader reader =cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    return dt;
                }
            }
        }
        public static int ExecuteNonQueryWithParameters(string query, params MySqlParameter[] parameters)
        {
            using(MySqlConnection connection = new MySqlConnection(MyConString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query,connection))
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return -1;
                    }
                }
            }
        }
    }
}
