using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.Models;
using System.IO;
using CBB.PekaoCalculator;

namespace CBB.HelpDesk.PekaoServices
{
    public class PekaoTicketsService : ITicketsService
    {
        private ICalculator calculator;


        public PekaoTicketsService()
            : this(new Calculator())
        {

        }

        public PekaoTicketsService(ICalculator calculator)
        {
            this.calculator = calculator;
        }



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
            // TODO: Send SMS
            //    calculator.Calculate(100, 12, 0.5m);


            ISender sender = null;

            var message = new Message { Content = "Hello", From = "pekao", To = "609851649", SendDate = DateTime.Today.AddDays(2) };

            sender.Send(message);


            // TODO: Send tweet



        }

        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> Get(TicketsSearchCriteria criteria)
        {

            if (!string.IsNullOrEmpty(criteria.Title))
            {
                tickets = tickets.Where(t => t.Title == criteria.Title).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.Description))
            {
                tickets = tickets.Where(t => t.Title == criteria.Title).ToList();
            }

            if (criteria.From.HasValue)
            {
                tickets = tickets.Where(t => t.CreateDate >= criteria.From).ToList();
            }

            if (criteria.To.HasValue)
            {
                tickets = tickets.Where(t => t.CreateDate <= criteria.To).ToList();
            }

            return tickets.ToList();
        }
    }


    public interface ISender
    {
        // void Send(string content, string from, string to, DateTime sendDate);

        void Send(Message message);

    }


    public class Message
    {
        public string Content { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime? SendDate { get; set; }

    }
}
