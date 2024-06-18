namespace S07_OOP_primo;

//quando creo una classe mi concentro sullo scopo dell'oggetto, non su com'è fatto
public class Matita
{
    public void Scrivere(string testo)//scopo della classe
    {
        Console.WriteLine(testo);
    }
    public void Disegnare(string disegno)//scopo della classe
    {
        Console.WriteLine(disegno);
    }
}
//Scrivere e Disegnare sono due metodi della classe Matita che accettano un parametro stringa ciascuno

/*
 quando abbiamo una class che descrive tutte le matite, in realtà noi abbiamo bisogno di una singola matita
 bisogna CREARE UN'ISTANZA tramite la parola chiave NEW
 Con NEW possiamo passare da un modello (class) a un oggetto
 l'OGGETTO è detto così infatti ISTANZA DELLA CLASSE (matita nel ns caso)

La CLASSE è un progetto/modello sulla base del quale vengono create tutte le istanze
e rappresenta un TIPO di dato

Non può esistere un oggetto senza una sua classe
 */



