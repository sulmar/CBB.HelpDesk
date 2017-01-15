using CBB.HelpDesk.DbPekaoServices;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CBB.HelpDesk.Service.Controllers
{
    public class TicketsController : ApiController
    {
        readonly ITicketsService TicketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            this.TicketsService = ticketsService;
        }

        public TicketsController()
            : this(new DbPekaoTicketsService())
        {
        }

        public IList<Ticket> Get()
        {
            var tickets = TicketsService.Get();

            return tickets;
        }

        public Ticket Get(int id)
        {
            var ticket = TicketsService.Get(id);

            return ticket;
        }



    }
}