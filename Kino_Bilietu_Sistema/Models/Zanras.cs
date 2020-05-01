using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Kino_Bilietu_Sistema.Models
{
    public class Zanras
    {
        public int id { get; set; }
        public string pav { get; set; }

        public List<Zanras> getZanras()
        {
            List<Zanras> zanrai = new List<Zanras>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT id, pav FROM zanrai";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                zanrai.Add(new Zanras
                {
                    id = Convert.ToInt32(item["id"]),
                    pav = Convert.ToString(item["pav"])
                });
            }

            return zanrai;
        }
    }
}