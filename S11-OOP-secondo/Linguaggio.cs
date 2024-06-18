using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S11_OOP_secondo;

public class Linguaggio
{
    private static int x = 10;
   
    //essendo static è invocabile direttamente dal main
    public static void sommaStatic(int x)
    {
        x++;
    }

    //è necessaria un istanza x poterlo invocare da main, non è invocabile direttamente da main
    public  void somma(int x)
    {
        x++;
    }
    //accetta un reference alla variabile e non un valore
    public void sommaByRef(ref int x)
    {
        x++;
    }

    public void somma(Contenitore c)
    {
        c.x++;
    }

    public int sommaReturn(int x)
    {
        x++;
        return x;
    }


    /*INCAPSULAMENTO

    --variabili di stato sempre private.
    --variabili di stato mai con un setter!

    A volte si puo concedere la lettura su una variabile di stato
    se la variabile è di tipo semplice non vi dovrebbero essere particolare problemi

    se la variabile è di tipo riferimento(complesso) le cose cambiano:
    --se la variabile di stato è di tipo riferimento ed è mutable mai concedere dei getter.

    --se la variabile di stato è di tipo riferimento ed è IMmutable non dovrebbero esserci problemi.*/

    private string _marca = "pinco";
    private int xx = 3;
    public string Marca
    {
        get { return _marca; }
    }

    public int Numero
    {
        get { return xx; }
    }

}
