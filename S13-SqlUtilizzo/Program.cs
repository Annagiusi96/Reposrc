using Microsoft.Data.SqlClient;

namespace S13_SqlUtilizzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serverName = "LAPTOP-V77R6E37\\SQLEXPRESS";

            //definire db che utilizzeremo:
            string database = "pinkacademy";

            //comporre una connection string:
            string connectionString = $"Server ={serverName}; Database ={database}; TrustServerCertificate = True;";

            //per windows
            string windowsConnectionString = $"{connectionString}; Integrated Security = True;";

            //usiamo nuGet per installare microsoft installa i pacchetti all'interno della soluzione
            SqlConnection connection = new(windowsConnectionString);

            //esempi esecuzione query

            string sqlQuery = "select id, nome, latitudine, longitudine from regioni";

            //apertura della connessione
            connection.Open();
            //la connessione è come un tubo che dobbiamo aprire per far passare i dati

            //per eseguirla realizziamo un sql command:
            //prepariamo oggetto di tipo comando sql

            SqlCommand sqlCmd = new(sqlQuery, connection); //abbiamo creato la connessione
            //abbiamo impacchettato il nostro sql chiamando qst pacchetto di dati SqlCommand

            //quello che viene restituito è un instanza di SqlDataReader (tabella ritrovarta tramite la select)
            SqlDataReader reader = sqlCmd.ExecuteReader(); //andiamo ad eseguirlo

    

            //mi serve un contenitore che tenga tutte le regioni 

            List<Regione> regioni = new();

            while (reader.Read())
            {
                //possiamo creare la regione con due modi
                Regione regione = new(); //creo la regione e poi la riempio
                //oppure
                //faccio lavorare costruttore di default
                //new(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3)); (costruttore facoltativo)
                regione.ID = reader.GetInt32(0);
                regione.NomeRegione = reader.GetString(1);
                regione.Latitudine = reader.GetDecimal(2);
                regione.Longitudine = reader.GetDecimal(3);
                regioni.Add(regione);
            }


            //chiudiamo il reader
            reader.Close(); //butto la tabella temporanea che avevo

            //chiudiamo connessione
            connection.Close(); //chiudo oggetto che mi era servito da tubo

            Console.WriteLine($"Trovate {regioni.Count} regioni");

            foreach (Regione item in regioni)
            {
                Console.WriteLine(item.NomeRegione);
            }

            //Abbiamo realizzato un "traduttore" tra tabella sql e mondo ad oggetti
            //il ponte tra questi due è la List di oggetti di tipo entità che vengono trasportati (List<Regione>)
        }
    }
}
