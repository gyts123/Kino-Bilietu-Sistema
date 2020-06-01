using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Kino_Bilietu_Sistema.Models
{
    public class Saskaita
    {
        public int pavedimoNr { get; set; }
        public double visakaina { get; set; }
        public int id { get; set; }
        public string elpastas { get; set; }

        public List<Saskaita> getSaskaita()
        {
            List<Saskaita> saskaita = new List<Saskaita>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT pavedimoNr, visa_kaina, id_Saskaita, naudotojas.elpastas  FROM `saskaita` INNER JOIN `naudotojas` ON saskaita.fk_Naudotojasid_Naudotojas = naudotojas.id_Naudotojas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                saskaita.Add(new Saskaita
                {
                    pavedimoNr = Convert.ToInt32(item["pavedimoNr"]),
                    visakaina = Convert.ToDouble(item["visa_kaina"]),
                    id = Convert.ToInt32(item["id_Saskaita"]),
                    elpastas = Convert.ToString(item["elpastas"])
                });
            }

            return saskaita;
        }
    }
}