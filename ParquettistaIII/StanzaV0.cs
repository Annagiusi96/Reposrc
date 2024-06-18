using Geometria;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaIII;

public class StanzaV0
{
    private FiguraGeometrica _stanza;
    private bool _calcolaPerimetro;
    private bool _calcolaArea;

    public double Perimetro
    {
        get { return _calcolaPerimetro ? _stanza.Perimetro() : 0; }
    }

    public double Area
    {
        get { return _calcolaArea ? _stanza.Area() : 0; }
    }


   
    public StanzaV0(FiguraGeometrica stanza, bool calcolaPerimetro, bool calcolaArea)
    {
        _stanza = stanza;
        _calcolaPerimetro = calcolaPerimetro;
        _calcolaArea = calcolaArea;
    }
}
