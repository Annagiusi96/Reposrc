using Geometria;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaIII;

public class StanzaV1
{
    private FiguraGeometrica _stanza;
    private bool _calcolaPerimetro;
    private bool _calcolaArea;
    private double _areaDaSottrarre;

    public double Perimetro
    {
        get { return _calcolaPerimetro ? _stanza.Perimetro() : 0; }
    }

    public double Area
    {
        get { return _calcolaArea ? (_stanza.Area() - _areaDaSottrarre) : 0; }
    }
    //  public double AreaDaSottrarre
    //{
    //    get { return _areaDaSottrarre ? _stanza.Area() : 0; }
    //}


   
    public StanzaV1(FiguraGeometrica stanza, bool calcolaPerimetro, bool calcolaArea, double areaDaSottrarre = 0)
    {
        _stanza = stanza;
        _calcolaPerimetro = calcolaPerimetro;
        _calcolaArea = calcolaArea;
        _areaDaSottrarre = areaDaSottrarre;
    }
}
