using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12_Contenitori;

public class MescolatoreTradizionale
{
    //a seconda del tipo di dati chiamo lo shuffle che mi serve
    //o char[] o int[]

    //avremmo dovuto fare uno shuffle per char, uno per interi, per questo usiamo i generics in mescolatoreclass

    public static char[] ShuffleReturn(char[] inputArray)//fa una copia del dato in ingresso 
    {
        char[] arrCopy = new char[inputArray.Length]; //defense copy per salvaguardare l'oggetto 
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            arrCopy[i] = inputArray[i];
        }
        //copio array d input in quello di output ovvero in copy
        //poi elaboro solamente l array di output

        for (int i = 4; i < arrCopy.Length - 1; i++)
        {
            //Faccio lo swap e in questo modo scambio le lettere
            int j = Random.Shared.Next(i + 1);
            char temp = arrCopy[i];
            arrCopy[i] = arrCopy[j];
            arrCopy[j] = temp;
        }
        return arrCopy; //ritorno array copia dell originale mescolato
    }

    public static int[] ShuffleReturn(int[] inputArray)//fa una copia del dato in ingresso 
    {
        int[] arrCopy = new int[inputArray.Length]; //defense copy per salvaguardare l'oggetto 
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            arrCopy[i] = inputArray[i];
        }
        //copio array d input in quello di output ovvero in copy
        //poi elaboro solamente l array di output

        for (int i = 4; i < arrCopy.Length - 1; i++)
        {
            //Faccio lo swap e in questo modo scambio le lettere
            int j = Random.Shared.Next(i + 1);
            int temp = arrCopy[i];
            arrCopy[i] = arrCopy[j];
            arrCopy[j] = temp;
        }
        return arrCopy; //ritorno array copia dell originale mescolato
    }
}
