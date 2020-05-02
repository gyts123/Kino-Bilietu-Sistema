using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Kino_Bilietu_Sistema.Views.Filmas;

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

        public bool addAuto(FilmasCreate filmasCreateViewModel)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `movie`
                                    (
                                    `pavadinimas`,
                                    `trukme`,
                                    `aktoriai`,
                                    `rezisierius`,
                                    `zanras`,
                                    `aprasymas`,
                                    `anonsas`) 
                                    VALUES (
                                    ?pav,
                                    ?truk,
                                    ?aktoriai,
                                    ?rez,
                                    ?zanras,
                                    ?apras,
                                    ?anons)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pav", MySqlDbType.VarChar).Value = filmasCreateViewModel.pavadinimas;
            mySqlCommand.Parameters.Add("?truk", MySqlDbType.Int32).Value = filmasCreateViewModel.trukme;
            mySqlCommand.Parameters.Add("?aktoriai", MySqlDbType.VarChar).Value = filmasCreateViewModel.aktoriai;
            mySqlCommand.Parameters.Add("?rez", MySqlDbType.VarChar).Value = filmasCreateViewModel.rezisierius;
            mySqlCommand.Parameters.Add("?zanras", MySqlDbType.Int32).Value = filmasCreateViewModel.zanras;
            mySqlCommand.Parameters.Add("?apras", MySqlDbType.VarChar).Value = filmasCreateViewModel.aprasymas;
            mySqlCommand.Parameters.Add("?anons", MySqlDbType.VarChar).Value = filmasCreateViewModel.anonsas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }
    }

    

}