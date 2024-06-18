using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ConsoleApp1
{
    public class Program
    {
        //https://learn.microsoft.com/en-us/answers/questions/1344525/having-issue-with-keyword-not-supported-trust-serv
        //https://stackoverflow.com/questions/70728906/keyword-not-supported-trusted-connection-parameter-keyword
        //https://www.connectionstrings.com/
        static void Main(string[] args)
        {
            string serverName = "LAPTOP-V77R6E37\\SQLEXPRESS";//"localhost"; //”pc_name\SQLEXPRESS” (qst nome funziona solo per macchine windows

            //definire db che utilizzeremo:
            string database = "pinkacademy";

            //dbbiamo comporre una connection string:

            string connectionString = $"Server ={serverName}; Database ={database}; TrustServerCertificate = True;"; //flag che inseriamo su sql 

            //TrustServerCertificate = True corrisponde Windows Autentication indipendentemente dal server

            //per windows
            string windowsConnectionString = $"{connectionString}; Integrated Security = True;";

            //per docker
            string userName = "allieva";
            string password = "@@C202405";
            string dockerConnectionString = $"{connectionString}; User id = {userName}; Password = {password}";

            //i driver prendono la connection string e si collegano col server 
            //realizzando una tubazione bidirezionale (ti mando i comandi e mi tiri giù i dati)

            //nuget installa i pacchetti all'interno della soluzione (micorsoft.data.sqlClient)
            SqlConnection connection = new(windowsConnectionString);

            //esempi esecuzione query

            string sqlQuery = "select id, nome, latitudine, longitudine from regioni";

            //apertura della connessione
            connection.Open();
            //la connessione è come un tubo che dobbiamo aprire per far passare i dati

            //per eseguirla realizziamo un sql command:
            //prepariamo oggetto di tipo comando sql

            //sqlcommand -> rappresentaz a oggetto di una select (seleziono la query e la esegue)
            SqlCommand sqlCmd = new(sqlQuery, connection); //abbiamo creato la connessione
            //abbiamo impacchettato il nostro sql chiamando qst pacchetto di dati SqlCommand

            //quello che viene restituito è un instanza di SqlDataReader (tabella ritrovarta tramite la select)
            SqlDataReader reader = sqlCmd.ExecuteReader(); //andiamo ad eseguirlo

            //reader è l'oggetto risultato della query
            //reader è un oggetto che rappresenta tab risultato della select che va scorsa fino a quando non ci sono piu righe
            while (reader.Read()) //==> qst metodo posizione cursore sempre sulla riga successiva fino a quando nn torna false
                //qnd le righe sono tutte lette, ritorna false e il programma finisce

                //metodo read è un bool, ritorna true se ci sono ancora righe altrimenti ritorna false
            {
                //usiamo i metodi dell'oggetto reader per leggere i dati della tabella
                Console.WriteLine($"id={reader[0]}, regione={reader.GetString(1)}, " +
                    $"latitudine={reader.GetDecimal(2)}, longitudine={reader.GetDecimal(3)}");
            }

            //possiamo anche scriverlo col for

            for (; reader.Read(); )
            {
                print((int)reader[0], reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3));
               /* Console.WriteLine($"id={reader[0]}, regione={reader.GetString(1)}, " +
                $"latitudine={reader.GetDecimal(2)}, longitudine={reader.GetDecimal(3)}");*/
            }

            //mi serve un contenitore he tenga tutte le rgioni 

            List<Regione> regioni = new();

            while (reader.Read()) 
            {
                Regione regione = new(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3));
                regioni.Add(regione);
            }


            //chiudiamo il reader
            reader.Close(); //butto la tabella temporanea che avevo

            //chiudiamo connessione
            connection.Close(); //chiudo oggetto che mi era servito da tubo

            Console.WriteLine($"Trovate {regioni.Count} regioni");


        }
        private void print(int id, string regione, decimal latitudine, decimal longitudine)
        {
            Console.WriteLine($"id={id}, regione={regione}, " +
                $"latitudine={latitudine}, longitudine={longitudine}");
        }

    }
}
