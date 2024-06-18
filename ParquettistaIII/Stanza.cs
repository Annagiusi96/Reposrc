using Geometria;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParquettistaIII;

public class Stanza : Spazio
{
      
    public Stanza(Misurabile misurabile, bool calcolaPerimetro, bool calcolaArea) : base(misurabile, calcolaPerimetro, calcolaArea)
    {
    }
}
