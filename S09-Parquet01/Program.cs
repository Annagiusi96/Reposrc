using S07_OOP_primo;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace S09_Parquet01;

/*
Luigi fa il parquettista, ci chiede aiuto per risolvere il problema dei preventivi che gli chiedono i clienti.
In genere le voci che compongono il preventivo, materiale escluso, sono 2:
Mano d’opera per la posa del parquet €. 16.00/mq
Mano d’opera per la posa del battiscopa €. 5.00/m
Avrebbe bisogno di un sw che lo aiuti nei calcoli
*/

/* Preventivo 01
 Mano d’opera per la posa del parquet €. 16.00/mq
 Mano d’opera per la posa del battiscopa €. 5.00/m
Per una villa nobiliare deve completare 4 stanze
rettangolo 10x3
rettangolo 7x5
cerchio 5
quadrato 5

Realizzare un sw che sia in
Grado di stampare i costi per
Le singole stanze e i costi globali.

Preventivo 02
 Mano d’opera per la posa del parquet €. 16.00/mq
 Mano d’opera per la posa del battiscopa €. 5.00/m
Per una villa nobiliare deve completare 4 stanze
rettangolo 10x3
rettangolo 7x5 (solo battiscopa)
cerchio 5 (solo battiscopa)
quadrato 5
*/
public class Program
{

    static void Main()
    {
        //PREVENTIVO 01:
        Preventivo p1 = new(16, 5);
        p1.Calcola([new Quadrato(5), new Rettangolo(10, 3), new Rettangolo(7, 5), new Cerchio(5)]);

    
    }
}

