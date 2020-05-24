using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Kino_Bilietu_Sistema.Models
{
    public class VietuTipai
    {
        public int id { get; set; }
        public string pav { get; set; }

        public List<Zanras> getVietuTipas()
        {
            List<Zanras> vietuTipai = new List<Zanras>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT id_Vietu_tipai, name FROM vietu_tipai";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                vietuTipai.Add(new Zanras
                {
                    id = Convert.ToInt32(item["id_Vietu_tipai"]),
                    pav = Convert.ToString(item["name"])
                });
            }

            return vietuTipai;
        }
    }
}