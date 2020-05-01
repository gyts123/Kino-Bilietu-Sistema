using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Kino_Bilietu_Sistema.Models
{
    public class Filmas
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("Trukmė")]
        public int trukme { get; set; }
        [DisplayName("Aktoriai")]
        public string aktoriai { get; set; }
        [DisplayName("Režisierius")]
        public string rezisierius { get; set; }
        [DisplayName("Žanras")]
        public string zanras { get; set; }
        [DisplayName("Aprašymas")]
        public string aprasymas { get; set; }
        [DisplayName("Anonsas")]
        public string anonsas { get; set; }

        public List<Filmas> getMovie()
        {
            List<Filmas> filmai = new List<Filmas>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT movie.id, movie.pavadinimas, movie.trukme, movie.aktoriai, movie.rezisierius, zanrai.pav, movie.aprasymas, movie.anonsas FROM movie INNER JOIN zanrai on movie.zanras = zanrai.id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                filmai.Add(new Filmas
                {
                    id = Convert.ToInt32(item["id"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    trukme = Convert.ToInt32(item["trukme"]),
                    aktoriai = Convert.ToString(item["aktoriai"]),
                    rezisierius = Convert.ToString(item["rezisierius"]),
                    zanras = Convert.ToString(item["pav"]),
                    aprasymas = Convert.ToString(item["aprasymas"]),
                    anonsas = Convert.ToString(item["anonsas"]),
                });
            }

            return filmai;
        }
    }

    

}