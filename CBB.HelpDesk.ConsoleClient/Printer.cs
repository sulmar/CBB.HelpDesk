using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.ConsoleClient
{
    public class Printer
    {
        public void Print(int item)
        {
            Console.WriteLine(item);
        }

        public void Print(string item)
        {
            Console.WriteLine(item);
        }

        public void Print(DateTime item)
        {
            Console.WriteLine(item);
        } 
    }
}
