using CBB.HelpDesk.DbPekaoServices;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CBB.HelpDesk.Service.Controllers
{
    public class UsersController : ApiController
    {
        readonly IUsersService UsersService;

        public UsersController(IUsersService usersService)
        {
            this.UsersService = usersService;
        }

        public UsersController()
            : this(new DbPeakoUsersService())
        {
        }

        public IList<User> Get()
        {
            return UsersService.Get();
        }
    }
}
