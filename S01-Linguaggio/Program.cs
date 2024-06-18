//espressioni in c#
//un programma è costituito da una sequenza di queste espressioni

int num1 = 10;
long num2 = 10;
float num3 = 10.4f;
double num4 = 10.4;
bool bo = false;
char carattere = 'a';
string stringa = "ciao";

Console.WriteLine($"int.getType() {num1.GetType()}");
Console.WriteLine($"long.getType() {num2.GetType()}");
Console.WriteLine($"float.getType() {num3.GetType()}");
Console.WriteLine($"double.getType() {num4.GetType()}");
Console.WriteLine($"bool.getType() {bo.GetType()}");
Console.WriteLine($"char.getType() {carattere.GetType()}");
Console.WriteLine($"string.getType() {stringa.GetType()}");


int x = 10 + 45; //espressione numerica che coinvolge dati di tipo int (intero)
bool booleano = false; //(contiene solo valori vero o falso)

//(SIMPLE TYPE: dati che contengono un'unica informazione)
//int, long, float, double, char (è carattere nativamente trattato come un numero), bool

string s = "Hello" + " " + "World";

Console.WriteLine($"La stringa {s} è lunga {s.Length} caratteri");

//(REFERENCE TYPE)
//- string è una composizione di più caratteri
//- Console (ogni oggetto è un reference type)

//POINTER TYPE
//estensioni che consentono una manipolazione diretta agli archivi di memoria
//(vengono evitati quando si lavora in OOP)


//ESPRESSIONI DI ASSEGNAZIONE
//a sinistra abbiamo la cosiddetta LEFT SIDE
//a dex abbiamo la RIGHT SIDE (la parte che deve essere valutata)
//il risultato della valutazione della right side va a finire nella left side

//LEFT SIDE è composta da due sezioni: int x =
//x : nome della variabile (maschera che nasconde il fatto che ci sia una memoria occupata dai bit da qualche parte)
//una variabile è un pezzo di bit che occupano nella memoria
//in c# le variabili sono fortemente tipizzate 

//int : data type (forniscono tipi di dato)

/*OPERATORE +
 * - TRA NUMERI: effettua la somma degli addendi
 * - TRA UNA STRINGA: e "qualcosa d'altro" trasforma il qlcs d'altro in una stringa e concatena i due elementi
 * (si privilegia la stringa xke è human readble)
 * 
 * Abbiamo dunque un comportamento OVERLOADED (con più effetti collaterali/significati) dell'operatore +
 * 
 * In c# è possibile avere degli operatori overloaded
*/

/* TIPI DI DATO 'BUILT-IN'
 * CHAR carattere in formato unicode. 
 * SHORT 16 bit
 * INT 32 bit
 * LONG 64 bit
 * FLOAT virgola mob 32 bit
 * DOUBLE virgola mob 63 bit
 * 
 */

double d1 = 100.78;
double d2 = 3254.09;

Console.WriteLine($"Risultato di {d1} + {d2} = {d1 + d2}");
/* Il risultato è 3354,8700000000003. Come mai ho questo 00003 ?
 * 
 * Se ho a che fare con un intero, partendo dall'intero ottengo una rappresentazione in base 2 (binaria in bit) assolutamente esatta
 * 123 => conversione in bit 1111011 (se facciamo la conversione opposta otteremo esattam il num 123)
 * 
 * Le rappresentazioni in virgola mobile, invece,  sono sempre approssimate tramite l'utilizzo di un algoritmo 
 * (insieme di passi logici e fisici che portano un sistema da uno stato all'altro) che tenderà a comprimere il numero
 * 
 * FLOAT e DOUBLE sono sempre in virgola mobile, quindi i numeri verranno approssimati
 * Nell'esempio.: il num di partenza => serie di bit // la serie di bit => num di partenza diverso
 * 
 * (virgola fissa: il num ha sempre tot numeri di decimali e verrà sempre trattato così)
 * In ambito monetario si lavora in virgola fissa e arrotondamenti fissi
 */

x = (int)((d1 + d2) * 100);
Console.WriteLine(x); //335487
Console.WriteLine(x / 100.0); //3354,87
Console.WriteLine(x / 100); //3354

/* CAST => (conversione forzata di tipo) Utilizzabile solo se i tipi sono compatibili
 * ES => x = (int) ((d1 + d2) * 100). 
 * con (int) eseguiamo un operazione di cast 
 * 
 * Se scrivo x = (int) (d1 + d2) * 100; viene prima eseguita la somma e poi il cast perchè
 * il cast ha una priorità maggiore rispetto alla moltiplica, x qst mettiamo le parentesi tonde
 * 
 * TIPO AUTOMATICO ASSEGNATO
   Console.WriteLine(x / 100); //3354 qst viene considerato INT xke non ha il punto (decimali)
 * Console.WriteLine(x / 100.0); //3354,87 qst viene considerato DOUBLE xke ha i decimali
 * 
 * Qualsiasi numero con la virgola, per default => DOUBLE
 * Qualsiasi numero senza la virgola, per default => INT
 
 */

//float: 32 bit
//double: 64 bit

long y = 100; //conversione automatica da 32 a 64 bit (dal piu piccolo al piu grande lo fa da solo int a long)

float f = 56.65f; //qui il tipo va esplicitato, dobbiamo aggiungere F

decimal dd = 123.33m; //il tipo decimal vuole la M obbligatoriamente (M => monetary) (128 bit)

//ESERCIZIO

Console.WriteLine("Inserisci una parola");
string a = Console.ReadLine();
string b = a;
Console.WriteLine($"Il valore della variabile B è: {b}");

//ESERCIZIO: eliminare gli spazi all'inizio e alla fine
string prova = "  xx  yy  ";
Console.WriteLine(prova.Trim().GetType());

//TRIM() da solo elimina gli spazi in testa e in coda
//se passo un parametro TRIM('*') mi va a togliere tutti gli * in testa e in coda
/* In questo caso il metodo trim è OVERLOADED
 * qst metodo ha lo stesso nome ma può avere parametri diversi
 */
//

Console.WriteLine("********Hello******".Trim('*'));


//VAR:
//var si dichiara una variabile in maniera piu flessibile ma nn è consigliato

var v1 = 65;
Console.WriteLine($"Tipo di dato associato a v1: {v1.GetType()}"); //system int32

var v2 = "Hello";
Console.WriteLine($"Tipo di dato associato a v1: {v2.GetType()}"); //system string

/////////////////////////////////////////////////////////////////////////////////////////////
//int32 rappresenta un intero a 32 bit
//simple type in c# sono degli oggetti rispetto ai dati nativi di java che sono i dati elaborati dalla cpu
55.GetType(); //in java non posso applicare un metodo a un numero direttamente