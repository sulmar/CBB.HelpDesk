using CBB.HelpDesk.DbPekaoServices;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IHttpActionResult> Get()
        {
            var tickets = await TicketsService.GetAsync();

            return Ok(tickets);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var ticket = await TicketsService.GetAsync(id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        public IHttpActionResult Post(Ticket ticket)
        {
            TicketsService.Add(ticket);

            return Created<Ticket>($"http://localhost:64068/api/Tickets/{ticket.TicketId}", ticket);
        }


        public Ticket Put(Ticket ticket)
        {
            TicketsService.Update(ticket);

            return ticket;
        }

        public IHttpActionResult Delete(int id)
        {
            var ticket = TicketsService.Get(id);

            if (ticket == null)
                return NotFound();

            TicketsService.Remove(id);

            return Ok();
        }



    }
}