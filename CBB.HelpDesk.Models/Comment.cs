using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.Models
{
    public class Comment : Base
    {
        public int CommentId { get; set; }

        public Ticket Ticket { get; set; }

        public string Note { get; set; }

        public DateTime CreateDate { get; set; }

        public User CreateUser { get; set; }
    }
}
