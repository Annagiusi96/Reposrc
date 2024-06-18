using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public class Cerchio : Ellisse
{
    private double _raggio;
    //Math.PI ti dà il pi greco

    //property
    public double Raggio
    {
        get { return _raggio; }
        set
        {//in qst modo posso mdificare il raggio dall esterno ma ho molto piu controllo sul value che può assumere
            if (value < 100 && value > 0)
                _raggio = value;
        }
    }

    //costruttore
    public Cerchio(double raggio) : base(raggio,raggio)
    {
        this._raggio = raggio; //this:qui, questo _raggio diventa questo raggio. 'riferito a questo _raggio'
        //il this diventa obbligatore quando c'è il medesimo nome delle variabili
        //THIS simboleggia l'istanza corrente vista dall'interno dell'istanza stessa
    }

    //metodi
    /*public override double Area()
    {
        double area = Math.PI * _raggio * _raggio;
        return area;
    }*/ //AREA VIENE EREDITATO DA ELLISSE

    public double Circonferenza()
    {
        return Perimetro();
    }

    public double Diametro()
    {
        double diamentro = 2 * _raggio;
        return diamentro;
    }

    public override string? ToString()
    {
        return $"{GetType()}: raggio:{Raggio} perimetro={Perimetro()} area={Area()}";
    }
}
