using S13_SqlUtilizzo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S15_RegioniDao;

public class Provincia
{
    public int Id { get; set; }
    public int IdRegione { get; set; }
    public int CodiceCittaMetropolitana { get; set; }
    public string Nome { get; set; }
    public string SiglaAutomobilistica { get; set; }
    public decimal Latitudine { get; set; }
    public decimal Longitudine { get; set; }

    public Provincia() 
    { 
    }

    public Provincia(int id)
    {
        this.Id = id;
    }

    public override string? ToString()
    {
        return $"{GetType()}: id:{Id}, id_regione:{IdRegione}, codice_citta_metropolitana:{CodiceCittaMetropolitana}," +
            $"nome:{Nome}, sigla_automobilistica:{SiglaAutomobilistica}, latitudine={Latitudine}, longitudine={Longitudine}";
    }
}
