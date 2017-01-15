using CBB.HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.Interfaces
{
    public interface ITicketsService
    {

        IList<Ticket> Get();

        Task<IList<Ticket>> GetAsync();

        Ticket Get(int ticketId);


        // IList<Ticket> Get(string title, string description, DateTime? from, DateTime? to);

        IList<Ticket> Get(TicketsSearchCriteria criteria);


        void Add(Ticket ticket);

        Task AddAsync(Ticket ticket);

        void Update(Ticket ticket);

        void Remove(int ticketId);

        void Send(Ticket ticket);

    }
}
