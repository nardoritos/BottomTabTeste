using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace BottomTabTeste
{
    public static class Holder
    {
        
        static Random rnd = new Random();
        public static List<Player> player { get; private set; }
        static Holder()
        {
            player = new List<Player>();
            for (int i = 0; i < 10; i++)
            {
                AddFilmes();
            }

           
        }

        private static void AddFilmes()
        {
            MySqlConnection sqlconn;
            string connsqlstring = "Server=dbmy0050.whservidor.com;Port=3306;database=dm2l_7;User Id=dm2l_7;Password=d2ladmin;charset=utf8";
            string query = "";

            MySqlDataAdapter dataAdapter;
            DataSet dataSet;
            sqlconn = new MySqlConnection(connsqlstring);

            dataAdapter = new MySqlDataAdapter(query, sqlconn);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "mensagens");

            foreach (DataRow row in dataSet.Tables["mensagens"].Rows)
            {
                player.Add(new Player()
                {
                    Id = Convert.ToInt32(row["idmsg"].ToString()),
                    Name = row["nomemsg"].ToString(),
                    Func = row["datamsg"].ToString(),
                    Image = Convert.ToInt32(row["imagemsg"].ToString()),
                    Check = Convert.ToInt32(row["checkmsg"].ToString())
                });
            }
        }
    }
}