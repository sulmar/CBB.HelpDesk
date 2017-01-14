using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.Models.Validators
{


    // FluentValidation
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(ticket => ticket.Title)
                .NotEmpty()
                .Length(1, 6);

            RuleFor(ticket => ticket.Description)
                .NotEmpty();


        }
    }
}
