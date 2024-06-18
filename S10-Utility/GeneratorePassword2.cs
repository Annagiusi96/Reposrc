using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Utility;
public class ArrayUtility
{
    //può essere tranquillam void e nn avere ritorno, funziona lo stesso,
    //qst perche il valore viene passato by reference
    //do per scontato che loggetto venga ricevuto e modificato l array originale in ingresso
    public void Shuffle(char[] inputArray)
    {
        for (int i = 4; i < inputArray.Length - 1; i++)
        {
            //Faccio lo swap e in questo modo scambio le lettere
            int j = Random.Shared.Next(i + 1);
            var temp = inputArray[i];
            inputArray[i] = inputArray[j];
            inputArray[j] = temp;
        }
    
    }

    //l'inputarray serve come promotore del lavoro ma che l'output sia elaborato ma nn modifichi l'array orginale
    //qui devo asumere che l oggetto in ingresso nn venga modificato
    //xke mi si chiede un oggetto in uscita dello stesso tipo
    //se voglio che il dato originale non venga toccato ma ho bisogno di elaborarlo allora uso il return
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
            var temp = arrCopy[i];
            arrCopy[i] = arrCopy[j];
            arrCopy[j] = temp;
        }
        return arrCopy; //ritorno array copia dell originale mescolato
    }

  
}
public class GeneratorePassword2
{
    private int _lunghezzaPsw = 0;
    private static string caratteriSpeciali = "@#?=+";
    private static string lettere = "abcdefghilmnopqrstuvz";
    private string _tuttiCaratteri = $"{caratteriSpeciali}{lettere}{lettere.ToUpper()}{Random.Shared.Next(10)}";
    public GeneratorePassword2(int lunghezzaPsw)
    {
        _lunghezzaPsw = lunghezzaPsw;
    }

    public string GeneraPass()
    {
        char[] chs = ArrayUtility.ShuffleReturn(_tuttiCaratteri.ToCharArray());

        //mescolo la stringa originale e la mescolo e la metto in chs

        // char[] inputArray = _tuttiCaratteri.ToCharArray();
        // char[] arrayMescolato = ArrayUtility.ShuffleReturn(inputArray);
        string generata = "";

        for (int i = 0; i < _lunghezzaPsw; i++)
        {
            int random = Random.Shared.Next(chs.Length);
            generata += chs[random];
        }
        return generata;
    }

    //base di calcolo => random => psw generata => shuffle

    //base di calcolo => shuffle => base di calcolo mescolata => genera password => psw


}
//creto to char arraycreato
//chiamo classe arrayutility.shuffle(arraycreato) che mescola array
//passwordarray = arrayutility.shuffle(passwordarray)
