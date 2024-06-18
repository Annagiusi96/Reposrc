using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaII;

public class StanzaV1
{
    private FiguraGeometrica _stanza;
    private bool _calcolaPerimetro;
    private bool _calcolaArea;
    private double _areaSottrarre;

    public double Perimetro
    {
        get { return _calcolaPerimetro ? _stanza.Perimetro() : 0; }
    }

    public double Area
    {
        get { return _calcolaArea ? _stanza.Area() : _stanza.Area() - _areaSottrarre; }
    }
   
    public StanzaV1(FiguraGeometrica stanza, bool calcolaPerimetro, bool calcolaArea, double areaSottrarre = 0)
    {
        _stanza = stanza;
        _calcolaPerimetro = calcolaPerimetro;
        _calcolaArea = calcolaArea;
        _areaSottrarre = areaSottrarre;
    }
}
