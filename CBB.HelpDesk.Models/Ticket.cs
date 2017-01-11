using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.Models
{
    public class Ticket : Base
    {

        public int TicketId { get; set; }

        public Category Category { get; set; }

        public DateTime CreateDate { get; set; }

        public User CreateUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public User UpdateUser { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public User CurrentUser { get; set; }

        public Ticket ReferenceTicket { get; set; }

        public string Location { get; set; }


        public Status Status { get; set; }


    }
}
