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
    public class MostroAdoRepository : IMostroRepository
    {
        const string connectionString = @"Server=(localdb)\mssqllocaldb;Database=MostriVsEroi;Trusted_Connection=True;";
        public int Inserimento(Mostro mostro)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                string insertCommand = "INSERT INTO MOSTRO" +
                    " VALUES (@NOME,@IDCATEGORIA,@IDARMA,@LIVELLO)";

                SqlCommand insert = conn.CreateCommand();
                insert.CommandText = insertCommand;
                insert.CommandType = System.Data.CommandType.Text;
                insert.Parameters.AddWithValue("@NOME", mostro.Nome);
                insert.Parameters.AddWithValue("@LIVELLO", mostro.Livello);
                insert.Parameters.AddWithValue("@IDCATEGORIA", mostro.Categoria);
                insert.Parameters.AddWithValue("@IDARMA", mostro.Arma.Nome);


                int result = insert.ExecuteNonQuery();
                return result;
            }
        }

        public Mostro MostroRandom(Eroe eroe)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                string selectCommand = "SELECT * FROM MOSTRO";

                SqlCommand select = conn.CreateCommand();
                select.CommandText = selectCommand;
                select.CommandType = System.Data.CommandType.Text;

                SqlDataReader reader = select.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                reader.Close();

                Random r = new Random();
                int randomIndex = r.Next(1, count + 1);

                Mostro mostroRandom = new Mostro();
                Arma arma = new Arma();

                reader = select.ExecuteReader();
                int count2 = 0;
                while (reader.Read())
                {
                    count2++;
                    if (count2 == randomIndex)
                    {
                        mostroRandom.Nome = reader.GetString(1);

                        mostroRandom.Livello = (Personaggio.livello)reader.GetInt32(4);

                        mostroRandom.Categoria=(Personaggio.categoria)reader.GetInt32(2);
                        
                        arma.Nome = (Arma.nomeArma)reader.GetInt32(3);                        

                    }
                    
                }
                reader.Close();

                string selectCommand3 = "SELECT * FROM ARMA WHERE NOME = @NOMEARMA";
                SqlCommand select3 = conn.CreateCommand();
                select3.CommandText = selectCommand3;
                select3.CommandType = System.Data.CommandType.Text;

                select3.Parameters.AddWithValue("@NOMEARMA", arma.Nome);


                reader = select.ExecuteReader();
                int count1 = 0;
                while (reader.Read())
                {
                    count1++;
                    if (count1 == randomIndex)
                    {
                        arma.PuntiDanno = reader.GetInt32(2);
                    }
                }

                mostroRandom.Arma = arma;
                return mostroRandom;


            }
        }


    }
}

