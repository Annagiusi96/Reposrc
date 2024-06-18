using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12_Contenitori;

public class MescolatoreParametrico<T>
{
    //SOSTITUENDO IL T, ho un placeholder, in cui posso cambiare il tipo a seconda di quello che mi serve
    public T[] ShuffleReturn(T[] inputArray)//fa una copia del dato in ingresso 
    {
        T[] arrCopy = new T[inputArray.Length]; //defense copy per salvaguardare l'oggetto 
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
            T temp = arrCopy[i];
            arrCopy[i] = arrCopy[j];
            arrCopy[j] = temp;
        }
        return arrCopy; //ritorno array copia dell originale mescolato
    }
}
