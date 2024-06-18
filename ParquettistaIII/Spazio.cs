using Geometria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaIII;

public class Spazio
{
    public const int SOMMA = 1; // True
    public const int SOTTRAI = -1;
    public const int IGNORA = 0; // False


    private Misurabile _stanza;
    private int _calcolaPerimetro;
    private int _calcolaArea;

    public string Descrizione { get; set; }

    public double Perimetro
    {
        get { return _stanza.Perimetro() * _calcolaPerimetro; }
    }

    public double Area
    {
        get { return _stanza.Area() * _calcolaArea; }
    }
   
    public Spazio(Misurabile stanza, bool calcolaPerimetro, bool calcolaArea)
    {
        _stanza = stanza;
        _calcolaPerimetro = calcolaPerimetro ? SOMMA : IGNORA;
        _calcolaArea = calcolaArea ? SOMMA : IGNORA;
    }   

    public Spazio(Misurabile stanza, int calcolaPerimetro, int calcolaArea)
    {
        _stanza = stanza;
        _calcolaPerimetro = calcolaPerimetro;
        _calcolaArea = calcolaArea;
    }
}
