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
            string sqlquery = @"SELECT filmas.id_Filmas, filmas.pavadinimas, filmas.trukme, filmas.aktoriai, filmas.rezisierius, zanrai.name, filmas.aprasymas, filmas.anonsas FROM filmas INNER JOIN zanrai on filmas.zanras = zanrai.id_Zanrai";
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
                    id = Convert.ToInt32(item["id_Filmas"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    trukme = Convert.ToInt32(item["trukme"]),
                    aktoriai = Convert.ToString(item["aktoriai"]),
                    rezisierius = Convert.ToString(item["rezisierius"]),
                    zanras = Convert.ToString(item["name"]),
                    aprasymas = Convert.ToString(item["aprasymas"]),
                    anonsas = Convert.ToString(item["anonsas"]),
                });
            }
            return filmai;
        }

        public bool addMovie(FilmasCreate filmasCreateViewModel)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `filmas`
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
        public List<Filmas> GetHistory()
        {
            List<Filmas> filmai = new List<Filmas>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT filmas.id_Filmas, filmas.pavadinimas, filmas.trukme, filmas.aktoriai, filmas.rezisierius, zanrai.name, filmas.aprasymas, filmas.anonsas FROM filmas INNER JOIN zanrai on filmas.zanras = zanrai.id_Zanrai WHERE id_Filmas IN (SELECT rodymo_laikas.fk_Filmasid_Filmas FROM bilietas INNER JOIN rodymo_laikas ON bilietas.fk_Rodymo_laikasid_Rodymo_laikas = rodymo_laikas.id_Rodymo_laikas)";
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
                    id = Convert.ToInt32(item["id_Filmas"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    trukme = Convert.ToInt32(item["trukme"]),
                    aktoriai = Convert.ToString(item["aktoriai"]),
                    rezisierius = Convert.ToString(item["rezisierius"]),
                    zanras = Convert.ToString(item["name"]),
                    aprasymas = Convert.ToString(item["aprasymas"]),
                    anonsas = Convert.ToString(item["anonsas"]),
                });
            }

            return filmai;
        }
        public List<Filmas> GetActorsAndGenres()
        {
            List<Filmas> filtruoti = GetHistory();
            List<Filmas> filmai = getMovie();
            List<Filmas> aktoriai = new List<Filmas>();

            if (filtruoti.Count == 0)
            {
                for (int k = 0; k < filmai.Count; k++)
                {
                    if (aktoriai.Count <= 10)
                    {
                        aktoriai.Add(filmai[k]);
                    }
                }
                return aktoriai;
            }
            else
            {
                for (int i = 0; i < filtruoti.Count; i++)
                {
                    for (int j = 0; j < filmai.Count; j++)
                    {
                        if ((filtruoti[i].aktoriai == filmai[j].aktoriai || filtruoti[i].zanras == filmai[j].zanras)&& !aktoriai.Contains(filmai[j]) && aktoriai.Count <= 10)
                        {
                            aktoriai.Add(filmai[j]);
                        }
                    }
                }
                return aktoriai;
            }
        }
    }
}