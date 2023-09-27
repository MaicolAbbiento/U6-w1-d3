using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using U6_w1_d3.Models;

namespace U6_w1_d3
{
    public static class Scarpe
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
        private static readonly SqlConnection conn = new SqlConnection(connectionString);

        public static void addscarpa(Scarpa scarpa)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO scarpe  VALUES (@NomeArticolo, @Prezzo, @Descrizione , @Immagine, @ImmaginiAggiuntiva1, @ImmaginiAggiuntiva2 )", conn);
                cmd.Parameters.AddWithValue("NomeArticolo", scarpa.NomeArticolo);

                cmd.Parameters.AddWithValue("Prezzo", Convert.ToDecimal(scarpa.Prezzo));
                cmd.Parameters.AddWithValue("Descrizione", scarpa.Descrizione);
                cmd.Parameters.AddWithValue("Immagine", scarpa.Immagine);
                cmd.Parameters.AddWithValue("ImmaginiAggiuntiva1", scarpa.ImmaginiAggiuntiva1);
                cmd.Parameters.AddWithValue("immaginiAggiuntiva2", scarpa.ImmaginiAggiuntiva2);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Scarpa> getScarpe()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from scarpe", conn);
                SqlDataReader sqlDataReader;
                conn.Open();
                List<Scarpa> scarpe = new List<Scarpa>();
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Scarpa scarpa = new Scarpa(
                           Convert.ToInt32(sqlDataReader["Idscarpa"]),
                           sqlDataReader["nomeArticolo"].ToString(),
                           Convert.ToDecimal(sqlDataReader["prezzo"]),
                           sqlDataReader["descrizione"].ToString(),
                           sqlDataReader["immagine"].ToString(),
                           sqlDataReader["ImmaginiAggiuntiva1"].ToString(),
                           sqlDataReader["ImmaginiAggiuntiva2"].ToString()
                           true
                        );
                    scarpe.Add(scarpa);
                }
                return scarpe;
            }
            catch { return new List<Scarpa>(); }
            finally { conn.Close(); }
        }
    }
}