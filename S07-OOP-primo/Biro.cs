using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;
/*
CLASS BIRO
- scrivere(string testo)
- disegnare(string testo)
*/
public class Biro
{
    public void Scrivere(string testo)
    {
        Console.WriteLine("Biro:" + testo);
    }
    public void Disegnare(string testo)
    {
        Console.WriteLine(testo);
    }
}

/* a volte una classe così generica non basta, bisogna andare un po' piu nello specifico.
 * Ho bisogno di un livello di dettaglio superiore. Ad esempio potremmo trovare due sotto livelli:
 * -- BiroScatto
 * -- Bic
 * 
 * La Biro esprime un concetto generico, mentre la biro a scatto e la bic esprimono un concetto piu specifico.
 * C'è logicamente una relazione tra Biro e le altre due. L'insieme delle Biro contiene gli altri due insiemi
 * 
 * In Object Oriented si dice che BiroScatto "specializza" Biro e anche che Bic "specializza" Biro.
 * La biro invece "generalizza". (è una specifica più generica) ==> è il sovrainsieme
 * 
 * Questo dà luogo alla GERARCHIA fra le classi => questo genera un effetto che si chiama EREDITARIETA' (II proprietà fondamentale del OOP)
    ciò vuol dire che sotto alcune condizioni, il metodo Scrivere() e il metodo Disegnare() verrano
    EREDITATI dalle classi BiroScatto e Bic
 */
