using Geometria;

namespace ParquettistaII;

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

*/
public class Program
{
    /*
     * Appunti emersi dalla version 1
     Idee emerse:
    - classe Preventivo come addizionatore dei valori da moltiplicare per i costi unitari.
        Alla classe preventivo vengono passati singolarmente o come array gli oggetti da usare nel calcolo.
    I possibili oggetti da usare nel calcolo sono:
        - FiguraGeometrica
        - Stanza
        - Passare i costi unitari al costruttore del Preventivo
    - Metodi per ottenere i costi separati per battiscopa, parquet, totale

     */
    /*
     * Versione 2
     * Mano d’opera per la posa del parquet €. 16.00/mq
     * Mano d’opera per la posa del battiscopa €. 5.00/m
     * 
     * Completamento parquet e battiscopa per:
     *  - 1 rettangolo 10*3
     *  - 1 quadrato lato 5
     * Solo sostituzione battiscopa per
     *  - 1 rettangolo 7x5
     *  - 1 cerchio raggio 5
     */
    static void Main(string[] args)
    {
        Preventivo preventivo = new Preventivo();

        preventivo.Aggiungi(new Stanza(new Rettangolo(7, 5), true, false));
        preventivo.Aggiungi(new Stanza(new Cerchio(5), true, false));
        preventivo.Aggiungi(new Stanza(new Rettangolo(10, 3), true, true));
        preventivo.Aggiungi(new Stanza(new Quadrato(5), true, true));
       

        

        Console.WriteLine($"COSTO TOTALE BATTISCOPA = {preventivo.CostoBattiscopa()}");
        Console.WriteLine($"costo totale parquet  {preventivo.CostoParquet()}");
        Console.WriteLine($"costo totale  {preventivo.CostoTotale()}");

    }
}
