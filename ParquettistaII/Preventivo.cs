using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometria;

namespace ParquettistaII;

public class Preventivo
{
    // valori per il calcolo del preventivo
    private double _costoPosaParquet = 16.00;
    private double _costoPosaBattiscopa = 5.00;

    public double CostoUnitarioPosaParquet
    {
        get { return _costoPosaParquet; }
    }

    public double CostoUnitarioPosaBattiscopa
    {
        get { return _costoPosaBattiscopa; }

    }

    public Preventivo(double costoPosaParquet = 16.0, double costoPosaBattiscopa = 5.0)
    {
        _costoPosaParquet = costoPosaParquet;
        _costoPosaBattiscopa = costoPosaBattiscopa;
    }

    public double CostoParquet()
    {
        double costo = 0.0;
        foreach (Stanza stanza in _stanze)
        {
            costo += stanza.Area * CostoUnitarioPosaParquet;
        }

        return costo;
    }
    public double CostoBattiscopa()
    {
        double costo = 0.0;
        foreach (Stanza stanza in _stanze)
        {
            costo += stanza.Perimetro * CostoUnitarioPosaBattiscopa;
        }

        return costo;
    }

    public double CostoTotale()
    {
        return CostoParquet() + CostoBattiscopa();
    }


    private List<Stanza> _stanze = new();

    public void Aggiungi(FiguraGeometrica figura) //il metodo seguente è fornito solo per retrocompatibilità
    {
        Aggiungi(new Stanza(figura, true, true));
    }

    public void Aggiungi(Stanza stanza)
    {
        _stanze.Add(stanza);
    }


}
