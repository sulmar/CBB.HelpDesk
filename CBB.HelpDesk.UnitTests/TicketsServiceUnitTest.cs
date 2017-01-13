using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.PekaoServices;
using System.Linq;
using CBB.HelpDesk.AbcBankServices;

namespace CBB.HelpDesk.UnitTests
{
    [TestClass]
    public class TicketsServiceUnitTest
    {
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
