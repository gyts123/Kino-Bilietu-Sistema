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
using Kino_Bilietu_Sistema.Views.Sale;

namespace Kino_Bilietu_Sistema.Models
{
    public class Sale
    {
        [DisplayName("ID")]

        public int id { get; set; }
        [DisplayName("Pavadinimas")]

        public string pavadinimas { get; set; }
        [DisplayName("Vietų Skaičius")]

        public int vietu_sk { get; set; }



        public bool addSale(SaleCreate saleCreateViewModel)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `kino_sale`
                                    (
                                    `pavadinimas`) 
                                    VALUES (
                                    ?pav)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pav", MySqlDbType.VarChar).Value = saleCreateViewModel.pavadinimas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public int getSaleId()
        {
            int salesId=0;

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT MAX(kino_sale.id_Kino_sale) FROM kino_sale";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                salesId = Convert.ToInt32(item["MAX(kino_sale.id_Kino_sale)"]);
            }

            return salesId;
        }

        public List<Sale> getSales()
        {
            List<Sale> sales = new List<Sale>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT pavadinimas, COUNT(vieta.id_Vieta) as vietu_sk FROM `kino_sale` INNER JOIN `vieta` ON kino_sale.id_Kino_sale = vieta.fk_Kino_saleid_Kino_sale GROUP BY kino_sale.pavadinimas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sales.Add(new Sale
                {
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    vietu_sk = Convert.ToInt32(item["vietu_sk"])
                });
            }

            return sales;
        }

    }
}