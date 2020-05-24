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
                                        `fk_Kino_saleid_Kino_sale`) 
                                        VALUES (
                                        ?eil,
                                        ?vt,
                                        ?tipas,
                                        ?salesId)";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?eil", MySqlDbType.Int32).Value = saleCreateViewModel.eiles_nr[i];
                mySqlCommand.Parameters.Add("?vt", MySqlDbType.Int32).Value = saleCreateViewModel.vietos_nr[i];
                mySqlCommand.Parameters.Add("?tipas", MySqlDbType.Int32).Value = saleCreateViewModel.vietos_tipas[i];
                mySqlCommand.Parameters.Add("?salesId", MySqlDbType.Int32).Value = SaleId;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

            }
            return true;
        }
    }


}