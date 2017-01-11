using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.ConsoleClient
{
    public class Printer
    {
        // Metoda generyczna
        public void Print<TItem>(TItem item)
        {
            Console.WriteLine(item);
        }

    }
}
