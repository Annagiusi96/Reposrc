namespace S10_Utility
{
    internal class Program
    {
        static void Main()
        {
            GeneratorePassword psw = new(10);
            string p1 = psw.GeneraPsw();
            Console.WriteLine(p1);

            GeneratorePassword2 psw2 = new(10);
            string p2 = psw2.GeneraPass();
            Console.WriteLine("psw generata con generaPass:" + p2);

            //effetto su array
            //array è un oggetto e qundi è un reference type
            //creo array di caratteri
            //istanzio array utilty usa metodo shuffle e passo arrayCaratteri
            //questo è un pass di un oggetto quindi è by reference
            //siccome è un oggetto riceve un reference e quindi lo shuffle mi modifica l'oggetto originale

            //prende in input un array e lo mescola
            char[] arrayCaratteri = ['a', 'b', 'c', 'd', 'e', 'f', 'g'];
            ArrayUtility a1 = new();
            a1.Shuffle(arrayCaratteri);
            foreach (char item in arrayCaratteri)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            //qui viene ritornato una copia dell array sorgente e quello originale nn viene toccato
            arrayCaratteri = ['a', 'b', 'c', 'd', 'e', 'f', 'g'];
            char[] arraymescolato = ArrayUtility.ShuffleReturn(arrayCaratteri);//ralizza una copia in ingresso, l'array originale  nn è piu modificato
            
            foreach (char item in arrayCaratteri)//array originale nn viene toccato
            {
                Console.Write(item);
            }

            foreach (char item in arraymescolato)//array mescolato
            {
                Console.Write(item);
            }

            TombolaI tt1 = new();
            for(int i = 0; i < 90; i++)
            {
                Console.WriteLine($"Tombola estratto {tt1.estrai()}");
            }
        }
    }
}
