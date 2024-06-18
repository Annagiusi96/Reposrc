using S07_OOP_primo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S09_Parquet01;

public class Preventivo
{
        private double _costoPosaParquetMq = 0.0;
        private double _costoPosaBattiscopaM = 0.0;
       
    public Preventivo(double costoPosaParquetMq, double costoPosaBattiscopaM)
    {
        this._costoPosaParquetMq = costoPosaParquetMq;
        this._costoPosaBattiscopaM = costoPosaBattiscopaM;
    }

    public double CostoPosaParquetMq
    {
        get { return  _costoPosaParquetMq; }
    }

    public double CostoPosaBattiscopaM
    {
        get { return _costoPosaBattiscopaM; }
    }
    //posso scrivere lo stesso nome di metodo con parametri diversi
    //metodi overloading (sovraccaricati) stesso nome, signature diversa
    //qst metodo si può avere in una gerarchia di classi, nella stessa classe o in un mix dei due
    //altra manifestazione del polimorfismo (ho piu forme e il codice viene attivato in automatico in base alla signature)
    public void Calcola(FiguraGeometrica figura)//diversa la signature tra i due metodi (firma del metodo = nome del metodo + tipo parametri)
    {
        Calcola(new FiguraGeometrica[]{figura});
    }

    public void Calcola(FiguraGeometrica[] arrayStanze)
    {
        double costoPosaParquetTotale = 0.0;
        double costoPosaBattiscopaTotale = 0.0;

        for (int i = 0; i < arrayStanze.Length; i++)
        {
            double costoPosaParquetStanza = Math.Round(arrayStanze[i].Area() * _costoPosaParquetMq, 2);
            double costoPosaBattiscopaStanza = Math.Round(arrayStanze[i].Perimetro() * _costoPosaBattiscopaM, 2);

            Console.WriteLine($"Stanza: {arrayStanze[i].GetType().Name}");
            Console.WriteLine($"Costo per la posa del parquet è di: {costoPosaParquetStanza} euro.");
            Console.WriteLine($"Costo per la posa del battiscopa è di: {costoPosaBattiscopaStanza} euro\n");

            costoPosaParquetTotale += costoPosaParquetStanza;
            costoPosaBattiscopaTotale += costoPosaBattiscopaStanza;
        }
       
        Console.WriteLine($"Il costo totale per la posa del parquet è di: {Math.Round(costoPosaParquetTotale, 2)} euro\n");
        Console.WriteLine($"Il costo totale per la posa del battiscopa è di: {Math.Round(costoPosaBattiscopaTotale, 2)} euro\n");
        Console.WriteLine($"Il costo totale per la pavimentazione della villa è di: {Math.Round(costoPosaBattiscopaTotale + costoPosaParquetTotale, 2)} euro\n");  
    }

    
    
}
