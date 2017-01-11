using CBB.HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AddTicketTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static void AddTicketTest()
        {
            User user = new User
            {
                UserId = 1,
                FirstName = "Marcin",
                LastName = "Sulecki",
                IsActive = true,
            };

            Category category = new Category
            {
                CategoryId = 1,
                Name = "IT",
                IsActive = true
            };

            Ticket issue = new Ticket
            {
                TicketId = 1,
                CreateDate = DateTime.Now,
                CreateUser = user,
                Priority = Priority.Normal,
                Category = category
            };


            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.LastName);
        }
    }
}
