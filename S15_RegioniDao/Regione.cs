using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S13_SqlUtilizzo;

public class Regione
{
    //dichiariamo direttament le proprietà, visto che porta in giro solo dati,
    //non devo preoccuparmi che qualcuno mi cambi lo stato del mio oggetto

    //questa scrittura però non ci permette di fare del controlli sul setter

    //il compito di qst classe è generare oggetti entity che traportano informazioni. Non hanno nessuno stato (o pieno o vuoto)
    //qualsiasi informazione contenuta non appartiene allo stato. Deve essere liberamente accessibile dall'esterno
    //perchè il compito dell'oggetto è il trasporto delle informazioni

    /*
     Le entity devono avere:
    - costruttore di default (esplicitato se esistono altri costruttori)
    - devono avere tutte le property per l’accesso read/write dei dati contenuti
    - devono avere il metodo ToString() (è importante per il debug)
     */

    /*
     Differenza tra usare variabili d'istanza o direttamente le proprietà?
     Se devo eseguire controlli nell’entità dei dati, il get e il set sono importanti, 
     se devo controllare i valori di Nome allora uso il get e il set.
     Se non uso il get e il set non posso fare questi controlli del value

    in genere questo tipo qui viene usato
     */
    public int Id { get; set; }

    public string Nome { get; set; }

    public decimal Latitudine { get; set; }
    public decimal Longitudine { get; set; }

    //costruttore di default obbligatorio. Questo lo dobbiamo mettere se abbiamo un altro costruttore sennò c# non lo genera
    public Regione()
    {
    }

    //costruttore non necessario
    public Regione(int id)
    {
        this.Id = id;
    }
    //costruttore per comodità
    public Regione(int id, string nomeRegione, decimal latitudine, decimal longitudine)
    {
        Id = id;
        Nome = nomeRegione;
        Latitudine = latitudine;
        Longitudine = longitudine;
    }

    public override string? ToString()
    {
        return $"{GetType()}: id={Id}, nome={Nome}, latitudine={Latitudine}, longitudine={Longitudine}";
        //è un buon modo per sovrascrivere la ToString()
    }
}
