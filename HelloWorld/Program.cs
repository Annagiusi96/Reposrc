// See https://aka.ms/new-console-template for more information
/*
 * commento multiriga
 */
//commento singola riga

Console.WriteLine/*infilo un commento*/("Hello, World!");
//Console è un OGGETTO per c#
//WriteLine è un METODO
//il punto fa da tramite e viene chiamato MESSAGE(seleziona). Unisce l'oggetto al metodo. Individua un elemento all'interno di un oggetto
//"" string delimiter 
//() il contenuto nelle parentesi è identificato come un ARGOMENTO

Console.WriteLine("Ciao Mondo");
Console.WriteLine("*********\n*       *\n*       *\n*  ***  *\n*       *\n*       *\n*********");

// \t carattere di tabulazione (tab) mette gli spazi
// \n new line, va accapo 
// \ backslash indica al compilatore di smettere il riconoscimento dei caratteri. In slang si chiama carattere di escape (interpreta n come new line)
// se voglio far vedere in console un backslash, allora devo farne uno doppio

Console.WriteLine("Digitare il nome");
//Console.ReadLine(); //legge una riga di caratteri fino a quando non vai accapo

//Console.WriteLine("Ciao il mio nome è " + Console.ReadLine());

//altro modo per concatenare le stringhe (template string)
//l'espressione nelle {} viene valutata prima e il risultato prende il posto delle {}

Console.WriteLine($"Il mio nome è {Console.ReadLine()}");

//in qt modo scriviamo la stringa AS IS, così com'è, ovvero così come l'ho scritta, con la stessa formattazione
Console.WriteLine(@"
                Nel mezzo 
                del cammin
                di nostra vita
                ...
");

//posso anche combinare sia @ che $

Console.WriteLine("Digita il cognome");
Console.WriteLine($@"
            Il mio cognome è
            {Console.ReadLine()}
");
//Console.WriteLine("*********\n*       *\n*       *\n*  ***  *\n*       *\n*       *\n*********");
//fare lo stesso esercizio con la @ spostato di due tab verso dex

Console.WriteLine(@"
        *********
        *       *
        *       *
        *  ***  *
        *       *
        *       *
        *********
");
