using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySql.Data.MySqlClient;
using System.Data;

namespace BottomTabTeste
{
    class DBConnect
    {
        public static MySqlConnection sqlconn;
        public static string connsqlstring = "Server=dbmy0050.whservidor.com;Port=3306;database=dm2l_7;User Id=dm2l_7;Password=d2ladmin;charset=utf8";

        public static void Conecta_Banco(Activity main) {
            MySqlConnection sqlconn;
            string connsqlstring = "Server=dbmy0050.whservidor.com;Port=3306;database=dm2l_7;User Id=dm2l_7;Password=d2ladmin;charset=utf8";
            sqlconn = new MySqlConnection(connsqlstring);
            sqlconn.Open();
            //MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
            //string result = sqlcmd.ExecuteScalar().ToString();
            //sqlconn.Close();
        }

        
        public static string GetText(string text, Context context)
        {
            MySqlConnection sqlconn;
            string connsqlstring = "Server=dbmy0050.whservidor.com;Port=3306;database=dm2l_7;User Id=dm2l_7;Password=d2ladmin;charset=utf8";
            sqlconn = new MySqlConnection(connsqlstring);
            sqlconn.Open();
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand("select * from appvalidacao where nrofone = " + text, sqlconn);
                string resposta = sqlcmd.ExecuteScalar().ToString();
                sqlconn.Close();
                return resposta;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            }
        
}
}