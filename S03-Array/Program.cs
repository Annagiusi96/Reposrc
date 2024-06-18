//array

int[] arr; //array di interi
string[] nomi; //array di stringhe

arr = new int[5]; //dimensiono arr per contenere 5 posizioni
nomi = new string[3];

//popolare l'array
arr[0] = Random.Shared.Next(100);
arr[1] = Random.Shared.Next(100);
arr[2] = Random.Shared.Next(100);
arr[3] = Random.Shared.Next(100);
arr[4] = Random.Shared.Next(100);

//popolare array stringhe
nomi[0] = "luca";
nomi[1] = "mario";
nomi[2] = "giulia";

//posso farlo tutto in una riga:

string[] cognomi = new string[3]{"rossi","bianchi","neri"}; //se lo dichiaro,dimensiono e popolo voglio le {}

int[] arr2 = new int[6] { 0, 6, -3, Random.Shared.Next(100), 22, -33 }; //creare un arr, lo dimensioni e lo popolo insieme
//tra {} forniamo elenco dei valori che devono essere piazzati nell'arr2

string[] auto = ["punto","ferrari","audi"]; //se non lo dimensiono allora uso [] 
int[] arr3 = [0, 6, -3, Random.Shared.Next(100)];

//ma posso usare anche le {} (versioni prima di .net 8)
string[] marche = {"nokia","apple","deg"};


//*************************************************************************************************************************
//SCORRERE ARRAY AVANTI E INDIETRO!!! N.B.

for (int i = 0; i < arr2.Length; i++) //loop standard per scorrere un array in avanti
{
    Console.WriteLine($"posizione= {i}, valore={arr2[i]}");
}

for (int i = arr2.Length - 1; i >= 0; i--) //loop standard per scorrere un array all'indietro
{
    Console.WriteLine($"posizione= {i}, valore={arr2[i]}");
}
//*************************************************************************************************************************

//FOREACH mi scorre tutto l'array

foreach(string marca in marche)
{
    //Console.WriteLine(marca);
}

foreach(int num in arr)
{
    //Console.WriteLine(num);
}

//****************************************************************************************************************************

//ESERCIZIO
//Creare un array di 100 interi riempiti con i valori da 1 a 100. Elaborare l'array secondo la logica fizz buzz

Console.WriteLine("*************ES 1 ARRAY************\n");
int[] arr4 = new int[100];

for (int i = 0; i < arr4.Length; i++)
{
    arr4[i] = i + 1;
}

for (int i = 0; i < arr4.Length; i++)
{
    if (arr4[i] % 3 == 0 && arr4[i] % 5 == 0)
    {
        Console.WriteLine("Fizz Buzz");
    }
    else if (arr4[i] % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (arr4[i] % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(arr4[i]);
    }
}

//creare un array di 100 interi, inizializzare ogni cella con un valore pari al triplo della posizione della cella
//(es. posizione=9, valore cella=27)
//eventuale loop per la stampa di controllo dei valori inseriti
//partendo dalla posizione 0 sino alla fine dell'array calcolare:
//la somma dei valori contenuti nelle celle
//la somma dei valori pari contenuti nelle celle 
//la somma dei valori dispari contenuti nelle celle 
//alla fine stampare le tre somme
Console.WriteLine("*************ES 2 ARRAY************\n");

int[] arr5 = new int[100];

//popolo array
for (int i = 0; i < arr5.Length; i++)
{
    arr5[i] = i * 3;
    Console.Write(arr5[i] + "-");//stampo valori di controllo
}
Console.WriteLine("*****************************************************\n");

int sommaTot = 0;
int sommaPari = 0;
int sommaDispari = 0;

for (int i = 0; i < arr5.Length; i++)
{
    sommaTot += arr5[i];

    if (arr5[i] % 2 == 0)
    {
        sommaPari += arr5[i];
    }
    else
    {
        sommaDispari += arr5[i];
    }
}

Console.WriteLine($"La somma dei valori totali è: {sommaTot}");
Console.WriteLine($"La somma dei valori pari è: {sommaPari}");
Console.WriteLine($"La somma dei valori dispari è: {sommaDispari}");

/*
 //creare un array di 100 interi, inizializzare ogni cella con un valore pari al triplo della posizione della cella
//(es. posizione=9, valore cella=27)

- partendo dalla metà dell'array (posizione 50) tornando indietro alla posizione 0, sommare i numeri ad indice pari
(indice 50,48,46)
- partendo dalla metà dell'array (posizione 50) andando verso l'ultima posizione, procedendo con incremento pari a 3
(indice: 50,53,56..), sommare i valori pari
- stampare il valore delle due somme
 */
Console.WriteLine("*************ES 3 ARRAY************\n");

int[] arr6 = new int[100];

//popolo array
for (int i = 0; i < arr6.Length; i++)
{
    arr6[i] = i * 3;
}

int sommaPariConDecrementoDiDue = 0;
int sommaPariConIncrementoDiTre = 0;
int metaArray = arr6.Length / 2;

//decremento partendo da metà
for (int i = metaArray; i >= 0; i -= 2) //correzione, non era i--
{
    if (i % 2 == 0) //considero la i
    {
        sommaPariConDecrementoDiDue += arr6[i];
    }
}

//incremento di 3 partendo da metà
for (int i = metaArray; i < arr6.Length; i += 3)
{
    if (arr6[i] % 2 == 0)
    {
        sommaPariConIncrementoDiTre += arr6[i];
    }
}

Console.WriteLine($"La somma dei valori pari con indice decrementato di 1 è di: {sommaPariConDecrementoDiDue}");
Console.WriteLine($"La somma dei valori pari con indice incrementato di 3 è di: {sommaPariConIncrementoDiTre}");
Console.WriteLine($"La somma totale è di: {sommaPariConIncrementoDiTre + sommaPariConDecrementoDiDue}");


//se dobbiamo scorrere tutto l'array in avanti usiamo il foreach

//esercizio: data la stringa Hello World tramite for o while realizzare la stringa inversa
//fare la medesima cosa trattando str tramite foreach
Console.WriteLine("************************************************************\n");

string str = "Hello World";
string inversaConFor = "";

for (int index = str.Length - 1; index >= 0; index--)
{
    inversaConFor += str[index];
}
Console.WriteLine($"stringa inversa col for: {inversaConFor}");

string inversaConForeach = "";
int indx = str.Length - 1;

foreach (char el in str) //foreach usato come scorrimento e non come valore
{
    inversaConForeach += str[indx];
    indx--;
}
Console.WriteLine($"stringa inversa col foreach: {inversaConForeach}");

//soluzione prof:
string inversaSoluzioneProf = "";

foreach (char el in str)
{
    inversaSoluzioneProf = el + inversaSoluzioneProf;
}

char[] chrs = new char[str.Length];

for (int indicestringaInversa = str.Length - 1; indicestringaInversa >= 0; indicestringaInversa--)
{
    chrs[indicestringaInversa] = str[str.Length - indicestringaInversa - 1];
    //Console.WriteLine($"Indice di stringa inversa: {indicestringaInversa} reverse = {str.Length - indicestringaInversa - 1}");
}
string strInversa = new string(chrs);
//Console.WriteLine(strInversa);

int isi = str.Length - 1;
char [] chars = new char[str.Length];

foreach (char item in str)
{
    chars[isi--] = item;
}
strInversa = new string(chars);
//Console.WriteLine(strInversa);


