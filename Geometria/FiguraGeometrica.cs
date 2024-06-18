using ParquettistaII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria;

public abstract class FiguraGeometrica : Misurabile
{
    public abstract double Area();

    public abstract double Perimetro();

    public virtual double Semiperimetro() // metodo overriddable
    {
        return Perimetro() / 2;
    } 
}

