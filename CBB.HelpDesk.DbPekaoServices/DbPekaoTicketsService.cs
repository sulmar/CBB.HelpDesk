using CBB.HelpDesk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBB.HelpDesk.Models;
using System.Data.Entity;
using CBB.HelpDesk.DbPekaoServices.Properties;
using System.Data.SqlClient;

namespace CBB.HelpDesk.DbPekaoServices
{
    public class DbPekaoTicketsService : ITicketsService
    {
        public void Add(Ticket ticket)
        {
            var context = new HelpDeskContext();

            var state = context.Entry(ticket).State;

            context.Tickets.Add(ticket);
            state = context.Entry(ticket).State;

            var entities = context.ChangeTracker.Entries();

            context.Entry(ticket.Category).State = EntityState.Unchanged;
            context.Entry(ticket.CreateUser).State = EntityState.Unchanged;

            entities = context.ChangeTracker.Entries();

            context.SaveChanges();

             entities = context.ChangeTracker.Entries();

             state = context.Entry(ticket).State;
        }

        public IList<Ticket> Get()
        {
            var context = new HelpDeskContext();

            var tickets = context.Tickets;

            return tickets.ToList();
        }

        public IList<Ticket> Get(TicketsSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int ticketId)
        {
            var context = new HelpDeskContext();


            // Eadger loading
            var ticket = context.Tickets
                .Include(t=> t.Category)
                .Include(t=> t.CreateUser)
                // .Include("Category")
               // .Include(nameof(Category))
                // .Include("CreateUser.Address.City")
                // .Include("CreateUser.Addresses")
                // .Include($"{nameof(Category)}.{nameof(Category.Name)}")
                .SingleOrDefault(t => t.TicketId == ticketId);

            return ticket;
        }

        public void Remove(int ticketId)
        {
            var context = new HelpDeskContext();

            var ticket = context.Tickets.Find(ticketId);

            context.Tickets.Remove(ticket);

            context.SaveChanges();
        }

        private void SqlProcedureQuery()
        {
            var context = new HelpDeskContext();

            var lastName = "Sulecki";

            var lastNameParameter = new SqlParameter("@LastName", lastName);

            var sql = "uspGetUsersByLastName @LastName";

            var users = context.Database.SqlQuery<User>(sql, lastNameParameter).ToList();
        }

        // Pobranie danych za pomocą SQL
        private void SqlQuery()
        {
            var context = new HelpDeskContext();

            var gender = Gender.Man;

            var genderParameter = new SqlParameter("@Gender", gender);

            var sql = "SELECT * FROM dbo.Users WHERE Gender = @Gender";

            var users = context.Database.SqlQuery<User>(sql, genderParameter).ToList();
        }

        public void Send(Ticket ticket)
        {
            SqlProcedureQuery();

            SqlQuery();

            ExecuteSql();

        }

        // Uruchomienie SQL, np. update, insert, delete
        private static void ExecuteSql()
        {
            var context = new HelpDeskContext();

            // context.Database.ExecuteSqlCommand(Resources.UpdateGender);

            Console.Write("Podaj userId: ");
            var userId = Console.ReadLine();

            var userIdParameter = new SqlParameter("@UserId", userId);

            var sql = "UPDATE Users SET Gender = 1 WHERE UserId = @UserId";

            context.Database.ExecuteSqlCommand(sql, userIdParameter);




            // SQL Injection
            //var sql = "UPDATE Users SET Gender = 1 WHERE UserId = " + userId;
            //context.Database.ExecuteSqlCommand(sql);
        }

        public void Update(Ticket ticket)
        {
            var context = new HelpDeskContext();

            var foundTicket = context.Tickets.Find(ticket.TicketId);

            foundTicket.Title = ticket.Title;
            foundTicket.Description = ticket.Description;

            context.SaveChanges();

        }

        public async Task AddAsync(Ticket ticket)
        {
            var context = new HelpDeskContext();

            context.Tickets.Add(ticket);

            await context.SaveChangesAsync();
        }

        public async Task<IList<Ticket>> GetAsync()
        {
            var context = new HelpDeskContext();

            var tickets = await context.Tickets.ToListAsync();

            return tickets;
        }

        public async Task<Ticket> GetAsync(int ticketId)
        {
            var context = new HelpDeskContext();

            var ticket = await context.Tickets
                .Include(t => t.Category)
                .Include(t => t.CreateUser)
                .SingleOrDefaultAsync(t => t.TicketId == ticketId);

            return ticket;
        }
    }
}
