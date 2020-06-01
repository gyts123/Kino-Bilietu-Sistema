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
    public class Vieta
    {
        public int id { get; set; }
        public int eilesnr {get; set;}
        public int vietosnr { get; set; }
        public double kaina { get; set; }
        public string vietostipas { get; set; }
        public int salespavadinimas { get; set; }


        public bool addVietos(SaleCreate saleCreateViewModel, int SaleId)
        {
            for (int i=0; i<saleCreateViewModel.eiles_nr.Length; i++) {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO `vieta`
                                        (
                                        `eiles_nr`,
                                        `vietos_nr`,
                                        `vietos_tipas`,
                                        `kaina`,
                                        `fk_Kino_saleid_Kino_sale`) 
                                        VALUES (
                                        ?eil,
                                        ?vt,
                                        ?tipas,
                                        ?kaina,
                                        ?salesId)";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?eil", MySqlDbType.Int32).Value = saleCreateViewModel.eiles_nr[i];
                mySqlCommand.Parameters.Add("?vt", MySqlDbType.Int32).Value = saleCreateViewModel.vietos_nr[i];
                mySqlCommand.Parameters.Add("?tipas", MySqlDbType.Int32).Value = saleCreateViewModel.vietos_tipas[i];
                mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Float).Value = saleCreateViewModel.kaina[i];
                mySqlCommand.Parameters.Add("?salesId", MySqlDbType.Int32).Value = SaleId;
                
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

            }
            return true;
        }

        public List<Vieta> getVieta()
        {
            List<Vieta> vietos = new List<Vieta>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"Select vieta.id_Vieta, vieta.eiles_nr, vieta.vietos_nr, vieta.kaina, vietu_tipai.name, kino_sale.id_Kino_sale FROM vieta INNER JOIN vietu_tipai ON vieta.vietos_tipas = vietu_tipai.id_Vietu_tipai INNER JOIN kino_sale ON vieta.fk_Kino_saleid_Kino_sale = kino_sale.id_Kino_sale";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                vietos.Add(new Vieta
                {
                    id = Convert.ToInt32(item["id_Vieta"]),
                    eilesnr = Convert.ToInt32(item["eiles_nr"]),
                    vietosnr = Convert.ToInt32(item["vietos_nr"]),
                    kaina = Convert.ToDouble(item["kaina"]),
                    vietostipas = Convert.ToString(item["name"]),
                    salespavadinimas = Convert.ToInt32(item["id_Kino_sale"])
                });
            }
            return vietos;
        }
    }


}