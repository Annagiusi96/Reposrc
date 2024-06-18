//Environment.Exit(0); ferma il programma qua

//ESERCIZI CON IF:

/*generare un numero intero random compreso tra 0 e 200.
2) Stampare “il numero è pari” se il numero casuale è pari, oppure stampare “il numero è dispari” in caso opposto.*/

using System.Diagnostics;
Console.WriteLine("*******************************************************************************");

int numeroArrivo = Random.Shared.Next(100, 301);
int numeroPartenza = Random.Shared.Next(100, 301);
Console.WriteLine($"partenza: {numeroPartenza}, arrivo {numeroArrivo}");

if (numeroArrivo < numeroPartenza)
{
    int swap = numeroArrivo;
    numeroArrivo = numeroPartenza;
    numeroPartenza = swap;
}

Console.WriteLine($"partenza: {numeroPartenza}, arrivo {numeroArrivo}");

int contatoreSomma = 0;
for (; numeroPartenza <= numeroArrivo; numeroPartenza++)
{
    int numeroTest = Random.Shared.Next(500);
    if (numeroTest >= numeroPartenza && numeroTest <= numeroArrivo)
    {
        if (numeroTest % 2 == 0)
        {
            Console.WriteLine($"numerotest pari: {numeroTest}, contatoreSomma: {contatoreSomma += numeroTest * 2}");
        }
        else
        {
            Console.WriteLine($"numerotest dispari: {numeroTest}, contatoreSomma: {contatoreSomma += numeroTest / 2}");
        }
        if (numeroTest % 3 == 0)
        {
            Console.WriteLine($"numerotest multiplo di 3: {numeroTest}, contatoreSomma: {contatoreSomma -= 3}");
        }
    }
}

Console.WriteLine($"Il valore finale del contatoreSomma è: {contatoreSomma}");

Console.WriteLine("*******************************************************************************");


int numeroRandom = Random.Shared.Next(0, 200);
if (numeroRandom % 2 == 0)
{
    Console.WriteLine($"Il numero {numeroRandom} è pari");
}
else
{
    Console.WriteLine($"Il numero {numeroRandom} è dispari");
}

/*
 WHILE (condiz bool). Se viene valutata a true, il ciclo viene ripetuto (condizione di permanenza del ciclo)
 */

//ESERCIZI CON WHILE:

/*Definire un contatore intero inizializzato a zero.
Ad ogni ciclo incrementare di 2 il valore del contatore.
Ripetere il ciclo 10 volte
Alla fine stampare il valore più elevato calcolato (=ultimo valore del contatore)*/

int contatoreNumeroGenerazioni = 0;
int i = 0;
while (i < 10)
{
    contatoreNumeroGenerazioni += 2;
    i++;
}
Console.WriteLine($"Ultimo valore del contatore è: {contatoreNumeroGenerazioni}");

/*Definire un contatore intero inizializzato a zero.
Ad ogni ciclo incrementare di una quota random (casuale) compresa tra 0 e 100 il valore del contatore.
Uscire dal ciclo quando il contatore è > 1000
Stampare il valore del contatore*/

int contatoreGenerazioniRandom = 0;

while (contatoreGenerazioniRandom <= 1000)
{
    contatoreGenerazioniRandom += Random.Shared.Next(100);
}

Console.WriteLine($"Il valore del contatore all'uscita del ciclo è: {contatoreGenerazioniRandom}");

contatoreGenerazioniRandom = 0;

while (true)
{
    contatoreGenerazioniRandom += Random.Shared.Next(100);
    if (contatoreGenerazioniRandom > 1000)
    {
        break; //go to alla prima istruzione dopo la graffa chiusa
    }
}

Console.WriteLine($"Il valore del contatore all'uscita del ciclo è: {contatoreGenerazioniRandom}");



int contatore2 = 0;
int random = Random.Shared.Next(0, 100); // 1 sola volta per tutto il ciclo

while (contatore2 <= 1000)
{
    random = Random.Shared.Next(0, 100); // 1 sola volta per tutto il ciclo
    contatore2 = contatore2 + random;
}

Console.WriteLine("valore del contatore " + contatore2);

/*string s = “Hello World”;
H è il carattere alla posizione 0
e è il carattere alla posizione 1
D è il carattere alla posizione s.Length-1
Data la stringa s calcolare una nuova stringa t che contenga la s reversata
string t = “dlroW olleH”;*/

