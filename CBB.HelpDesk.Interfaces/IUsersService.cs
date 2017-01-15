using CBB.HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.Interfaces
{
    public interface IUsersService
    {
        IList<User> Get();
    }
}
