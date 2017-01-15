using CBB.HelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBB.HelpDesk.Models;

namespace CBB.HelpDesk.DbPekaoServices
{
    public class DbPeakoUsersService : IUsersService
    {
        public IList<User> Get()
        {
            var context = new HelpDeskContext();

            return context.Users.ToList();
        }
    }
}
