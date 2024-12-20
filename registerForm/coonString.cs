using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registerForm
{
    internal class coonString
    {
        public static SqlConnection dataCon { get; set; }
        public static string Seller {  get; set; }
        public static void connectionDb(string ip, string dbName, string user, string password)
        {
            string connectionString = "Server=" + ip + ";Database=" + dbName + ";User ID=" + user + ";Password=" + password + ";";
            dataCon = new SqlConnection(connectionString);
            dataCon.Open();
            Seller = user;
        }
        public static void connectionDb(String ip, string dbName)
        {
            string connectionString = "Server=" + ip + ";Database=" + dbName + ";Trusted_Connection=True;";
            dataCon = new SqlConnection(connectionString);
            dataCon.Open();
            Seller = Environment.UserName;
        }
    }
}
