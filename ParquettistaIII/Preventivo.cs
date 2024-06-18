using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometria;

namespace ParquettistaIII;

public class Preventivo
{
    // valori per il calcolo del preventivo
    private double _costoPosaParquet = 16.00;
    private double _costoPosaBattiscopa = 5.00;
    public string Descrizione { get; set; }

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
        foreach (Spazio spazio in _spazi)
        {
            costo += spazio.Area * CostoUnitarioPosaParquet;
        }

        return costo;
    }
    public double CostoBattiscopa()
    {
        double costo = 0.0;
        foreach (Spazio spazio in _spazi)
        {
            costo += spazio.Perimetro * CostoUnitarioPosaBattiscopa;
        }

        return costo;
    }

    public double CostoTotale()
    {
        return CostoParquet() + CostoBattiscopa();
    }


    private List<Spazio> _spazi = new();

    public void Aggiungi(FiguraGeometrica figura) //il metodo seguente è fornito solo per retrocompatibilità
    {
        Aggiungi(new Spazio(figura, true, true));
    }

    public void Aggiungi(Spazio spazio)
    {
        _spazi.Add(spazio);
    }
}
