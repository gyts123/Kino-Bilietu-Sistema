using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Kino_Bilietu_Sistema.Models
{
    public class FilmoPradlaikai
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<FilmoPradlaikai> getFilmoPradLaikai()
        {
            List<FilmoPradlaikai> laikai = new List<FilmoPradlaikai>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT id_FilmoPradLaikai, name FROM filmopradlaikai";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                laikai.Add(new FilmoPradlaikai
                {
                    id = Convert.ToInt32(item["id_FilmoPradLaikai"]),
                    name = Convert.ToString(item["name"])
                });
            }

            return laikai;
        }
    }
}