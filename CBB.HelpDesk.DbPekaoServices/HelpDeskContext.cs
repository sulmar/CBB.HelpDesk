using CBB.HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.DbPekaoServices
{
    public class HelpDeskContext : DbContext
    {
        #region DbSets

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        #endregion

        public HelpDeskContext()
            : base("HelpDeskConnection")
        {

        }
    }
}
