using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.Models
{
    public abstract class SearchCriteria : Base
    {

    }

    public class PeriodSearchCriteria : SearchCriteria
    {
        public DateTime? From { get; set; }

        private DateTime? _To;

        public DateTime? To
        {
            get { return _To; }
            set {

                if (value < this.From)
                {
                    throw new ArgumentException("Data to nie może być wcześniejsza od daty początkowej");
                }

                _To = value;

            }
        }

    }

    public class TicketsSearchCriteria : PeriodSearchCriteria
    {
        public string Title { get; set; }

        public string Description { get; set; }

    }

    public class CommentsSearchCriteria : PeriodSearchCriteria
    {
        public string Comment { get; set; }

    }
}
