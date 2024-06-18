using S07_OOP_primo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S09_Parquet01;

public class NullDemo
{
    public void ProvaNull()
    {
        Quadrato q = new(5);
        Console.WriteLine(q.Area());

        q = null;
        Console.WriteLine(q.Area());

        //genero una null exeption, ovvero un oggetto vuoto

        FiguraGeometrica[] fgs = new FiguraGeometrica[10];
        fgs[0] = q;
        fgs[1] = new Cerchio(8);
        foreach (FiguraGeometrica item in fgs)
        {
            Console.WriteLine($"****{item}****"); //per i valori non riempiti sono vuoti, ovvero c'è dentro null
            Console.WriteLine($"{item.Area()}");//avrò una null reference exeption per tutte le posizioni null
        }
    }
}
