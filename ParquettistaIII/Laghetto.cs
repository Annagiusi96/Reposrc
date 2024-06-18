using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaIII;

internal class Laghetto : Misurabile
{
    private double _area;
    private double _perimetro;

    public Laghetto(double area, double perimetro)
    {
        _area = area;
        _perimetro = perimetro;
    }

    public virtual double Area()
    {
        return _area;
    }

    public virtual double Perimetro()
    {
        return _perimetro;
    }
}
