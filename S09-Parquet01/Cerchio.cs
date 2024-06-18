using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public class Cerchio : Ellisse
{
    private double _raggio = 4.0;     //field privati, non accessibili

    public Cerchio(double raggio) : base(raggio, raggio)
    {
        this._raggio = raggio; // this simboleggia l'istanza corrente vista dall'interno dell'istanza stessa.
    }

    public double Raggio                 //property, non é una variabile né un metodo
    {
        get { return _raggio; }
    }

    public  double Circonferenza()    //metodo public, accessibile dall'esterno
    {
        return Perimetro();
    }

    public override string? ToString()
    {
        return $"{GetType()}: raggio={_raggio} perimetro={Perimetro()} area={Area()} ";
    }
}
