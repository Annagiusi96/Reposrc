//il ns programma utilizza tutte queste classi

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public class Rettangolo : FigureGeometriche
{
    //le variabili private si scrivono con underscore davanti 
    private double _baseRettangolo = Random.Shared.NextDouble() * 20;//ci da un random tra 0 e 1
    //se lo moltiplico per 20 mi da un random tra 0 e 20
    private double _altezzaRettangolo = 34.789;
    //private double @base = 0.0; base è una parola riservata, quindi la scriviamo con @

    //property, è un metodo mascherato che può gestire getter e setter
    //è un campo dove posso mettere get se voglio leggerla e set se voglio impostarla
    public double Base
    {
        get { return _baseRettangolo; }
    }

    public double Altezza
    {
        get { return _altezzaRettangolo; }
    }



    /*public void Perimetro()
    {
        Console.WriteLine($"Il perimetro del rettangolo è: {2 * (_baseRettangolo + _altezzaRettangolo)}");
    }*/

    public override double Perimetro()
    {
        return _baseRettangolo * 2 + _altezzaRettangolo * 2;
    }
    /*public void Area()
    {
        //double area = _baseRettangolo * _altezzaRettangolo;
        //la definisco minuscola essendo una variabile definita in un metodo
        Console.WriteLine($"L'area del rettangolo è: {(_baseRettangolo*_altezzaRettangolo)}");
    }*/

    public override double Area()
    {
        double area = (_baseRettangolo * _altezzaRettangolo) * 2;
        //Console.WriteLine($"L'area del rettangolo è: {(_baseRettangolo * _altezzaRettangolo)}"); solo per debug
        return area;
    }

    public Rettangolo(double baseRettangolo, double altezzaRettangolo)
    {
        _baseRettangolo = baseRettangolo;
        _altezzaRettangolo = altezzaRettangolo;
    }

  
    public override string? ToString()
   {
       return $"{GetType()}: base:{Base}, altezza:{Altezza}" +
            $" perimetro={Perimetro()} area={Area()}";
   }
}

