using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using MySql.Data.MySqlClient;

namespace Kino_Bilietu_Sistema.Models
{
    public class Bilietas
    {
        public bool ar_panaudotas { get; set; }
        public int amziaus_cenzas { get; set; }
        public bool ar_užrezervuotas { get; set; }
        public int id_Bilietas { get; set; }
        public DateTime Rodymo_laikas_id_rodymo_laikas { get; set; }
        public string filmopradlaikas { get; set; }
        public int salesid { get; set; }
        public int Eilės_nr { get; set; }
        public int Vietos_nr { get; set; }
        public double Kaina { get; set; }





        public List<Bilietas> getBilietas()
        {
            List<Bilietas> bilietai = new List<Bilietas>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT bilietas.ar_panaudotas, bilietas.amziaus_cenzas, bilietas.ar_užrezervuotas, bilietas.id_Bilietas, rodymo_laikas.laikas,rodymo_laikas.filmo_prad_laik, vieta.eiles_nr, vieta.vietos_nr,vieta.fk_Kino_saleid_Kino_sale, saskaita.visa_kaina FROM bilietas INNER JOIN rodymo_laikas ON bilietas.fk_Rodymo_laikasid_Rodymo_laikas = rodymo_laikas.id_rodymo_laikas INNER JOIN vieta ON bilietas.fk_Vietaid_Vieta = vieta.id_Vieta INNER JOIN saskaita ON bilietas.fk_Saskaitaid_Saskaita = saskaita.id_Saskaita";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                bilietai.Add(new Bilietas
                {
                    ar_panaudotas = Convert.ToBoolean(item["ar_panaudotas"]),
                    amziaus_cenzas = Convert.ToInt32(item["amziaus_cenzas"]),
                    ar_užrezervuotas = Convert.ToBoolean(item["ar_užrezervuotas"]),
                    id_Bilietas = Convert.ToInt32(item["id_Bilietas"]),
                    Rodymo_laikas_id_rodymo_laikas = Convert.ToDateTime(item["laikas"]),
                    filmopradlaikas = Convert.ToString(item["filmo_prad_laik"]),
                    Eilės_nr = Convert.ToInt32(item["eiles_nr"]),
                    Vietos_nr = Convert.ToInt32(item["vietos_nr"]),
                    salesid = Convert.ToInt32(item["fk_Kino_saleid_Kino_sale"]),
                    Kaina = Convert.ToDouble(item["visa_kaina"])
                });
            }

            return bilietai;
        }
    }
}