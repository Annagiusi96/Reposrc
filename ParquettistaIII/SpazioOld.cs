using Geometria;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaIII;

public class SpazioOld
{
    private Misurabile _zona;

    private bool _calcolaPerimetro;
    private bool _calcolaArea;

    public string Descrizione { get; set; }

    public double Perimetro
    {
        get { return _calcolaPerimetro ? _zona.Perimetro() : 0; }
    }

    public double Area
    {
        get { return _calcolaArea ? _zona.Area() : 0; }
    }
   
    public SpazioOld(Misurabile stanza, bool calcolaPerimetro, bool calcolaArea)
    {
        _zona = stanza;
        _calcolaPerimetro = calcolaPerimetro;
        _calcolaArea = calcolaArea;
    }
}
