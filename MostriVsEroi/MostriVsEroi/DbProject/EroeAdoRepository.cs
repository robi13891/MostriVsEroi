using BusinessLayer;
using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class EroeAdoRepository : IEroeRepository
    {
        const string connectionString = @"Server=(localdb)\mssqllocaldb;Database=MostriVsEroi;Trusted_Connection=True;";

        public int Inserimento(Eroe eroe)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                string insertCommand = "INSERT INTO EROE" +
                    " VALUES (@NOME,@IDCATEGORIA,@IDARMA,@LIVELLO,@IDUTENTE,@PUNTIACCUMULATI)";

                SqlCommand insert = conn.CreateCommand();
                insert.CommandText = insertCommand;
                insert.CommandType = System.Data.CommandType.Text;
                insert.Parameters.AddWithValue("@NOME", eroe.Nome);
                insert.Parameters.AddWithValue("@LIVELLO", eroe.Livello);
                insert.Parameters.AddWithValue("@IDUTENTE", eroe.Utente.Nickname);
                insert.Parameters.AddWithValue("@PUNTIACCUMULATI", 0);


                insert.Parameters.AddWithValue("@IDCATEGORIA", eroe.Categoria);
                insert.Parameters.AddWithValue("@IDARMA", eroe.Arma.Nome);


                int result = insert.ExecuteNonQuery();
                return result;
            }
        }

        public void Classifica()
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                SqlCommand select = new();
                select.Connection = conn;
                select.CommandType = System.Data.CommandType.Text;
                select.CommandText = "SELECT * FROM EROE"
                    +
                  " ORDER BY PUNTIACCUMULATI DESC";


                SqlDataReader reader = select.ExecuteReader();
                Console.Clear();
                Console.WriteLine("{0,20}{1,15}{2,15}{3,20}", "NOME", "PUNTI", "LIV.", "UTENTE");
                Console.WriteLine(new String('-', 70));

                int count = 0;
                while (reader.Read() && count<=10)
                {
                    count++;
                    Console.WriteLine("{0,20}{1,15}{2,15}{3,20}", reader["NOME"], reader["PUNTIACCUMULATI"], reader["LIVELLO"],reader["IDUTENTE"]);
                }
                reader.Close();

                Console.WriteLine(new String('-', 70));

            }

        }
    

    public int EliminaEroe(Utente utente, Eroe eroeDaEliminare)
    {
        using (SqlConnection conn = new(connectionString))
        {
            conn.Open();
            string deleteCommand = "DELETE FROM EROE" +
                " WHERE NOME = @NOMEEROE AND IDUTENTE = @NICKNAME";

            SqlCommand delete = conn.CreateCommand();
            delete.CommandText = deleteCommand;
            delete.CommandType = System.Data.CommandType.Text;
            delete.Parameters.AddWithValue("@NOMEEROE", eroeDaEliminare.Nome);
            delete.Parameters.AddWithValue("@NICKNAME", utente.Nickname);

            int result = delete.ExecuteNonQuery();
            return result;
        }
    }

    public void AggiornamentoLivello(Utente utente, Eroe eroe)
    {
        using (SqlConnection conn = new(connectionString))
        {
            conn.Open();
            string updateCommand = "UPDATE EROE" +
                " SET PUNTIACCUMULATI = @PUNTI " +
                "WHERE IDUTENTE = @NICKNAME AND NOME=@NOMEEROE";
            SqlCommand update = conn.CreateCommand();
            update.CommandText = updateCommand;
            update.CommandType = System.Data.CommandType.Text;
            update.Parameters.AddWithValue("@NICKNAME", utente.Nickname);
            update.Parameters.AddWithValue("@PUNTI", eroe.PuntiAccumulati);
            update.Parameters.AddWithValue("@NOMEEROE", eroe.Nome);

            int result = update.ExecuteNonQuery();


        }
    }
}
}
