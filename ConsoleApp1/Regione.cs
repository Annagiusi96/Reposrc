using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

public class Regione
{
    private int _id;
    private string _nome;
    private decimal _latitudine;
    private decimal _longitudine;

    public int ID
    {
        get { return _id; }
    }

    public string NomeRegione
    {
        get { return _nome; }
    }

    public decimal Latitudine
    {
        get { return _latitudine;  }
    }

    public decimal Longitudine
    {
        get { return _longitudine; }
    }
    public Regione(int id, string nome, decimal latitudine, decimal longitudine)
    {
        this._id = id;
        this._nome = nome;
        this._latitudine = latitudine;
        this._longitudine = longitudine;
    }

    public override string? ToString()
    {
        return $"getType(): id={_id}, nome={_nome}, latitudine={_latitudine}, longitudine={_longitudine}";
    }
}
