using S15_RegioniDao;

namespace S16_Dao;

public class Program
{
    static void Main(string[] args)
    {

        RegioniDAO rd = new();

        List<Regione> regioni = rd.FindAll();

        foreach (Regione regione in regioni)
        {
            Console.WriteLine(regione);
        }
    }
}

