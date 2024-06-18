using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public class Quadrato : Rettangolo //dalla geometria dal rettangolo si ricava il quadrato
    //per questo motivo quadrato eredita tutto quello che è dentro rettangolo
{
    private double _lato = 4.0; //lato fa parte della natura del quadrato, a parte il valore in se per se
    //private: nessuno può modificarlo dall'esterno
    //lato è una VARIABILE DI STATO, perche se la modifico allora cambio tutta la vita dell'oggetto

    //l'information hiding mi da la possibilità dunque di fornire risultati coerenti,
    //non avendo la possibilità di modificarli dall'esterno

    //se facessi:
    //public double lato = 4.0;
    //posso accedere dall'esterno a lato e cambiargli il valore

    public double Lato
    {
        get { return _lato; }

        //qst operazione rompe l'incapsulamento:
        //set { lato = value; } //q1.Lato = 23.44, value assumerà il valore di 23.44, non piu di 4.0
    }

    //***Non avrò bisogno di definire di nuovo area e perimetro visto che quadrato eredita i due metodi da rettangolo****

    /*public double Perimetro() //è public xke dall'esterno devo usare qst metodi, è importante che non siano hidden
    {
        //Console.WriteLine($"Il perimetro del quadrato è: {lato * 4}");
        return _lato * 4;
    }
    public double Area()
    {
        //Console.WriteLine($"L'area del quadrato è: {lato * lato}");
        return _lato * _lato;
        //metodo prof:
        //double a = 4.0 * 4.0;
        //Console.WriteLine($"l'area è: {a}");
    }*/

    //***Non avrò bisogno di definire di nuovo area e perimetro visto che quadrato eredita i due metodi da rettangolo****

    //costruttore: ha lo stesso nome della classe, è un metodo e puo accettare argomenti e
    //li passo direttamente a chi li deve utilizzare
    //il costruttore è un metodo particolare che ha lo stesso nome della classe,
    //può avere tutti gli argomenti che servono per portare l'oggetto allo stato iniziale

    public Quadrato(double lato) : base(lato, lato) //richiamo il costruttore della classe padre
    {
        //Console.WriteLine($"sto per costruire un quadrato di lato {lato}");
        _lato = lato;
    }
    //CTRL . per generare il costruttore

    public override string? ToString()
    {
        return $"{GetType()}: lato ={_lato} perimetro={Perimetro()} area={Area()}";
    }
}

/* quando uso private o public?
 Regola empirica (vale quasi dappertutto) =>
-- i Field sempre PRIVATE
-- i Metodi che forniscono risultati utilizzati dall'esterno per ottenere lavoro dall'oggetto sempre PUBLIC
-- ((eventuali Metodi che non sono accessibili o non utili per l'esterno li definiamo private))
 */
