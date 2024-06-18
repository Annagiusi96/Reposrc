using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S13_SqlUtilizzo;

//Le istanze di questa classe sono contenitori specializzati il cui compito è solo quello di trasportare informazioni
//non hanno stato (lo stato può essere pieno o vuoto)
//qualsiasi informazione contenuta non appartiene allo stato e quindi è liberamente accessibile dall’esterno

//Gli oggetti di questo tipo che trasportano dati da e verso un database si chiamano ENTITY (entità)

//l'incapsulamento non mi serve in questo caso perche l'oggetto non ha stato
public class Regione
{
    private int _id;
    private string _nome;
    private decimal _latitudine;
    private decimal _longitudine;

    public int ID
    {
        get { return _id; } 
        set { _id = value; }
        
        //essendo un simple type da fuori non possiamo modificarlo, perchè facciamo un passaggio per valore
        //è una primary key, in tutta la tab è univoca, per questo non rendiamo l'id modificabile
    }

    public string NomeRegione
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public decimal Latitudine
    {
        get { return _latitudine;  }
        set { _latitudine = value; }
    }

    public decimal Longitudine
    {
        get { return _longitudine; }
        set { _longitudine = value; }
    }

    //costruttore di default è obbligatorio per questo tipo di oggetti
    public Regione()
    {
    }

    public Regione (int id)
    {
        this._id = id; //ne ho biogno perche è l'unico modo per accedervi a modificarlo
    }

    //costruttore di comodo, non obbligatorio
    public Regione(int id, string nomeRegione, decimal latitudine, decimal longitudine)
    {
        this._id = id;
        this._nome = nomeRegione;
        this._latitudine = latitudine;
        this._longitudine = longitudine;
    }

    public override string? ToString()
    {
        return $"id={_id}, nome={_nome}, latitudine={_latitudine}, longitudine={_longitudine}";
    }
}
