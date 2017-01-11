using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.HelpDesk.ConsoleClient
{
    public class DateTimeHelper
    {
        public static bool IsHoliday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday 
                || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class DateTimeExtensions
    {
        // Metoda rozszerzająca (Extension method)
        public static bool IsHoliday(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkingDays(this DateTime date, int days)
        {
            return date.AddDays(days);
        }
    }

}
