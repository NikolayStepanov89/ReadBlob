using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using Tutorial.SqlConn;

namespace ReadBlob
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            int j = 1;
            string sql = ConfigurationSettings.AppSettings["select"];

            Console.WriteLine("GetConnection:" + conn);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            //using (FileStream fstream = new FileStream(@"C:\123\5555\"+j+".xml", FileMode.OpenOrCreate))

            try
            {
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();
                Console.WriteLine(conn.ConnectionString, "Successful Connection");


                while (dr.Read())
                {
                    // File.Create(@"C:\123\5555\" + j + ".xml");
                    StreamWriter sw = new StreamWriter(File.Create(ConfigurationSettings.AppSettings["path"] + j + ".xml"));
                    //   byte[] array = Encoding.Default.GetBytes(dr.GetString(0));
                    // fstream.Write(array, 0, array.Length);
                    sw.WriteLine(dr.GetString(0));
                    sw.Close();
                    j = j + 1;
                   // Console.WriteLine(dr.GetOracleBlob(0).ToString());
                }

                conn.Close();

            }
            catch (Exception)
            {
                //  Console.WriteLine("## ERROR: " + ex.Message);
                Console.Read();
                return;


            }
            Console.WriteLine("Connection successful!");

            Console.Read();

        }
    }
}
