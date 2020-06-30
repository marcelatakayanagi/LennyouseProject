using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.RD.Lennyouse.BusinessLayer.ExtendedMethods
{
    public static class DateTimeExtendedMethods
    {
        public static bool IsToday(this DateTime date)
        {
            var today = DateTime.Now;
            return date.Day == today.Day && date.Month == today.Month && date.Year == today.Year;
        }
    }
}
