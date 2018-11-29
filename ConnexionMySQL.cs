using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ProjetAirAtlantique
{
    class ConnexionMySQL
    {
        private MySqlConnection connexion;
        private string server;
        private string database;
        private string user;
        private string password;


        public Boolean OpenConnection()
        {
            server = "localhost";
            database = "dba_air_atlantique";
            user = "dba_air_atlantique";
            password = "soosabharrt2ld";
            string connectionString = "SERVER=" + server + ";" +
                                      "DATABASE=" + database + ";" +
                                      "UID=" + user + ";" +
                                      "PASSWORD=" + password + ";";

            connexion = new MySqlConnection(connectionString);

            connexion.Open();

            return true;
        }

        public List<AvionBinder> SelectAvions()
        {
            List<AvionBinder> ListAvions = new List<AvionBinder>();

            string query = "SELECT * FROM avions;";
            MySqlCommand cmd = new MySqlCommand(query, connexion);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AvionBinder a = new AvionBinder(reader.GetString(0), reader.GetString(1));
                ListAvions.Add(a);
            }
            return ListAvions;
        }
    }
}
