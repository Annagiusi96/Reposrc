using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria;

public class Ellisse : FiguraGeometrica
{
    private readonly double _semiasseMinore;
    public double SemiasseMinore
    {
        get { return _semiasseMinore; }
    }

    private readonly double _semiasseMaggiore;
    public double SemiasseMaggiore
    {
        get { return _semiasseMaggiore; }
    }

    public Ellisse(double semiasseMinore, double semiasseMaggiore)
    {
        this._semiasseMinore = semiasseMinore;
        this._semiasseMaggiore = semiasseMaggiore;
    }

    public override double Area()
    {
        // https://www.youmath.it/domande-a-risposte/view/6350-area-ellisse.html
        double area = Math.PI * _semiasseMinore * _semiasseMaggiore;
        return area;
    }

    public override double Perimetro()
    {
        // https://www.youmath.it/domande-a-risposte/view/6349-perimetro-ellisse.html
        double perimetro = 2 * Math.PI * Math.Sqrt((Math.Pow(_semiasseMinore, 2) + Math.Pow(_semiasseMaggiore, 2)) / 2);
        return perimetro;
    }

    public override string? ToString()
    {
        return $"{GetType()}: area={Area()} perimetro={Perimetro()} semiasse minore={_semiasseMinore} semiasse maggiore={_semiasseMaggiore}";

    }
}
