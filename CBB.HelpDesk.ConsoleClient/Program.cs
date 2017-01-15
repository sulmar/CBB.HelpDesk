using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CBB.HelpDesk.Models;
using System.IO;
using CBB.HelpDesk.Interfaces;
using CBB.HelpDesk.PekaoServices;
using CBB.HelpDesk.AbcBankServices;
using System.Linq;
using System.Collections;
using NLog;
using CBB.HelpDesk.DbPekaoServices;
using System.Threading;

namespace CBB.HelpDesk.ConsoleClient
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            Console.WriteLine("Application started.");


            var task1 = Task.Run(()=> Send());
           

            var task2 = Task.Run(()=> Send());

            Task.WaitAll(task1, task2);

            Task.Run(() => Send());

            Console.WriteLine("Next operation.");

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();


            return;


            #region 

            ExecuteSqlTest();

            GetTicketTest();

            AddTicketDbTest();



            NLogTest();

            FindTest();

            UnionTest();

            GroupByIsActiveAndFirstNameTest();

            GroupByFirstNameTest();

            GroupByTest();

            CountActiveUsersTest();

            GetActiveUsersTest();

            LinqTest();

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

            #endregion

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

     
        private static void Send()
        {
            Console.WriteLine("Sending...");

            Thread.Sleep(5000);

            Console.WriteLine("Sent.");
        }

        private static void ExecuteSqlTest()
        {
            var ticket = new Ticket
            {
                Title = "Awaria",
                Description = "Opis błędu...",
                CreateDate = DateTime.Now,
                CreateUser = new User { UserId = 1, FirstName = "Kasia", LastName = "" },
                Priority = Priority.Normal,
                Category = new Category { CategoryId = 1, Name = "IT" },
                UpdateDate = DateTime.Now,
            };

            ITicketsService ticketsService = new DbPekaoTicketsService();
            ticketsService.Send(ticket);

        }

        private static void GetTicketTest()
        {
            ITicketsService ticketsService = new DbPekaoTicketsService();
            var ticket = ticketsService.Get(2);

            Console.WriteLine(ticket.Title);
        }

        private static void AddTicketDbTest()
        {
            var ticket = new Ticket
            {
                Title = "Awaria",
                Description = "Opis błędu...",
                CreateDate = DateTime.Now,
                CreateUser = new User { UserId = 1, FirstName = "Kasia", LastName = "" },
                Priority = Priority.Normal,
                Category = new Category { CategoryId = 1, Name = "IT" },
                UpdateDate = DateTime.Now,
            };

            ITicketsService ticketsService = new DbPekaoTicketsService();

            ticketsService.Add(ticket);
        }

        private static void NLogTest()
        {
            logger.Info("Application version 1.0 started.");

            logger.Trace("Śledzenie");

            logger.Warn("Ostrzeżenie");

            logger.Error("Coś poszło nie tak");

        }

        private static void FindTest()
        {
            IList<User> users = new List<User>()
            {
                new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { UserId = 3, FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { UserId = 4, FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { UserId = 5, FirstName = "Marcin", LastName = "Kowalski", IsActive = false },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Nowak", IsActive = false },
            };


            var user = users.Where(u => u.UserId == 5).First();


            var user2 = users.FirstOrDefault(u => u.LastName == "Smith");


            // First - pobiera pierwszy element. Jeśli nie ma żadnego to zwróci błąd (exception)
            // FirstOrDefault - pobiera pierwszy element. Jeśli nie ma żadnego to null
            // Single - pobiera pojedynczy element. Jeśli jest ich więcej lub nie ma żadnego to zwróci błąd
            // SingleOrDefault -  pobiera pojedynczy element. Jeśli jest ich więcej to zwróci błąd, a jeśli nie ma to zwróci null

            var query = users.First(u => u.UserId == 1000);


            if (user2==null)
            {
                Console.WriteLine("Nie znaleziono");
            }
        }

        private static void UnionTest()
        {
            IList<User> users = new List<User>()
            {
                new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { UserId = 3, FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { UserId = 4, FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { UserId = 5, FirstName = "Marcin", LastName = "Kowalski", IsActive = false },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Nowak", IsActive = false },
            };

            var women = users.Where(u => u.FirstName.EndsWith("a"));

            var man = users.Where( u => u.IsActive && (u.FirstName == "Marcin" || u.FirstName == "Bartek"));

            var query = women.Union(man);


            var active = users.Where(u => u.IsActive);

            var query2 = women.Union(active);


            var barteks = users.Where(u => u.FirstName == "Bartek");

            var query3 = users.Except(barteks);


            var kasie = users.Where(u => u.FirstName == "Kasia");

            var query4 = active.Intersect(kasie);



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

        // SQL:
        // Pogrupuj użytkowników wg imienia i policz ich ilość w każdej grupie

        // | Imie      | Ilosc |
        // | Kasia     |      2 |
        // | Marcin    |      3 |
        private static void GroupByFirstNameTest()
        {
            IList<User> users = new List<User>()
            {
                new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { UserId = 3, FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { UserId = 4, FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { UserId = 5, FirstName = "Marcin", LastName = "Kowalski", IsActive = false },
            };


            var query = users.GroupBy(user => user.FirstName)
                .Select(g => new { Grupa = g.Key, Ilosc = g.Count() });

            foreach (var group in query)
            {
                Console.WriteLine($"Imię: {group.Grupa} Ilosc: {group.Ilosc}" );
            }

        }


        // | IsActive | Imie      | Ilosc  |
        // |    false | Kasia     |      2 |
        // |    true  | Kasia     |      5 |
        // |    false | Marcin    |      3 |
        // |    true  | Marcin    |      2 |

        private static void GroupByIsActiveAndFirstNameTest()
        {
            IList<User> users = new List<User>()
            {
                new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { UserId = 3, FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { UserId = 4, FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { UserId = 5, FirstName = "Marcin", LastName = "Kowalski", IsActive = false },
            };


            var query = users.GroupBy(user => new { user.IsActive, user.FirstName })
                .Select(g => new { Grupa = g.Key, Ilosc = g.Count() });

            foreach (var group in query)
            {
                Console.WriteLine($"Aktywny: {group.Grupa.IsActive} Imię: {group.Grupa.FirstName} Ilosc: {group.Ilosc}");
            }

        }


        private static void GroupByTest()
        {
            IList<User> users = new List<User>()
            {
                new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { UserId = 3, FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { UserId = 4, FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { UserId = 5, FirstName = "Adam", LastName = "Kowalski", IsActive = false },
            };

            // SQL:
            // Pogrupuj użytkowników wg aktywności i policz ich ilość w każdej grupie

            // | IsActive | Count |
            // | true     |     2 |
            // | false    |     3 |

            // select IsActive, count(*) from dbo.Users
            // group by IsActive 

            var query = users
                .GroupBy(user => user.IsActive)
                .Select(g => new { Grupa = g.Key, Uzytkownicy = g })
                .ToList();

            foreach (var group  in query)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"Grupa: {group.Grupa}");
                Console.WriteLine("-------------------");

                foreach (var user in group.Uzytkownicy)
                {
                    Console.WriteLine(user);
                }
            }

            // Podsumowanie ilości w grupach
            var query2 = users
               .GroupBy(user => user.IsActive)
               .Select(g => new { Grupa = g.Key, Ilosc = g.Count() })
               .ToList();

        }


        /// <summary>
        /// Funkcje agregujące
        /// </summary>
        private static void CountActiveUsersTest()
        {
            IList<User> users = new List<User>()
            {
                new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { UserId = 2, FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { UserId = 3, FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { UserId = 4, FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { UserId = 5, FirstName = "Adam", LastName = "Kowalski", IsActive = false },
            };

            // Znajdz tylko aktywnych uzytkowników 

            var countActiveUsers = users
                .Where(user => user.IsActive)
                .Count();

            var sumActiveUsers = users
                .Where(user => user.IsActive)
                .Sum(user => user.UserId);

            var maxId = users.Max(user => user.UserId);

        }

        private static void GetActiveUsersTest()
        {
            IList<User> users = new List<User>()
            {
                new User { FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { FirstName = "Adam", LastName = "Kowalski", IsActive = false },
            };

            // Znajdz tylko aktywnych uzytkowników 

            var activeUsers = users
                .Where(user => user.IsActive)
                .OrderBy(user => user.LastName)
                .ThenBy(user => user.FirstName)
                .ToList();


            var activeUsers2 = (from user in users
                               where user.IsActive
                               orderby user.LastName, user.FirstName
                               select user)
                               .ToList();
                
        }

        private static void LinqTest()
        {
            IList<User> users = new List<User>()
            {
                new User { FirstName = "Marcin", LastName = "Sulecki", IsActive = true },
                new User { FirstName = "Bartek", LastName = "Sulecki", IsActive = true },
                new User { FirstName = "Kasia", LastName = "Sulecka", IsActive = false },
                new User { FirstName = "Kasia", LastName = "Nowak", IsActive = true },
                new User { FirstName = "Adam", LastName = "Kowalski", IsActive = false },
            };

            // znajdz uzytkownikow o nazwisku Sulecki

            // SQL - deklaratywny - co chcesz 
            // select * from dbo.Users where LastName = 'Sulecki'

            // C# - imperatywne - jak to masz zrobić


            bool isFilter = true;

            // select FirstName as Imie, LastName as Nazwisko from dbo.Users
            // where LastName = 'Sulecki'
            // order by FirstName

            var foundUsers = users
                .Where(user => user.LastName == "Sulecki")
                .OrderBy(user => user.FirstName)
                .Select(user => new { Imie = user.FirstName, Nazwisko = user.LastName });

            if (isFilter)
            {
                foundUsers = foundUsers
                    .Where(user => user.Imie.StartsWith("M"));
            }
                
          //  var users3 = foundUsers;


            var foundUsers2 = from user in users
                              where user.LastName == "Sulecki"
                              orderby user.FirstName
                              select new { user.FirstName, user.LastName };

            //var foundUsers = new List<User>();

            //foreach (var user in users)
            //{
            //    if (user.LastName == "Sulecki")
            //    {
            //        foundUsers.Add(user);
            //    }
            //}

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
