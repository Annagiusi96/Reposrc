using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S16_Dao;

// Le istanze di questa classe sono contenitori specializzati
// il cui compito è solo quello di trasportare informazioni
// non hanno stato (lo stato può essere pieno/vuoto)
// quindi qualsiasi informazione contenuta non appartenga allo stato
// quindi è liberamente accessibile dall'esterno
// Gli oggetti di questo tipo che trasportano dati
// da e verso un database si chiamano ENTITY
public class Regione
{
    public int Id { get; set; } 

    public string Nome { get; set;  }

    public decimal Latitudine { get; set; }

    public decimal Longitudine { get; set; }

    public override string? ToString()
    {
        return $"getType(): id={Id} regione={Nome} latitudine={Latitudine} longitudine={Longitudine}";
    }

    // Unico costruttore obbligatorio
    public Regione()
    {
    }

    public Regione(int id)
    {
        this.Id = id;
    }

    public Regione(int id, string nome, decimal latitudine, decimal longitudine)
    {
        Id = id;
        Nome = nome;
        Latitudine = latitudine;
        Longitudine = longitudine;
    }
}
