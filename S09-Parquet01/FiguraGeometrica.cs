using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public abstract class FiguraGeometrica
{
    //abstract è sempre overriddable sennò non funziona
    public abstract double Area();

    public abstract double Perimetro();

    //per permettere la sovrascrittura di questo metodo dovrei aggiungere VIRTUAL
    //potrei avere un metodo virtual in una classe astratta o anche in una classe non astratta
    //virtual perche può essere sovrascrivere

    //posso combinare override e virtual, si possono intersecare
    public virtual double Semiperimetro() //metodo overriddable
    {
        return Perimetro() / 2;
    }
}

public abstract class X //x avere una classe astratta devo marcarla abstract
    //nn è necessario avere nessun metodo abstract per avere una classe abstract
{
    //se ho un metodo abstract allora sarà overridable
    public void esegui()
    {
        Console.WriteLine("sono una classe astratta");
    }
}
