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
            User user = new User();
            user.UserId = 1;
            user.FirstName = "Marcin";
            user.LastName = "Sulecki";
            user.IsActive = true;

            Category category = new Category();
            category.CategoryId = 1;
            category.Name = "IT";
            category.IsActive = true;

            Ticket issue = new Ticket();
            issue.TicketId = 1;
            issue.CreateDate = DateTime.Now;
            issue.CreateUser = user;
            issue.Priority = Priority.Normal;
            issue.Category = category;


            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.LastName);
        }
    }
}
