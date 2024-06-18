using Microsoft.Data.SqlClient;
using S13_SqlUtilizzo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S15_RegioniDao;

public class RegioniDAO : DAO<Regione, int> //implementa interfaccia dao. Gestisci le nostre regioni in qst modo
{
    const string findAllQuery = "select id, nome, latitudine, longitudine from regioni";
    const string countQuery = "select count(*) as Conteggio from regioni";
    const string findByIdQuery = "select id,  nome, latitudine, longitudine from regioni where id = @IdRegione";
    //@id necessità di un parametro esterno. La query diventa parametrica

    //esempio parametri
    const string insertQuery = "insert into regioni (id, nome, latitudine, longitudine) " +
                               "values (@IdRegione, @nomeRegione, @latitudine, @longitudine)";

    /*
     sqlCmd.Parametres.AddWithValue("@idRegione",22);
     sqlCmd.Parametres.AddWithValue("@nomeRegione","nuona regione");
     sqlCmd.Parametres.AddWithValue("@latitudine", 0);
     sqlCmd.Parametres.AddWithValue("@longitudine", 0);

    in qst modo formatta la stringa di inserimento in maniera tale da:
                                "insert into regioni (id, nome, latitudine, longitudine) " +
                                 "values (22, "nuona regione", 0, 0)";
     */
    public int Count()
    {
        int numeroRegioni = 0;
        SqlConnection connection = GetConnection();

        connection.Open();

        SqlCommand sqlCmd = new(countQuery, connection);
        SqlDataReader reader = sqlCmd.ExecuteReader();

        if (reader.Read())
        {
            //numeroRegioni = reader.GetInt32(0); //la count(*) ritorna una riga sola quindi usiamo if anziche while
            numeroRegioni = reader.GetInt32(reader.GetOrdinal("Conteggio")); //si va a prendere la colonna 
        }

        return numeroRegioni;
    }

    //la regione in input al metodo 

    public Regione Create(string nome, decimal latitudine, decimal longitudine) { return null; }
    public Regione Create(Regione entity) //passo un ogetto perchè è un contenitore che mi fa comodo anziche elencare tutto come sopra
    {
        //quando entra non è un entity, quando esce è un entity
        entity.Id = 45;
        //oppure
        Regione r3 = new();
        r3.Id = 45;
        r3.Nome = entity.Nome;
        r3.Latitudine = entity.Latitudine;
        r3.Longitudine = entity.Longitudine;

        return r3; // in qst modo mi ritorna un nuovo oggetto aggiornato con le modifiche
        
        //lo stesso ogg che ho in ingresso lo tengo anche in uscita
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Regione> FindAll()
    {
        List<Regione> regioni = new();//creo una lista di regioni vuota e la ritorno fuori

        SqlConnection connection = GetConnection();


        connection.Open();


        SqlCommand sqlCmd = new(findAllQuery, connection); 

        
        SqlDataReader reader = sqlCmd.ExecuteReader(); 

        while (reader.Read())
        {
           
            Regione regione = new();
            regione.Id = reader.GetInt32(reader.GetOrdinal("id"));//reader.GetOrdinal("id")
            regione.Nome = reader.GetString(reader.GetOrdinal("nome")); //reader.GetOrdinal("nome")
            regione.Latitudine = reader.GetDecimal(reader.GetOrdinal("latitudine")); //reader.GetOrdinal("latitudine")
            regione.Longitudine = reader.GetDecimal(reader.GetOrdinal("longitudine")); //reader.GetOrdinal("longitudine")
            regioni.Add(regione);
        }


        reader.Close(); 

        connection.Close(); 

        return regioni;
    }

    public Regione FindById(int id)
    {
        Regione regione = null;// new Regione();

        SqlConnection connection = GetConnection();
        connection.Open();

        SqlParameter idParameter = new SqlParameter("@IdRegione", System.Data.SqlDbType.Int); //dobb dare il tipo SQL del dato

        SqlCommand sqlCmd = new(findByIdQuery, connection);

        // aggiungere il SqlParameter
        //aggiunta parametri direttamente alla query
        sqlCmd.Parameters.AddWithValue("@IdRegione",id);
        //il sqlCmd contiene una struttura dati parametres a cui aggiungiamo per valore

        SqlDataReader reader = sqlCmd.ExecuteReader();

        if(reader.Read())
        {
            regione = new();
            regione.Id = reader.GetInt32(reader.GetOrdinal("id"));//usiamo i nomi delle colonne e non gli indici che puntano alle colonne
            regione.Nome = reader.GetString(reader.GetOrdinal("nome")); 
            regione.Latitudine = reader.GetDecimal(reader.GetOrdinal("latitudine")); 
            regione.Longitudine = reader.GetDecimal(reader.GetOrdinal("longitudine")); 
        }

        return regione; //se non trovato allora dà null
    }

    public void Update(Regione entity)
    {
        throw new NotImplementedException();
    }

    //qst metodo incapsula la creazione della connessione
    private SqlConnection GetConnection()
    {

        string serverName = "LAPTOP-V77R6E37\\SQLEXPRESS";

        string database = "pinkacademy";

        string connectionString = $"Server ={serverName}; Database ={database}; TrustServerCertificate = True;";

        string windowsConnectionString = $"{connectionString}; Integrated Security = True;";

        return new(windowsConnectionString); //ritorna una nuova connessione
    }
}
