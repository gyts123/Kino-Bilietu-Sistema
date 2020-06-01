using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Kino_Bilietu_Sistema.Models
{
    public class Naudotojas
    {
        public string elpastas { get; set; }
        public string slaptazodis { get; set; }
        public string naudotojo_vardas { get; set; }
        public string telnr { get; set; }
        public int id_Naudotojas { get; set; }




        public List<Naudotojas> getNaudotojas()
        {
            List<Naudotojas> naudotojai = new List<Naudotojas>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM bilietas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                naudotojai.Add(new Naudotojas
                {
                    elpastas = Convert.ToString(item["elpastas"]),
                    slaptazodis = Convert.ToString(item["slaptazodis"]),
                    naudotojo_vardas = Convert.ToString(item["naudotojo_vardas"]),
                    telnr = Convert.ToString(item["telnr"]),
                    id_Naudotojas = Convert.ToInt32(item["id_Naudotojas"])
                });
            }

            return naudotojai;
        }
    }
}