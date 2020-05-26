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
using Kino_Bilietu_Sistema.Views.ShowTime;

namespace Kino_Bilietu_Sistema.Models
{
    public class RodymoLaikas
    {
        [DisplayName("ID")]

        public int id { get; set; }
        [DisplayName("Pavadinimas")]

        public string laikas { get; set; }
        [DisplayName("Filmas")]

        public string filmas { get; set; }

        [DisplayName("Kina sale")]

        public string kinoSale { get; set; }
        [DisplayName("Filmo prad laikas")]

        public int filmo_prad_laik { get; set; }

        public bool Insert(ShowTimeCreate ShowTimeViewModel)
        {
            for (int i = 0; i < ShowTimeViewModel.fk_Filmasid_Filmas.Length; i++)
            {
                if (ShowTimeViewModel.fk_Filmasid_Filmas[i] != 0) {

                    string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                    MySqlConnection mySqlConnection = new MySqlConnection(conn);
                    string sqlquery = @"INSERT INTO `rodymo_laikas`
                                    (
                                    `laikas`,
                                    `fk_Filmasid_Filmas`,
                                    `fk_Kino_saleid_Kino_sale`,
                                    `filmo_prad_laik`) 
                                    VALUES (
                                    ?laikas,
                                    ?fk_Filmasid_Filmas,
                                    ?fk_Kino_saleid_Kino_sale,
                                    ?filmo_prad_laik)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                    mySqlCommand.Parameters.Add("?laikas", MySqlDbType.Date).Value = ShowTimeViewModel.laikas[i];
                    mySqlCommand.Parameters.Add("?fk_Filmasid_Filmas", MySqlDbType.Int32).Value = ShowTimeViewModel.fk_Filmasid_Filmas[i];
                    mySqlCommand.Parameters.Add("?fk_Kino_saleid_Kino_sale", MySqlDbType.Int32).Value = ShowTimeViewModel.fk_Kino_saleid_Kino_sale[0];
                    mySqlCommand.Parameters.Add("?filmo_prad_laik", MySqlDbType.Int32).Value = ShowTimeViewModel.filmo_prad_laik[i];
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    mySqlConnection.Close();
                }
            }
            return true;
        }
    }
}