using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;

public class BiroScatto : Biro //dico che qst biroscatto specializza Biro, è costruita da partire da Biro
{
    public void Scrivere(string testo)
    {
        Console.WriteLine("BiroScatto:" + testo);
    }

    public override string? ToString()
    {
        return $"ridefiniziaione di to string: {base.ToString()}";
    }
}
