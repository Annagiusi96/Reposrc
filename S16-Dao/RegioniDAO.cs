using Microsoft.Data.SqlClient;
using S16_Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S16_Dao;

public class RegioniDAO : AbstractDao<Regione, int>
{
    const string findAllQuery = "select id, nome, latitudine, longitudine from regioni";
    const string countQuery = "select count(*) as conteggio from regioni";
    const string findByIdQuery = "select id, nome, latitudine, longitudine from regioni where id = @IdRegione";

    const string insertQuery = "insert into regioni (id, nome, latitudine, longitudine) values (@idRegione, @nomeRegione, @latitudine, @longitudine)";

    /*
     sqlCmd.Parameters.AddWithValue("@idRegione", 22);
     sqlCmd.Parameters.AddWithValue("@nomeRegione", "nuova regione da definire");
     sqlCmd.Parameters.AddWithValue("@latitudine", 0);
     sqlCmd.Parameters.AddWithValue("@longitudine", 0);
    "insert into regioni (id, nome, latitudine, longitudine) values (22, "nuova regione da definire", 0, 0)";
     */

    public int Count()
    {
        int numeroRegioni = 0;
        SqlConnection connection = getConnection();
        connection.Open();
        SqlCommand sqlCmd = new(countQuery, connection);
        SqlDataReader reader = sqlCmd.ExecuteReader();
        if (reader.Read())
        {
            numeroRegioni = reader.GetInt32(reader.GetOrdinal("conteggio"));
        }

        reader.Close();
        connection.Close();
        return numeroRegioni;
    }


    public List<Regione> FindAll()
    {
        List<Regione> regioni = new();

        SqlConnection connection = getConnection();

        connection.Open();

        SqlCommand sqlCmd = new(findAllQuery, connection);

        SqlDataReader reader = sqlCmd.ExecuteReader();

        while (reader.Read())
        {
            Regione regione = new();
            regione.Id = reader.GetInt32(reader.GetOrdinal("id"));
            regione.Nome = reader.GetString(reader.GetOrdinal("nome"));
            regione.Latitudine = reader.GetDecimal(reader.GetOrdinal("latitudine"));
            regione.Longitudine = reader.GetDecimal(reader.GetOrdinal("longitudine"));
            regioni.Add(regione);
        }

        reader.Close();

        connection.Close();

        return regioni;
    }

    public Regione FindById(int id)
    {   
        SqlConnection connection = getConnection();
        connection.Open();

       // SqlParameter idParameter = new SqlParameter("@IdRegione", System.Data.SqlDbType.Int);

        SqlCommand sqlCmd = new(findByIdQuery, connection);

        // aggiunger il SqlParameter
        sqlCmd.Parameters.AddWithValue("@IdRegione", id);

        SqlDataReader reader = sqlCmd.ExecuteReader();

        Regione regione = null; // new();

        if (reader.Read()) 
        {
            regione = new();
            regione.Id = reader.GetInt32(reader.GetOrdinal("id"));
            regione.Nome = reader.GetString(reader.GetOrdinal("nome"));
            regione.Latitudine = reader.GetDecimal(reader.GetOrdinal("latitudine"));
            regione.Longitudine = reader.GetDecimal(reader.GetOrdinal("longitudine"));
        }

        return regione; // se non trovato ==> allora null
    }


}
