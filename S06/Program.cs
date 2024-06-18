//gli array in c# sono "rigidi": una volta stabilita la dimensione questa rimane.
//Se viene utilizzato un indice oltre la capacità disponibile, viene generata un'Exception (un errore bloccante)
//generare un array di interi di 1000 elementi riempito con valori casuali
//- dobbiamo copiare i 1000 elementi in un altro array di inizialmente 100 elementi
//espandendolo quando la capacità manca, di 100 el per volta

/*
 Gli array in C# sono “rigidi”: una volta stabilita la dimensione questa rimane. Se viene utilizzato un indice oltre la capacità disponibile, viene generata un’Exception (un errore bloccante).
- Generare un array di interi di 1000 elementi riempito con valori casuali.
- Copiare i 1000 elementi in un altro array di inizialmente 100 elementi espandendolo, quando la capacità manca, di 100 elementi per volta.
 */

using System.Runtime.ConstrainedExecution;

int[] arr = new int[10];

for (int i = 0; i < arr.Length; i++)
{
    //arr[i] = Random.Shared.Next(1, 1001);
    arr[i] = i;
}
int[] arrCopy = new int[100];
int index = 0;

for (int i = 0; i < arr.Length; i++)
{
    if (index >= arrCopy.Length)
    {
        //Console.WriteLine($"Prima della variazione: {arrCopy.Length}");
        Array.Resize(ref arrCopy, arrCopy.Length + 100);
        //Console.WriteLine($"Dopo della variazione: {arrCopy.Length}");
    }
    arrCopy[i] = arr[i];
    index++;
}

for (int i = 0; i < arrCopy.Length; i++)
{
    //Console.WriteLine($"arrCopy: indice:({i}) valore:({arrCopy[i]})");
    // Console.WriteLine($"ARR: indice:({i}) valore:({arr[i]})");
}

/*--Per mescolare un array a di n elementi (indici 0.. n -1):
 per i  da  n −1 fino a 1 fare 
     j ← intero casuale tale che 0 ≤ j ≤ i 
     scambiano a [j] e a[i]*/

/*--Per mischiare un array a di n elementi (indici 0.. n -1):
 per i  da 0 a  n −2 fare 
     j ← intero casuale tale che i ≤ j < n 
     scambiare a [i] e a[j]*/


for (int i = arr.Length - 1; i >= 1; i--)
{
    int j = Random.Shared.Next(i + 1);
    Console.WriteLine($"PRIMA arr[j]: {arr[j]}, arr[i]: {arr[i]}");
    int temp = arr[j];
    arr[j] = arr[i];
    arr[i] = temp;
    Console.WriteLine($"DOPO arr[j]: {arr[j]}, arr[i]: {arr[i]}");
}

for(int i = 0; i < arr.Length; i++)
{
    Console.WriteLine(arr[i]);
}

