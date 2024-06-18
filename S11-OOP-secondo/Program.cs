using System.Text;

namespace S11_OOP_secondo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IstanzaDemo id1 = new();
            id1.Incrementa();
            id1.Incrementa();
            id1.Incrementa();

            IstanzaDemo id2 = new();
            id2.Incrementa();

            Console.WriteLine(id1);
            Console.WriteLine(id2);

            IstanzaDemo.Stampa();

            Linguaggio.sommaStatic(5);

            Linguaggio l1 = new();

            //PASS BY VALUE
            int valore = 100;
            l1.somma(valore); //viene stampato ancora 100 e non 101
            //c# estrae il 100 da valore e il 100 viene passato al metodo, in x arriva una copia di valore
            //il contenuto della variabile valore
            //il metodo riceve il valore, passando una copia il metodo incrementa la copia locale della variabile
            //il metodo riceve una copia del valore
            //dato che il valore avviene su una copia, la modifica è solo locale, non viene propagata all'indietro


            //PASS BY REFERENCE
            l1.sommaByRef(ref valore); //101
            //abbiamo passato il riferimento a quella variabile
            //qst metodo riceve il riferimento del valore all'indirizzo della memoria
            //il lavoro del metodo avviene sul riferimento, la modifica viene propagata all indietro
          

            //PASS OBJECT BY REFERENCE
            Contenitore contenitore = new(500);
            l1.somma(contenitore);//viene passato il reference a contenitore
            Console.WriteLine($"contenitore.x= {contenitore.x}");//501
            //si incrementa perche quando passo un oggetto sono in un pass by value
            //però nel value del riferimento è contenuto il riferimento stesso, quindi
            //passo il riferiemtno alla mia variabile
            //il metodo riceve una copia del reference all'oggetto
            //il lavoro del metodo avviene tramite il reference sull oggetto e
            //la modifica viene propagata all indietro
            /*
             l'oggetto contenitore ha un indirizzo di memoria sullo STACK e il suo valore (i dati) è posizionato sullo HEAP
            il valore 500 che sta nella x si trova nello heap
            l argomento che viene ricevuto dal metodo è la copia del valore contenuto nella variabile
            siccome l oggetto è tipo reference
            nella variabile è contenuto il reference
            che puntano entrambi nella heap dove ci sono i dati dell oggetto
            il metodo rievente riceve il reference al valore contenuto nell oggtto
            tramite il reference puo fare la modifica ai dati dell oggetto stesso
            Contnitore c che passiamo come parametro a somma è esattamente una maniglia

            il return è fatto apposta per ritornare il valore
            in somma(int x) se voglio che il valore che passo come parametro il metodo influenza il valore della variabile (x++)
            l'unica maniera che ho è prendere il risultato e ritornarlo fuori col return (sommaReturn)
            per modificare l valore della variabile 

            valore = l1.sommaReturn(valore); //valore viene influenzato grazie al return

            quando il metodo deve elaborare e modificare una var semplice per farla uscire devo usare il return

            per gli oggetti avviene un comportamento differenze
            l'ggoetto sullo stack ha il riferimento e non il valore stesso
            viene estratto il riferiemnto che puntano al medesimo oggetto
            tramite il riferimento la modifica viene riportata all indietro
             
             */



            /*
             STRING è IMMUTABLE
             */
            
            string str = "Hello world";//stringa nr 1
            str = "Ciao mondo";//stringa nr 2

            //con qst operazione ho cambiato il valore e il riferimento ad str
            //è come se avessi fatto str = new string("hello world")
            //e str = new string("ciao mondo")
            //il compilatore esegue questa operazione in realtà, quindi il compilatore ottimizza esecuzione

            str += "***";
            //è come se avessi fatto str = new string("ciao mondo"+"****")
            str = "ddd";
            str += "ggg";
            //sto creando in realtà varie istanze nuove, ogni volta che cambio il valore
            //ho una nuova istanza della classe stringa
            /*
             la classe string si comporta quasi come se fosse una simple type variable
            essendo che genera oggetti di tipo immutable, butto via oggetto precedente e ne creo uno nuovo 
            ogni volta che modifico quell oggetto

            qst succede per tutti gli oggetti che sono immutable

            se si lavora in progetti ad alto traffico allora rallenta il fatto che vengano create piu oggetti string

      

            l'oggetto STRING BUFFER e STRING BUILDER trattano le stringhe in maniera non immutable 
             
       
             */
            //se devo manipolare una stringa usare stringbuilder è un metodo piu performante
            //dopo averla manipolata la converto in stringa 

            StringBuilder sb = new("Hello world"); //realizza una stringa non immutable
            //l'isanza rimane sempre la stessa quando viene modificata
            sb.Append(' '); //append ci consenste di accodare caratteri (come se fosse il +)
            sb.Append("dddd");
            sb.Append("#####");
            sb.Append("ciao mondo");
            Console.WriteLine(sb.ToString()); //pochi momenti in cui usiamo tostring per farlo lavorare
            //convertiamo il string builder in una stringa
             //l'istanza è rimasta sempre la stessa, sb

            sb.Length = sb.Length - 5; //stiamo perdendo 5 caratteri

            string h1 = "ciao";
            string h2 = "ciao mondo";
            string str1 = $"{h1}{h2}";
            //Nel momento in cui noi usiamo il dollaro in una stringa, è come se stessimo usando lo stringbuilder
            //il compilatore genera istanze inutili, ne viene creata una sola

            /*
            ATTIVAZIONE DISTRUTTORE


             */

            //esempio incapsulamento modifica dall esterno d una stringa immutable

            string marca = l1.Marca;
            marca = "***";
            Console.WriteLine(l1.Marca);//non viene cambiata

            int numero = l1.Numero;
            numero = 77;
            Console.WriteLine(l1.Numero);




            for (int i = 0; i < 100000; i++)
            {
                new DistruttoreDemo(); //si creao oggetto e lo si marca libero da qualiasi handle
                                       //ovvero disponibile per il garbage collection
                //prima di liberare glik oggetti questi vengono avvisati dell operazione in corso
                //tramite la chiamata al distruttore
                //la sintassi del distruttore è tildeDistruttore
                //in genere non si fa mai ma serve solo se l oggetto prima di andarlo via deve liberare delle risorse
                //di solito questo è un processo automatico
            }

           
        }
    }

    public class IstanzaDemo()
    {
        private int x = 0;
        private static int StaticX = 0;
        //static nn è piu legato all istanza ma è legato alla classe

        public void Incrementa()
        {
            x++;
            IstanzaDemo.StaticX++;
        }

        public override string? ToString()
        {
            return $"x={x}, staticx ={IstanzaDemo.StaticX}";

        }

        public static void Stampa()
        {
            Console.WriteLine("sto stampando un messaggio");
        }

    }

}

public class Contenitore

{
    public int x;

    public Contenitore(int x)
    {
        this.x = x;
    }
}
