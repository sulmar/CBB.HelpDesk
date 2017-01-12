using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.Models;
using System.IO;

namespace CBB.HelpDesk.PekaoServices
{
    public class PekaoTicketsService : ITicketsService
    {
        public void Add(Ticket ticket)
        {
            var stream = new StreamWriter("tickets.txt", true);

            stream.WriteLine($"{ticket.TicketId} | {ticket.Title} | {ticket.Description}");

            stream.Close();
        }

        public Ticket Get(int ticketId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int ticketId)
        {
            throw new NotImplementedException();
        }

        public void Send(Ticket ticket)
        {
            throw new NotSupportedException();
        }

        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
