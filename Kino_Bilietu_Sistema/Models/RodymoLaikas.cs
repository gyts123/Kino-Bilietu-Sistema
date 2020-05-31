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

        public DateTime laikas { get; set; }
        [DisplayName("Filmas")]

        public string filmas { get; set; }

        public int filmas_id { get; set; }
        [DisplayName("Kina sale")]

        public int kinoSale_id { get; set; }
        [DisplayName("Filmo prad laikas")]

        public int filmo_prad_laik { get; set; }

        public bool insertAndUpdate(ShowTimeCreate ShowTimeViewModel)
        {
            List<RodymoLaikas> items = SelectRepertory();
            for (int i = 0; i < ShowTimeViewModel.fk_Filmasid_Filmas.Length; i++) {
                bool notInsert = false;
                for (int j = 0; j < items.Count-1; j++)
                {
                    string data = items[j].laikas.ToString("yyyy-MM-dd");
                    if (ShowTimeViewModel.filmo_prad_laik[i] == items[j].filmo_prad_laik &&
                        ShowTimeViewModel.laikas[i] == data &&
                        ShowTimeViewModel.fk_Kino_saleid_Kino_sale[0] == items[j].kinoSale_id &&
                        ShowTimeViewModel.fk_Filmasid_Filmas[i] != 0)
                    {
                        string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                        MySqlConnection mySqlConnection = new MySqlConnection(conn);
                        string sqlquery = @"UPDATE `rodymo_laikas` SET `fk_Filmasid_Filmas` = ?fk_Filmasid_Filmas WHERE laikas=?laikas AND fk_Kino_saleid_Kino_sale= ?fk_Kino_saleid_Kino_sale AND filmo_prad_laik = ?filmo_prad_laik";
                        MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                        mySqlCommand.Parameters.Add("?laikas", MySqlDbType.Date).Value = ShowTimeViewModel.laikas[i];
                        mySqlCommand.Parameters.Add("?fk_Filmasid_Filmas", MySqlDbType.Int32).Value = ShowTimeViewModel.fk_Filmasid_Filmas[i];
                        mySqlCommand.Parameters.Add("?fk_Kino_saleid_Kino_sale", MySqlDbType.Int32).Value = ShowTimeViewModel.fk_Kino_saleid_Kino_sale[0];
                        mySqlCommand.Parameters.Add("?filmo_prad_laik", MySqlDbType.Int32).Value = ShowTimeViewModel.filmo_prad_laik[i];
                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();
                        mySqlConnection.Close();

                        notInsert = true;
                    }

                }
                if (!notInsert)
                {
                    if (ShowTimeViewModel.fk_Filmasid_Filmas[i] != 0)
                    {

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
            }
            return true;
        }
        public bool Update(ShowTimeCreate ShowTimeViewModel)
        {
            return true;
        }
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
        public List<RodymoLaikas> SelectRepertory()
        {
            List<RodymoLaikas> rodymolaikai = new List<RodymoLaikas>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT rodymo_laikas.laikas, rodymo_laikas.id_Rodymo_laikas, rodymo_laikas.fk_Filmasid_Filmas, rodymo_laikas.fk_Kino_saleid_Kino_sale, rodymo_laikas.filmo_prad_laik, filmas.pavadinimas FROM `rodymo_laikas` INNER JOIN `filmas` on filmas.id_Filmas = rodymo_laikas.fk_Filmasid_Filmas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                rodymolaikai.Add(new RodymoLaikas
                {
                    laikas = Convert.ToDateTime(item["laikas"]),
                    id = Convert.ToInt32(item["id_Rodymo_laikas"]),
                    filmas_id = Convert.ToInt32(item["fk_Filmasid_Filmas"]),
                    kinoSale_id = Convert.ToInt32(item["fk_Kino_saleid_Kino_sale"]),
                    filmo_prad_laik = Convert.ToInt32(item["filmo_prad_laik"]),
                    filmas = Convert.ToString(item["pavadinimas"]),
                });
            }

            return rodymolaikai;
        }
    }
}