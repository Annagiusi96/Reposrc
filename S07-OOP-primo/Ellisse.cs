using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public class Ellisse : FigureGeometriche
{
    private double _semiasseMaggiore;
    private double _semiasseMinore;

    public Ellisse(double semiasseMaggiore, double semiasseMinore)
    {
        _semiasseMaggiore = semiasseMaggiore;
        _semiasseMinore = semiasseMinore;
    }

    public double SemiasseMinore
    {
        get { return _semiasseMinore; }
    }

    public double SemiasseMaggiore
    {
        get { return _semiasseMaggiore; }
    }

    public override double Area()
    {
        return Math.PI * _semiasseMaggiore * _semiasseMinore;
    }
   
    public override double Perimetro()
    {
        return 2 * Math.PI * Math.Sqrt((_semiasseMinore*_semiasseMinore + _semiasseMaggiore*_semiasseMaggiore)/2);
    }

    public override string? ToString()
    {
        return $"{GetType()}: semiasseMagg:{SemiasseMaggiore}, semiasseMin: {SemiasseMinore} " +
            $"perimetro={Perimetro()} area={Area()}";
    }

}
