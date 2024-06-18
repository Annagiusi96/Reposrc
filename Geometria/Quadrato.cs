using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria;

public class Quadrato : Rettangolo
{
    private double _lato = 4.0;  // deve essere leggibile, ma non modificabile
    public double Lato { // Property
        get { return _lato;  } 
        // set { _lato = value;  }  // non legale, rompe l'incapsulamento ==> q1.Lato = 23.44;
    }

    public Quadrato(double lato) : base(lato, lato)
    {
        // Console.WriteLine($"Sto per costruire un quadrato di lato {lato}");
        _lato = lato;
    }

    public override string? ToString()
    {
        return $"{GetType()}: lato={_lato} perimetro={Perimetro()} area={Area()} ";
    }
}
