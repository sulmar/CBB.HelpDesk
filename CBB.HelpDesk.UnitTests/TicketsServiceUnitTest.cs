using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.PekaoServices;
using System.Linq;
using CBB.HelpDesk.AbcBankServices;
using CBB.HelpDesk.Models.Validators;
using CBB.HelpDesk.Models;

namespace CBB.HelpDesk.UnitTests
{
    [TestClass]
    public class TicketsServiceUnitTest
    {
        [TestMethod]
        public void ValidatorTest()
        {
            var ticket = new Ticket
            {
                TicketId = 1,
                Title = "Awaria komputera u Kasi",
                CreateDate = DateTime.Now,
                CreateUser = new User { UserId = 1, FirstName = "Kasia", LastName = "" },
                Priority = Priority.Normal,
                Category = new Category { CategoryId = 1, Name = "IT" }
            };

            TicketValidator validator = new TicketValidator();
            var results = validator.Validate(ticket);

            Assert.IsFalse(results.IsValid);
            
        }

        [TestMethod]
        public void Validator2Test()
        {
            var ticket = new Ticket
            {
                TicketId = 1,
                Title = "Awaria",
                Description = "Opis błędu...",
                CreateDate = DateTime.Now,
                CreateUser = new User { UserId = 1, FirstName = "Kasia", LastName = "" },
                Priority = Priority.Normal,
                Category = new Category { CategoryId = 1, Name = "IT" }
            };

            TicketValidator validator = new TicketValidator();
            var results = validator.Validate(ticket);

            Assert.IsTrue(results.IsValid);

        }

        [TestMethod]
        public void GetTest()
        {
            ITicketsService ticketsService = new PekaoTicketsService();

            var tickets = ticketsService.Get();

            Assert.IsNotNull(tickets);

            Assert.IsTrue(tickets.Any());

            Assert.IsTrue(tickets.All(t => !string.IsNullOrEmpty(t.Title)), "Brak tytułu");

            Assert.IsTrue(tickets.All(t => !string.IsNullOrEmpty(t.Description)), "Brak opisu");

        }

        [TestMethod]
        public void GetByIdTest()
        {
            var ticketId = 3;

            ITicketsService ticketsService = new PekaoTicketsService();

            var ticket = ticketsService.Get(ticketId);

            Assert.IsNotNull(ticket);

            Assert.AreEqual(ticketId, ticket.TicketId);

            Assert.IsTrue(!string.IsNullOrEmpty(ticket.Title));

        }
    }
}
