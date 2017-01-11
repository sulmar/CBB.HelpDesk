﻿using CBB.HelpDesk.Models;
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
            AnonymousTest();

            AddTicketTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static void AnonymousTest()
        {

            // Klasa anonimowa
            var userinfo = new 
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                Age = 18,
                Weight = 65.5,
            };


        }

        private static void AddTicketTest()
        {
            var user = new User("Marcin", "Sulecki")
            {
                UserId = 2,
            };

            var category = new Category
            {
                CategoryId = 1,
                Name = "IT",
                IsActive = true
            };

            var issue = new Ticket
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
