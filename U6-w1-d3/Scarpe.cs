using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
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
                if(scarpa.Immagine==null) { scarpa.Immagine = ""; }
                if (scarpa.ImmaginiAggiuntiva1 == null) { scarpa.ImmaginiAggiuntiva1 = ""; }
                if (scarpa.ImmaginiAggiuntiva2 == null) { scarpa.ImmaginiAggiuntiva2 = ""; }
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
                        );
                    scarpe.Add(scarpa);
                }
                return scarpe;
            }
            catch { return new List<Scarpa>(); }
            finally { conn.Close(); }
        }

        public static void delete(int id)
        {
            conn.Open();
            string deleteQuery = "DELETE FROM scarpe WHERE IdScarpa = @IdScarpa ";
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("IdScarpa ", id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void elimica(Scarpa scarpa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE scarpe SET  NomeArticolo=@NomeArticolo, Prezzo=@Prezzo, Descrizione= @Descrizione ,Immagine=@Immagine, ImmaginiAggiuntiva1=@ImmaginiAggiuntiva1 , ImmaginiAggiuntiva2=@ImmaginiAggiuntiva2 where IdScarpa = @IdScarpa";
            cmd.Parameters.AddWithValue("NomeArticolo", scarpa.NomeArticolo);
            cmd.Parameters.AddWithValue("Prezzo", Convert.ToDecimal(scarpa.Prezzo));
            cmd.Parameters.AddWithValue("Descrizione", scarpa.Descrizione);
            cmd.Parameters.AddWithValue("Immagine", scarpa.Immagine);
            cmd.Parameters.AddWithValue("ImmaginiAggiuntiva1", scarpa.ImmaginiAggiuntiva1);
            cmd.Parameters.AddWithValue("ImmaginiAggiuntiva2", scarpa.ImmaginiAggiuntiva2);
            cmd.Parameters.AddWithValue("IdScarpa", scarpa.Id);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}