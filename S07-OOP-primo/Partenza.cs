using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;
//ci creiamo una classe partenze che conterrà il nostro main
//main: entry point, il punto nel quale parte l'elaborazione del programma
//questo punto è stabilito dal nome MAIN che viene dato a una funzione
//è il punto di INIZIO del programma
public class Partenza
{
    //il main è univoco, non possono essercene due
    public static void Main()
    {
        Matita m = new Matita(); //creiamo l'istanza di una Matita
        string s = new string("sto scrivendo con la matita");
        //string s = ("Hello"); noi scriviamo così senza NEW perchè la stringa è un tipo di dato molto usato
        //è comunq un oggetto a tutti gli effetti della classe String

        m.Scrivere(s);//usiamo il metodo Scrivere sull'oggetto appena creato

        //creo un'istanza della classe Biro
        Biro b = new Biro();
        b.Scrivere("sto scrivendo con la biro");

        Biro b2 = new Biro();
        b2.Scrivere("sto scrivendo dalla biro2");
        Console.WriteLine(b == b2); //false xke sono due istanze diverse, anche se appartengono alla stessa classe

        //forma abbreviata:
        Biro b3 = new();

        //per stampare il tipo:
        Console.WriteLine(b3.GetType()); //output namespace.Biro
        /*
         Il tipo di dato comprende anche il NAMESPACE
         */

        //uguaglianza tra oggetti
        Biro bb1 = new();
        Biro bb2 = new();
        Console.WriteLine((bb1 == bb2) + "bb1 == bb2"); //false, sono due biro diverse

        //prendo istanza che c'era in bb1 e la metto in bb3, non creo un'altra istanza con bb3
        Biro bb3 = bb1;
        Console.WriteLine((bb1 = bb3) + "bb1 = bb3");// true, trattengo la medesima biro con due reference

        long x = 123;
        Console.WriteLine(x.GetType()); //System.Int64, è un oggetto 

        //stringhe
        string str1 = new String("Hello"); //viene memorizz in una tabella interna
        string str2 = new String("Hello");//la macchina assegna la stringa vecchia, avendo lo stesso valore
        Console.WriteLine((str1 == str2) + "str1 == str2"); //True

        str2 = "He";
        str2 += "llo";
        Console.WriteLine((str1 == str2) + "str1 == str2"); //True

        Console.WriteLine("**********************************************************\n");

        //mai testare uguagliaza tra oggetti con ==
        //== ritorna true solo se si sta usando il medesimo oggetto

        Quadrato q1 = new(55.78);// posso cambiare il valore del lato solamente mentre sto costruendo l'oggetto q1
        q1.Perimetro();
        q1.Area();
        Console.WriteLine(q1); //la stampa di un oggetto mi chiama il metodo tostring

        string q1Str = "[[[ " + q1 + "]]"; //[[[ S07_OOP_primo.Quadrato]]
        //viene usato il tostring come sistema standard di conversione di un qualsiasi oggetto in una stringa
        //viene chiamato implicitamente il metodo tostring()
        //il ns dato quindi sarà sempre traducibile in una stringa

        Console.WriteLine(q1Str); //ogni volta che usiamo il + concateniamo qulcosa a una stringa 
        //quel qualcosa diventa una stringa. Questo è dovuto al metodo toString

        Console.WriteLine("**********************************************************\n");

        Rettangolo r1 = new(33.4, 44.0);
        r1.Perimetro();
        r1.Area();
        double area = r1.Area(); //area2 ritorna un valora, ovvero un double, e lo salvo in double area
        Console.WriteLine(area);
        Console.WriteLine($"la base del rettangolo misura {r1.Base}");

        Console.WriteLine($"metodo tostring su r1: {r1}");

        Console.WriteLine("**********************************************************\n");

        Cerchio c1 = new(22.5);//imposto valore del raggio
        double areaCerchio = c1.Area();
        double circonferenzaCerchio = c1.Circonferenza();
        double diametroCerchio = c1.Diametro();

        Console.WriteLine($"Il raggio del cerchio è: {c1.Raggio}, l'area del cerchio è: {areaCerchio}, " +
            $"la circonferenza è: {circonferenzaCerchio} e il diametro è: {diametroCerchio}");

        Console.WriteLine("**********************************************************\n");

        Dado d1 = new(4); //imposto 4 facce
        int numeroLanci = Random.Shared.Next(1, 20);
        Console.WriteLine($"Il mio dado ha {d1.NumeroFacce} facce. Lo lancio per {numeroLanci} volte\n");

        for (int i = 0; i < numeroLanci; i++)
        {
            Console.WriteLine($"Lancio {i + 1}, valore estratto: {d1.Lanciare()}");
        }

        Console.WriteLine("**********************************************************\n");

        //erediterietà fa si che io poss scrivere:
        BiroScatto bs = new();
        bs.Scrivere($"Hello tramite BiroScatto {bs.ToString()}"); //posso accedere al metodo ToString su qualsiasi oggetto

        //con l ereditarietà mi porto dietro il tipo anche
        //posso maneggiare un quadrato come un rettangolo

        Object orqq2 = new Quadrato(10);
        /*sulla base del rettangolo crei un quadrato*/
        Rettangolo rqq2 = new Quadrato(10);

        //il tipo rimane quadrato, ma lo sto maneggiando come se fosse un rettangolo
        Console.WriteLine($"tipo={rqq2.GetType()} area={rqq2.Area()} " +
            $"perimetro={rqq2.Perimetro()}, altezza={rqq2.Altezza}, base={rqq2.Base}");//uso i metodi del rettangolo sul quadrato
        Quadrato qq2 = new(10);

        //quando scendiamo verso il basso piu specializzo e piu tipi raccolgo
        //ottengo il funzionamento del rettangolo facendo lavorare un quadrato

        FigureGeometriche fg = new Quadrato(40); //il quadrato corrispone/viene trattato come una figura geometrica
        Console.WriteLine($"tipo={fg.GetType()} area={fg.Area()} " +
           $"perimetro={fg.Perimetro()}");
        //qui vedo soko area e perimetro perche sono le uniche dichiarate in figuregeometriche

        //quello che ottengo è sempre il funzionamento del quadrato
        Console.WriteLine("**********************************************************\n");
        //es. completare classe ellisse e come test considerare un ellisse con semiasse magg e minre uguale a 10
        //confrontare i risultati comparandoli a quelli diun cerchio con raggio 10

        //creo un oggetto ellisse
        Ellisse e1 = new(10, 10);
        Console.WriteLine($"Il perimetro dell'ellisse è: {e1.Perimetro()}, " +
            $"l'area è di: {e1.Area()}");

        //creo oggetto cerchio con raggio 10
        Cerchio cerchio = new(10);
        Console.WriteLine($"Il perimetro del cerchio è: {cerchio.Circonferenza()}, " +
            $"l'area è di: {cerchio.Area()}");

        Console.WriteLine("**********************************************************\n");
        Console.WriteLine("**************************POLIMORFISMO********************************\n");
        //POLIMORFISMO

        //possiamo definire un array di tipo figuregeometriche
        FigureGeometriche[] arrayDiFigureGeometriche = [new Cerchio(12.65), 
                                                        new Quadrato(22.6),
                                                        new Rettangolo(12.5,5.4),
                                                        new Ellisse(5.4,8.5)
                                                        ];

        double areaTotale = 0.0;
        double perimetroTotale = 0.0;

        for (int i = 0; i < 5; i++)
        {
            //ho un reference generico di tipo figuregeometriche
            //ma quando lo uso mi da il risultato corretto della figura che va a pescare
            FigureGeometriche figuraCasuale = arrayDiFigureGeometriche[Random.Shared.Next(arrayDiFigureGeometriche.Length)];
            areaTotale += figuraCasuale.Area(); //capisce in automatico l'area da calcolare della figura corrente
            perimetroTotale += figuraCasuale.Perimetro();
            Console.WriteLine(figuraCasuale);
        }
        Console.WriteLine($"Totale perimetro= {perimetroTotale}, totale areea={areaTotale}");
    }
}
