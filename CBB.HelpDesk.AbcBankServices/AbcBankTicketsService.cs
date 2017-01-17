using CBB.HelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBB.HelpDesk.Models;

namespace CBB.HelpDesk.AbcBankServices
{
    public class AbcBankTicketsService : ITicketsService
    {
        public void Add(Ticket ticket)
        {
            Console.WriteLine(ticket);
        }

        public Ticket Get(int ticketId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int ticketId)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket ticket)
        {   
            throw new NotImplementedException();
        }

        public void Send(Ticket ticket)
        {
            if (ticket==null)
            {
                throw new ArgumentNullException("ticket");
            }

            if (string.IsNullOrEmpty(ticket.Title))
            {
                throw new ArgumentNullException("Title");
            }

            if (ticket.CreateDate < DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("CreateDate");
            }

            Console.WriteLine("Przygotowanie bramki");

            Console.WriteLine("Obliczeie kosztu wysłania");


            Console.WriteLine($"Sending sms... {ticket.Title}");
        }

        public IList<Ticket> Get()
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> Get(TicketsSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Ticket>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetAsync(int ticketId)
        {
            throw new NotImplementedException();
        }
    }
}
