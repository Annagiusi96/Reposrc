using System.Security.Cryptography.X509Certificates;

namespace S12_Contenitori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContenitoreDiOggetti contenitore1 = new ContenitoreDiOggetti("Hello");
            ContenitoreDiOggetti contenitore2 = new ContenitoreDiOggetti(22);
            ContenitoreDiOggetti contenitore3 = new ContenitoreDiOggetti(new ContenitoreDiOggetti("Ciao"));

            Console.WriteLine(contenitore1.Contenuto);
            Console.WriteLine(contenitore2.Contenuto);
            Console.WriteLine(contenitore3.Contenuto);

            string str = (string)contenitore1.Contenuto;//cast, conversione forzata visto che è un object inizialm
            int intero = (int)contenitore2.Contenuto;//cast, conversione forzata visto che è un object inizialm

            //a qst punto posso usare i dati che ho tirato fuori
            Console.WriteLine($"intero={intero}");//22

            //intero = (int)contenitore1.Contenuto; //genera exeption
            //il conten1 contiene una stringa, ne prendo il contenuto e lo forzo a int
            //invalid cast exeption, la conversione forzata è sbagliata

            //in qst modo abbiamo diversi problemi
            //fare un cast, ricordarci che tipo è ecc

            object o = contenitore3.Contenuto;
            str = (string)((ContenitoreDiOggetti)o).Contenuto; //ho un contenitore che contiene un contenitore di ogg
            //o è il contenitore di oggetti 
            //faccio cast al contenit di ogg e dopo posso prelevare il contenuto
            Console.WriteLine($"str={str}");

            Contenitore<string> cds = new Contenitore<string>("hello");
            //qst ha diversi vantaggi:

            string cont = cds.Contenuto; //ho una conversione diretta a string

            //posso tenere insieme piu informazioni anche di tipo diverso
            Coppia<string, double> unitaDiMisura = new("litro", 1.0);
            Coppia<string, double> unitaDiMisuraDecilitro = new("decilitro", 0.1);

            Console.WriteLine("******************************************************");

          
            Console.WriteLine(faiQualcosa("ciao", "mondo", 3));
            Console.WriteLine("******************************************************");

            //esempio shuffle generics

            int[] arr1 = [2, 3, 4, 6, 6];

            MescolatoreParametrico<int> mpi = new();
            arr1 = mpi.ShuffleReturn(arr1);
            foreach (int item in arr1)
            {
                Console.WriteLine(item);
            }

            char[] arr2 = ['a', 'v', 'f', 'x'];

            MescolatoreParametrico<char> mpi2 = new();
            arr2 = mpi2.ShuffleReturn(arr2);
            foreach (char item in arr2)
            {
                Console.WriteLine(item);
            }

            //ho usato lo shuffle indipendetemente dal tipo che voglio usare

            //STRUTTURE DATI:

            int[] arrayInteri = [1,2,3,4,5];

            //LIST ==> personalizzabile a un tipo. Realizza un contenitore a lunghezza variabile di tipo generico.

            List<string> listaStringhe = new();

           /* listaStringhe.Add("stringa 1");
            listaStringhe.Add("stringa 2");
            listaStringhe.Add("stringa 3");
            listaStringhe.Add("stringa 4");*/

            for (int i = 0; i < 100000; i++)
            {
                listaStringhe.Add($"stringa {i}"); //è espandibile
            }
            Console.WriteLine($"la lista contiene {listaStringhe.Count} elemento");
            listaStringhe.RemoveAt(0); //viene rimosso elemento 0
            Console.WriteLine($"la lista contiene {listaStringhe.Count} elemento");
            //COUT corrispettivo della LENGTH. 
            //la differenza tra i due è che il count cambia durante il ridimensionamneto della lista

            List<MescolatoreTradizionale> mescolatori = new();

            List<string> stringhe = new();
            



        }

        private static Contenitore2<Contenitore2<int, string, string>, Contenitore2<string, int, string>, Contenitore2<int, int, string>> 
            faiQualcosa(string t1, string t2, int t3)
        {
            Contenitore2<int, string, string> result1 = new(t3, t2, t1);
            Contenitore2<string, int, string> result2 = new(t1, t3, t2);
            Contenitore2<int, int, string> result3 = new(t3, t3, t1);

            Contenitore2<Contenitore2<int, string, string>, Contenitore2<string, int, string>, Contenitore2<int, int, string>> result =
                new(result1, result2, result3);
            return result;
        }
    }
}

public class ContenitoreDiOggetti //<T>//nome che identifica un tipo parametrico che sostituisce il tipo della variabile
                                  //che vogliamo rendere cambiabile volta per volta
{
    private object _object; //object è al top di tutte le gerarchie e trattiene qualsiasi tipo di oggetto
    //se voglio leggere l oggetto potrei
    public object Contenuto
    {
        get { return _object; }
    }
    public ContenitoreDiOggetti(object @object)
    {
        _object = @object;
    }

    //un contenitore object generico è posso flessibile
    /*
     si può gestire il tipo di oggetto contenuto attraverso 
     GENERICS ==> <T> (es. t sta per tipo, psosiamo chiamarlo come vogliamo)
     
     */
}

public class Contenitore<T>//nome che identifica un tipo parametrico che sostituisce il tipo della variabile
                           //che vogliamo rendere cambiabile volta per volta
{
    private T _object; //object è al top di tutte le gerarchie e trattiene qualsiasi tipo di oggetto
    //se voglio leggere l oggetto potrei
    public T Contenuto
    {
        get { return _object; }
    }
    public Contenitore(T @object)
    {
        _object = @object;
    }

    //un contenitore object generico è posso flessibile
    /*
     si può gestire il tipo di oggetto contenuto attraverso 
     GENERICS ==> <T> (es. t sta per tipo, psosiamo chiamarlo come vogliamo)
     
     */
}

public class Coppia<T1, T2> //definisco classe coppia con due tipi differenti
{
    private T1 elemento1;
    public T1 Elemento1
    {
        get { return elemento1; }
        set { this.elemento1 = value; } //facendo il setter rendo il contenitore MUTABLE per T1
    }

    private T2 elemento2;
    public T2 Elemento2 //qui non garantisco che elemento2 possa essere immutable
    {
        get { return elemento2; }
    }

    public Coppia(T1 elemento1, T2 elemento2)
    {
        this.elemento1 = elemento1;
        this.elemento2 = elemento2;
    }
    //Un contenitore è IMMUTABLE quando nn può cambiare il suo contenuto
}

public class Contenitore2<T1, T2, T3>
{
    private T1 _el1;
    private T2 _el2;
    private T3 _el3;
    public T1 El1
    {
        get { return _el1; }
       
    }
    public T2 El2
    {
        get { return _el2; }
       
    }
    public T3 El3
    {
        get { return _el3; }
        
    }

    public Contenitore2(T1 el1, T2 el2, T3 el3)
    {
        this._el1 = el1;
        this._el2 = el2;
        this._el3 = el3;
    }

    public override string? ToString()
    {
        return $"{_el1} {_el2} {_el3}";
    }
}