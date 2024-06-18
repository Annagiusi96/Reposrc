using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaII;

public class Stanza
{
    private Misurabile _stanza;
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
   
    public Stanza(Misurabile stanza, bool calcolaPerimetro, bool calcolaArea)
    {
        _stanza = stanza;
        _calcolaPerimetro = calcolaPerimetro;
        _calcolaArea = calcolaArea;
    }
}
