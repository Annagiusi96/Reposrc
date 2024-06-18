using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S11_OOP_secondo;

internal class DistruttoreDemo
{
    private long x = Random.Shared.NextInt64();

     ~DistruttoreDemo() //tilde avvisa che si tratta di un distruttore
    {
        Console.WriteLine($"distruttore attivato per {x}");
    }
}
