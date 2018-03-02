using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MT2018_v1.Models
{
    public class ConnectDB
    {
        public MySqlConnection db;
        public MySqlCommand q;
        public MySqlDataReader dr;

        public ConnectDB()
        {
            db = new MySqlConnection();
            // Cadena de conexión para la base de datos "montool".
            db.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLmontool"].ConnectionString;
        }

        public List<Structure> ObtenerModelos()
        {
            List<Structure> strs = new List<Structure>();
            try
            {
                db.Open();
                q = db.CreateCommand();
                q.CommandType = System.Data.CommandType.Text;
                q.CommandText = "select id, nombre from estructura order by nombre";
                dr = q.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        strs.Add(new Structure() { Id = dr.GetInt16(0), Nombre = dr.GetString(1) });
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            {
                // ...
            }
            return strs;
        }
    }
}