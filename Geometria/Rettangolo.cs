using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria;

public class Rettangolo : FiguraGeometrica
{
    private double _base = Random.Shared.NextDouble() * 20; // deve essere leggibile, ma non modificabile
    public double Base
    { // Property
        get { return _base; }
    }

    private double _altezza = Random.Shared.NextDouble() * 50; // deve essere leggibile, ma non modificabile
    public double Altezza
    { // Property
        get { return _altezza; }
    }

    public override double Area() {
        double area = _base * _altezza;
        // Console.WriteLine($"base={_base} altezza={_altezza} ==> area={area}"); // stampa di Debug
        return area;
    }

    public override double Perimetro() {
        double perimetro = (_base + _altezza ) * 2;
        // Console.WriteLine($"base={_base} altezza={_altezza} ==> perimetro={perimetro}"); // stampa di Debug
        return perimetro;
    }

    public Rettangolo(double @base, double altezza)
    {
        _base = @base;
        _altezza = altezza;
    }

    public override string? ToString()
    {
        return $"{GetType()}: area={Area()} perimetro={Perimetro()} base={_base} altezza={_altezza}";

    }
}
