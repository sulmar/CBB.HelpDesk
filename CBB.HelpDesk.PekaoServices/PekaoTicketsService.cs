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
        private IList<Ticket> tickets = new List<Ticket>
        {
            new Ticket
            {
                TicketId = 1,
                Title = "Awaria komputera u Kasi",
                Description = "Mam czarny ekran",
                CreateDate = DateTime.Now,
                CreateUser = new User { UserId = 1, FirstName = "Kasia", LastName = "" },
                Priority = Priority.Normal,
                Category = new Category { CategoryId = 1, Name = "IT" }
            },

            new Ticket
            {
                TicketId = 2,
                Title = "Brak kawy",
                Description = "Skończyła się kawa w automacie",
                CreateDate = DateTime.Now,
                CreateUser = new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki" },
                Priority = Priority.High,
                Category = new Category { CategoryId = 1, Name = "IT" }
            },

            new Ticket
            {
                TicketId = 3,
                Title = "Awaria projektora",
                Description = "Lampa do wymiany",
                CreateDate = DateTime.Now,
                CreateUser = new User { UserId = 1, FirstName = "Bartek", LastName = "Sulecki" },
                Priority = Priority.High,
                Category = new Category { CategoryId = 1, Name = "IT" }
            },




        };


        public void Add(Ticket ticket)
        {
            var stream = new StreamWriter("tickets.txt", true);

            stream.WriteLine($"{ticket.TicketId} | {ticket.Title} | {ticket.Description}");

            stream.Close();
        }

        public IList<Ticket> Get()
        {
            return tickets;
        }

        public Ticket Get(int ticketId)
        {
            return tickets.Single(t => t.TicketId == ticketId);
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
