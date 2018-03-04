using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static OracleConnection GetDBConnection()
        {
            string host = ConfigurationSettings.AppSettings["host"];   //"192.168.10.221";
            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["port"]);
            string sid = ConfigurationSettings.AppSettings["sid"];
            string user = ConfigurationSettings.AppSettings["user"];
            string password = ConfigurationSettings.AppSettings["password"];

            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }

}