using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Utility;

/*costruire un generatore di psw
partendo dalle stringhe lettere minuscole, lettere maiuscole, numeri e "@#?=+"
scrivere una classe in grado di istanziare un generatore di psw di lunghezza desiderata*/

public class GeneratorePassword
{
    private int _lunghezzaPsw = 0;
    private char[] chars = ['@', '#', '?', '=', '+'];
    private char[] letters = ['a','b','c','d','e','f','g','h','i','l','m','n','o','p','q','r','s','t','u','v','z'];
    public GeneratorePassword(int lunghezzaPsw)
    {
        _lunghezzaPsw = lunghezzaPsw;
    }

    private char GeneraChar()
    {
        char randomChar = chars[Random.Shared.Next(chars.Length)];
        return randomChar;
    }

    private char GeneraLetterMin()
    {
        char randomLetterMin = letters[Random.Shared.Next(letters.Length)];
        return randomLetterMin;
    }

    private string GeneraLetterMaisc()
    {
        string randomLetterMaisc = letters[Random.Shared.Next(letters.Length)].ToString().ToUpper();
        return randomLetterMaisc;
    }

    public string GeneraPsw()
    {
        string password = "";
      
        for(int i = 0; i < _lunghezzaPsw + 1; i++)
        {
           int numeroCasuale = Random.Shared.Next(4);
            
            switch (numeroCasuale)
            {
                case 0:
                    password += GeneraChar();
                    break;
                case 1:
                    password += GeneraLetterMin();
                    break;
                case 2:
                    password += GeneraLetterMaisc();
                    break;
                case 3:
                    password += Random.Shared.Next(10);
                    break;
            }
        }
        return password;
    }
}
