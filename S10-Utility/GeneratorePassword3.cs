using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Utility;

internal class GeneratorePassword3
{
    public class GeneratoreDiPassword
    {
        //Dichiaro le stringhe che mi interessano
        private static readonly string _lettereMaiuscole = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _lettereMinuscole = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string _numeri = "0123456789";
        private static readonly string _simboli = "@#?=";

        //Concateno le stringhe che mi interessano
        private static readonly string _tuttiICaratteri = _lettereMaiuscole + _lettereMinuscole + _numeri + _simboli;
        private int _lunghezza;

        public GeneratoreDiPassword()
        { //Costruttore di default
        }

        public int Lunghezza
        { //Property
            get { return _lunghezza; }
        }
        public string GeneraPassword(int length)
        {
            StringBuilder password = new StringBuilder();

            password.Append(_lettereMaiuscole[Random.Shared.Next(_lettereMaiuscole.Length)]);
            password.Append(_lettereMinuscole[Random.Shared.Next(_lettereMinuscole.Length)]);
            password.Append(_numeri[Random.Shared.Next(_numeri.Length)]);
            password.Append(_simboli[Random.Shared.Next(_simboli.Length)]);

            // Riempire il resto della password con caratteri casuali
            for (int i = 4; i < length; i++)
            {
                password.Append(_tuttiICaratteri[Random.Shared.Next(_tuttiICaratteri.Length)]);

                //Console.WriteLine($"Ciao sono una stringa : {password.Append(_tuttiICaratteri[Random.Shared.Next(_tuttiICaratteri.Length)])}");

            }
            //char [] passwordArray = new char[password.Length];
            char[] passwordArray = password.ToString().ToCharArray();


            for (int i = 4; i < passwordArray.Length - 1; i++)
            {
                //Faccio lo swap e in questo modo scambio le lettere
                int j = Random.Shared.Next(i + 1);
                var temp = passwordArray[i];
                passwordArray[i] = passwordArray[j];
                passwordArray[j] = temp;
            }
            return new string(passwordArray);
        }
    }
}
