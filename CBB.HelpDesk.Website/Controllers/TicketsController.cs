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
        ITicketsService TicketsService = new PekaoTicketsService();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = TicketsService.Get();

            return View(tickets);
        }

        public ActionResult Edit(int id)
        {
            var ticket = TicketsService.Get(id);

            return View(ticket);
        }

        public async Task<ActionResult> Add(Ticket ticket)
        {
            await TicketsService.AddAsync(ticket);

            return View(ticket);
        }
    }
}