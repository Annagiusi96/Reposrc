using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaII;

public class Laghetto //laghetto implementa l interfaccia misurabile
{
    private double _area;
    private double _perimetro;
    public virtual double Area()//virtual dobbiamo esplicitarlo noi per far si che i metodi siano overrideble
        //dato che in interfaccia si definiscono solo i metodi normali
    {
        return _area;
    }

    public virtual double Perimetro()
    {
        return _perimetro;
    }

    public Laghetto(double area, double primetro)
    {
        _area = area;
        _perimetro = primetro;
    }
}
