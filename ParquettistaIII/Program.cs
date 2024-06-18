using Geometria;

namespace ParquettistaIII;

public class Program
{

    static void Main(string[] args)
    {
        Preventivo preventivo = new Preventivo(1.0, 1.0);

        Laghetto laghetto = new(500, 650.22);

        Spazio st = new(laghetto, Spazio.SOMMA, Spazio.SOMMA); // +650.22, +500
        preventivo.Aggiungi(st); 
        
        Spazio st1 = new(laghetto, Spazio.SOTTRAI, Spazio.SOMMA); // -650.22, +500
        preventivo.Aggiungi(st1);

        Quadrato q = new(10); // area=100 perimetro=40
        Spazio st2 = new(q, Spazio.SOMMA, Spazio.IGNORA); // +40, 0
        preventivo.Aggiungi(st2);

        // atteso perimetro = 40, Area = 1000

        Console.WriteLine($"Preventivo battiscopa={preventivo.CostoBattiscopa()}");
        Console.WriteLine($"Preventivo parquet={preventivo.CostoParquet()}");
        Console.WriteLine($"Preventivo totale={preventivo.CostoTotale()}");



        //Console.WriteLine(prova.Area);
    }
}
