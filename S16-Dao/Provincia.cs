using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S16_Dao;
public class Provincia

{

    public int Id { get; set; }

    public int Id_Regione { get; set; }

    public int Codice_Citta_Metropolitana { get; set; }

    public string Nome { get; set; }

    public string Sigla_Automobilistica { get; set; }

    public decimal Latitudine { get; set; }

    public decimal Longitudine { get; set; }

    public override string? ToString()

    {

        return $"{GetType().Name}: Id provincia = {Id}, Id regione = {Id_Regione}, Codice_Citta_Metropolitana = {Codice_Citta_Metropolitana}, Nome provinicia = {Nome}, (Prov) = {(Sigla_Automobilistica)},  Latitudine provincia = {Latitudine}, Longitudine provincia = {Longitudine};";

    }

    public Provincia()

    { //Costruttore di default, obbligatorio

    }

    public Provincia(int id, int id_Regione)

    {

        this.Id = id;

        this.Id_Regione = id_Regione;

    }

    public Provincia(int id, int id_Regione, int codice_Citta_Metropolitana, string nome, string sigla_Automobilistica, decimal latitudine, decimal longitudine)

    {

        Id = id;

        Id_Regione = id_Regione;

        Codice_Citta_Metropolitana = codice_Citta_Metropolitana;

        Nome = nome;

        Sigla_Automobilistica = sigla_Automobilistica;

        Latitudine = latitudine;

        Longitudine = longitudine;

    }

}
