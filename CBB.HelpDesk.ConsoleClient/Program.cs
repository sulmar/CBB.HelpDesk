﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBB.HelpDesk.Models;
using System.IO;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.PekaoServices;
using CBB.HelpDesk.AbcBankServices;
using System.Collections;

namespace CBB.HelpDesk.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ListTest();

            ArrayListTest();

            ArrayTest();


            CheckedTest();
            

            FormTicketTest();


            PrinterTest();

            IsHolidayTest();

            EqualsTest();

            AnonymousTest();

            AddTicketTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }


        private static void ListTest()
        {
            IList<User> users = new List<User>();
            users.Add(new User { FirstName = "Marcin", LastName = "Sulecki" });
            users.Add(new User { FirstName = "Bartek", LastName = "Sulecki" });
            users.Add(new User { FirstName = "Kasia", LastName = "Sulecka" });
            users.Add(new User { FirstName = "Kasia", LastName = "Nowak" });
            users.Add(new User { FirstName = "Adam", LastName = "Kowalski" });

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            // znajdz uzytkownikow o nazwisku Sulecki

            // SQL - deklaratywny - co chcesz 
            // select * from dbo.Users where LastName = 'Sulecki'

            // C# - imperatywne - jak to masz zrobić
            var foundUsers = new List<User>();


            foreach (var user in users)
            {
                if (user.LastName == "Sulecki")
                {
                    foundUsers.Add(user);
                }
            }

            Console.WriteLine("Znaleziono użytkowników:");

            foreach (var user in foundUsers)
            {
                Console.WriteLine(user);
            }
            

        }

        private static void LinqTest()
        {
            IList<User> users = new List<User>()
            {
                new User { FirstName = "Marcin", LastName = "Sulecki" },
                new User { FirstName = "Bartek", LastName = "Sulecki" },
                new User { FirstName = "Kasia", LastName = "Sulecka" },
                new User { FirstName = "Kasia", LastName = "Nowak" },
                new User { FirstName = "Adam", LastName = "Kowalski" },
            };

            
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            // znajdz uzytkownikow o nazwisku Sulecki

            // SQL - deklaratywny - co chcesz 
            // select * from dbo.Users where LastName = 'Sulecki'

            // C# - imperatywne - jak to masz zrobić
            var foundUsers = new List<User>();


            foreach (var user in users)
            {
                if (user.LastName == "Sulecki")
                {
                    foundUsers.Add(user);
                }
            }

            Console.WriteLine("Znaleziono użytkowników:");

            foreach (var user in foundUsers)
            {
                Console.WriteLine(user);
            }


        }

        private static void ArrayTest()
        {
            User user1 = new User { FirstName = "Marcin", LastName = "Sulecki" };

            User[] users = new User[5];

            users[0] = user1;
            users[1] = new User { FirstName = "Bartek", LastName = "Sulecki" };
            users[2] = new User { FirstName = "Kasia", LastName = "Sulecka" };


            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }


        private static void ArrayListTest()
        {
            ArrayList users = new ArrayList(2);
            users.Add(new User { FirstName = "Marcin", LastName = "Sulecki" });
            users.Add(new User { FirstName = "Bartek", LastName = "Sulecki" });
            users.Add(new User { FirstName = "Kasia", LastName = "Sulecka" });

            foreach (var user in users)
            {
                Console.WriteLine( ((User) user).IsActive);
            }
        }

        private static void CheckedTest()
        {
            byte x = 255;

            x++;

            checked
            {
                x++;
                x++;
            }

            Console.WriteLine(x);
        }

        private static void FormTicketTest()
        {
            Console.WriteLine("Witaj w HelpDesk");


            while (true)
            {

                Console.WriteLine("Utwórz ticket");

                Console.Write("Podaj tytuł: ");

                var title = Console.ReadLine();

                Console.Write("Podaj opis: ");

                var description = Console.ReadLine();


                Console.Write("Podaj lokalizację: ");

                var location = Console.ReadLine();

                var ticket = new Ticket
                {
                    TicketId = 1,
                    Title = title,
                    Description = description,
                    Priority = Priority.High,
                    Location = location
                };


                ITicketsService ticketsService = TicketsServiceFactory.Create(ticket.Location);

                ticketsService.Add(ticket);



                try
                {
                    ticketsService.Send(ticket);
                }

                catch(NotSupportedException)
                {
                    Console.WriteLine("Nie obsługiwane");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

        private static void PrinterTest()
        {
            var printer = new Printer();

            printer.Print<int>(10);

            printer.Print<DateTime>(DateTime.Now);

            printer.Print<string>("Hello World");

        }

        private static void IsHolidayTest()
        {
            var isHoliday = DateTimeHelper.IsHoliday(DateTime.Now);

            isHoliday = DateTime.Now.IsHoliday();

            var result = DateTime.Now.AddWorkingDays(4);

        }

        public static void Test(ref int x)
        {
            x = x + 1;
        }

        public static void Test(User user)
        {
            user.FirstName = "Bartek";
        }

        private static void EqualsTest()
        {

            int x = 10;

            Console.WriteLine(x);

            Test(ref x);


            Console.WriteLine(x);

            var user = new User
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            // var copyUser = user;
            User copyUser = (User) user.Clone();

            if (copyUser == user)
            {

            }

            

            Test(copyUser);

            var user2 = user;

           

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


            Console.WriteLine(user);
        }
    }
}
