using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Entities;
using BusinessLayer.Interfaces;

namespace DbProject
{
    public class UtenteAdoRepository : IUtenteRepository
    {
        const string connectionString = @"Server=(localdb)\mssqllocaldb;Database=MostriVsEroi;Trusted_Connection=True;";
        public int Inserimento(Utente utente)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                string insertCommand = "INSERT INTO UTENTE" +
                    " VALUES (@NICKNAME,@PASSWORD,@ADMIN)";
                SqlCommand insert = conn.CreateCommand();
                insert.CommandText = insertCommand;
                insert.CommandType = System.Data.CommandType.Text;
                insert.Parameters.AddWithValue("@NICKNAME", utente.Nickname);
                insert.Parameters.AddWithValue("@PASSWORD", utente.Password);
                insert.Parameters.AddWithValue("@ADMIN", 0);
                int result = insert.ExecuteNonQuery();
                return result;

            }
        }

        public void AggiornaAdmin(Utente utente)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                string updateCommand = "UPDATE UTENTE" +
                    " SET ADMIN = @ADMIN " +
                    "WHERE NICKNAME = @NICKNAME";
                SqlCommand update = conn.CreateCommand();
                update.CommandText = updateCommand;
                update.CommandType = System.Data.CommandType.Text;
                update.Parameters.AddWithValue("@NICKNAME", utente.Nickname);
                int admin=0;
                if (utente.Admin) admin = 1;
                else if (!utente.Admin) admin = 0;
                update.Parameters.AddWithValue("@ADMIN", admin);
                int result = update.ExecuteNonQuery();
                

            }
        }

        public Eroe GetEroe(int idEroeScelto, Utente utente)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                Eroe eroeScelto = new Eroe();
                Arma arma = new Arma();

                SqlCommand select = new();
                select.Connection = conn;
                select.CommandType = System.Data.CommandType.Text;
                select.CommandText = "SELECT * FROM EROE"
                    +
                  " WHERE IDUTENTE = @IDUTENTE AND ID = @IDEROESCELTO";
                select.Parameters.AddWithValue("@IDUTENTE", utente.Nickname);
                select.Parameters.AddWithValue("@IDEROESCELTO", idEroeScelto);
                
                SqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {

                    eroeScelto.Utente = utente;
                    eroeScelto.Nome = reader.GetString(1);
                    int idCategoria = reader.GetInt32(2);
                    eroeScelto.Categoria = (Personaggio.categoria)idCategoria;
                    int idArma = reader.GetInt32(3);
                    arma.Nome = (Arma.nomeArma)idArma;
                    int idLivello = reader.GetInt32(4);
                    eroeScelto.Livello = (Personaggio.livello)idLivello;
                    eroeScelto.PuntiAccumulati = reader.GetInt32(6);
                }
                reader.Close();
                
                SqlCommand select2 = new();
                select2.Connection = conn;
                select2.CommandType = System.Data.CommandType.Text;
                select2.CommandText = "SELECT * FROM ARMA"
                    +
                  " WHERE ID = @ID";
               
                select2.Parameters.AddWithValue("@ID", (int)arma.Nome);

                SqlDataReader reader2 = select2.ExecuteReader();
                while (reader2.Read())
                {
                    arma.PuntiDanno = reader2.GetInt32(2);
                }
                eroeScelto.Arma = arma;
                return eroeScelto;

            }
        }

        public int VerificaCredenziali(Utente utente)
        {


            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();


                SqlCommand select = new();
                select.Connection = conn;
                select.CommandType = System.Data.CommandType.Text;
                select.CommandText = "SELECT * FROM UTENTE"
                    +
                  " WHERE NICKNAME = @NICKNAME";
                select.Parameters.AddWithValue("@NICKNAME", utente.Nickname);


                SqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {

                    string password = reader.GetString(1);
                    if (password == utente.Password)
                    {
                        bool admin = reader.GetBoolean(2);
                        if (admin == false) return 1;
                        else return 2;
                    }
                    else return 0;
                }
                return 0;



            }
        }


        public bool ElencoEroi(Utente utente)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                SqlCommand select = new();
                select.Connection = conn;
                select.CommandType = System.Data.CommandType.Text;
                select.CommandText = "SELECT * FROM EROE"
                    +
                  " WHERE IDUTENTE = @IDUTENTE";
                select.Parameters.AddWithValue("@IDUTENTE", utente.Nickname);


                bool noHero = false;

                SqlDataReader reader = select.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                reader.Close();
                if (count == 0)
                {
                    noHero = true;
                }
                else
                {
                    reader = select.ExecuteReader();
                    while (reader.Read())
                    {

                        Console.Clear();
                        Console.WriteLine("{0,10}{1,20}{2,10}", "ID", "NOME", "LIV.");
                        Console.WriteLine(new String('-', 40));
                        Console.WriteLine("{0,10}{1,20}{2,10}", reader["ID"], reader["NOME"], reader["LIVELLO"]);
                        Console.WriteLine(new String('-', 40));
                    }
                }
                
                return noHero;               

            }

        }

    }
}
