using CBB.HelpDesk.AbcBankServices;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.PekaoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.ConsoleClient
{
    // Wzorzec fabryki klas
    public class TicketsServiceFactory
    {
        public static ITicketsService Create(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException("location");
            }

            ITicketsService ticketsService = null;

          

            if (location == "Pekao")
            {
                ticketsService = new PekaoTicketsService();
            }
            else if (location == "Abc")
            {
                ticketsService = new AbcBankTicketsService();
            }
            else
            {
                throw new NotSupportedException();
            }

            return ticketsService;
        }
    }
}
