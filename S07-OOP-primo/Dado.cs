using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public class Dado
{
    private int _numeroFacce;
    //numeroLanci non lo definisco come variabile di istanza perchè non è necessario per un dado 

    //costruttore
    public Dado(int numeroFacce)
    {
        if (numeroFacce < 4)
        {
            string msg = "Il numero delle facce deve essere almeno 4";
            throw new Exception(msg); 
        }
        this._numeroFacce = numeroFacce;
    }

    //property
    public int NumeroFacce
    {
        get { return _numeroFacce; }
        set { _numeroFacce = value; }
    }

    //metodo Lanciare
    public int Lanciare()
    {
        int numeroEstratto = Random.Shared.Next(1, _numeroFacce + 1);
        return numeroEstratto;
    }
}
