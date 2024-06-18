using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07_OOP_primo;
//sto dicendo che se voglio racchiudere tutte le figure in qst classe
//sto dicendo che posso calcolare area e perimetro in generale per tutte le sottoclassi
//se nn metto il calcolo dell area o del perimetro non ha senso creare la classe figurageometrica,
//quindi sono costretto a metterle, sennò nn ha senso di esistere la figura geometrica
//ma nello stesso tempo nn posso creare qst metodi generali per tutte le figure derivate

//in qst caso ci viene utile il tipo ABSTRACT
//sono creati per cnsentirci di creare gerarchie complete.
//conviene che il top di una gerarchia sia sempre una classe astratta e racchiuda le caratteristiche di quella gerarchia

//***una classe astratta rappresenta un tipo realmente esistente (o di comodo) non istanziabile perchè troppo generico***
public abstract class FigureGeometriche
{
    public abstract double Area();
    public abstract double Perimetro();
}
