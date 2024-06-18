using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Utility;

public class TombolaI
{
    private List<int> tabellone = new();

    // per dimostrazione
    private int contatoreDelleEstrazioni = 0;

    public TombolaI() {
       
    }

    public int estrai() // privilegia l'indice
    {
        contatoreDelleEstrazioni++;

        int estratto = Random.Shared.Next(0, 90);

        // filtro: abbiamo già estratto il numero?
        while (tabellone.Contains(estratto)) // esiste già l'estratto sul tabellone?
        {
            Console.WriteLine($"DEBUG: Estrazione #{contatoreDelleEstrazioni} numero {estratto} già estratto");
            estratto = Random.Shared.Next(0, 90);
        }

        // numero non ancora estratto
        // metto il numero non ancora estratto sul tabellone

        tabellone.Add(estratto); // estratto + 1

        return estratto + 1;

    }

    public int estrai2() // privilegia il numero estratto
    {
        contatoreDelleEstrazioni++;

        int estratto = Random.Shared.Next(1, 91);

        // filtro: abbiamo già estratto il numero?
        while (tabellone[estratto-1] >= 0) // esiste già l'estratto sul tabellone?
        {
            Console.WriteLine($"DEBUG: Estrazione #{contatoreDelleEstrazioni} numero {estratto} già estratto");
            estratto = Random.Shared.Next(0, 90);
        }

        // numero non ancora estratto
        // metto il numero non ancora estratto sul tabellone

        tabellone[estratto-1] = estratto;

        return estratto;

    }
}
