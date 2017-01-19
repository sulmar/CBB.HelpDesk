using CBB.HelpDesk.DbPekaoServices;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.Models;
using CBB.HelpDesk.PekaoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CBB.HelpDesk.Website.Controllers
{
    public class TicketsController : Controller
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

        // GET: Tickets
        public async Task<ActionResult> Index()
        {
            var tickets = await TicketsService.GetAsync();

            return View(tickets);
        }

        public ActionResult Edit(int id)
        {
            var ticket = TicketsService.Get(id);

            return View(ticket);
        }

        public async Task<ActionResult> Add(Ticket ticket)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return View("Create", ticket);
            }


            await TicketsService.AddAsync(ticket);

            return View(ticket);
        }
    }
}