//SUBSTRING (int,int) accetta due parametri, il primo è l'indice di inizio del caratt e il secondo è l'indice di fine del caratt
string s = "Hello World";
string t = "";
int lunghezza = s.Length - 1;

//finchè la lunghezza è magg o uguale a 0, mi esegui il loop
while (lunghezza >= 0)
{
    t += s.Substring(lunghezza, 1);
    lunghezza--;
}
Console.WriteLine(t);

t = "";
lunghezza = 0;
while (lunghezza < s.Length)
{
    t = s.Substring(lunghezza, 1) + t;
    lunghezza++;
}
Console.WriteLine(t);

Console.WriteLine(s.Substring(0, 1));

Console.WriteLine("******************************************************");

//ES FIZZ BUZZ
//stampa i num da 1 a 100. Ma per i multpili di 3 e 5 stampa fizzbuzz, per i multipli di 3 stampa fizz e per i multipli di 5 stsmpa buzz
Console.WriteLine("fizz buzz con while:");

int indx = 1;
while (indx <= 100)
{
    if (indx % 3 == 0 && indx % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (indx % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (indx % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(indx);
    }
    indx++;
}

/*Definire due contatori uno per i numeri pari ed un per i numeri dispari.
Ripetere il ciclo 1000 volte, alla fine del ciclo stampare il numero dei valori pari generati in modo 
random ed il corrispondente numero di numeri dispari sempre generati in modo random.*/

int contatoreNumeriPari = 0;
int contatoreNumeriDispari = 0;
int indiceCiclo = 0;
int randomNum;
while (indiceCiclo < 1000)
{
    randomNum = Random.Shared.Next(100);
    if (randomNum % 2 == 0)
    {
        contatoreNumeriPari++;
    }
    else
    {
        contatoreNumeriDispari++;
    }
    indiceCiclo++;
}

Console.WriteLine($"Sono stati generati {contatoreNumeriPari} numeri pari");
Console.WriteLine($"Sono stati generati {contatoreNumeriDispari} numeri dispari");

/*Definire due contatori uno per i numeri pari ed un per i numeri dispari.
Ripetere il ciclo sino a quando sono stati generati 1000 numeri pari e 970 numeri dispari
Alla fine del ciclo stampare il numero dei valori pari generati in modo random ed il corrispondente numero di numeri dispari*/

contatoreNumeriPari = 0;
contatoreNumeriDispari = 0;
indiceCiclo = 0;
while (true)
{
    randomNum = Random.Shared.Next(100);
    if (randomNum % 2 == 0)
    {
        contatoreNumeriPari++;
    }
    else
    {
        contatoreNumeriDispari++;
    }
    indiceCiclo++;
    if (contatoreNumeriPari == 1000 && contatoreNumeriDispari == 970)
    {
        break;
    }
}

Console.WriteLine($"Sono stati generati {contatoreNumeriPari} numeri pari");
Console.WriteLine($"Sono stati generati {contatoreNumeriDispari} numeri dispari");


//FOR() prende 3 parametri separati da ; equivale a dire while(true) => forever
/*
 WHILE e FOR
 */

//ESERCIZI COL FOR:

//ES riscrivere il fizzbuzz col FOR
Console.WriteLine("fizz buzz con for:");
for (int indice = 1; indice <= 100; indice++)
{
    if (indice % 3 == 0 && indice % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (indice % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (indice % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(indice);
    }
}



//REGOLA PRINCIPALE:tutti i numeri da generare random devono essere generati in un intervallo che parte da 100 e termina a 300
/*
 - generare il numero di partenza (pre-condizione)
- generare il numero di arrivo (per il test di fine loop)
- generare un numero compreso tra 0 e 500, se il numero cade nell'intervallo considerato dal loop (tra 100 e 300),  stampare il numero
 e se il num è pari sommare il doppio al contatore, 
se il num è dispari sommare la metà al contatore, 
se il num è multiplo di 3 sottrarre 3 al contatore.
alla fine stampare il valore del contatore

generare il numero di partenza e il num di arrivo (arrivo potrebbe ess > di partenza (ok) 
oppure arrivo < di partenza (devo decrementare e testare che la partenza sia min dell'arrivo) oppure si può fare lo swap dei numeri,
ovvero lo scambio di arrivo con partenza
o arrivo = partenza stampa 0)
 */

//swap ESEMPIO
int k1 = 100;
int k2 = 200;
int temp = k1;
k1 = k2;
k2 = temp;

