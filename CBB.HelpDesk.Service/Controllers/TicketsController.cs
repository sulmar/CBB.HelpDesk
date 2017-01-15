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

        public async Task<IList<Ticket>> Get()
        {
            var tickets = await TicketsService.GetAsync();

            return tickets;
        }

        [HttpGet]
        public Ticket Pobierz(int id)
        {
            var ticket = TicketsService.Get(id);

            return ticket;
        }

        [HttpPost]
        public void Test(Ticket ticket)
        {
            TicketsService.Add(ticket);
        }


        public Ticket Put(Ticket ticket)
        {
            TicketsService.Update(ticket);

            return ticket;
        }

        public void Delete(int id)
        {
            TicketsService.Remove(id);
        }



    }
}