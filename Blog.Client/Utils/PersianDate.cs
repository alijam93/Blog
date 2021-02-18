using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Utils
{
    public static class PersianDate
    {
        public static string ToPersianDate(this DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            string year = persianCalendar.GetYear(date).ToString();
            string month = persianCalendar.GetMonth(date).ToString().PadLeft(2, '0');
            string day = persianCalendar.GetDayOfMonth(date).ToString().PadLeft(2, '0');
            string persianDateString = string.Format($"{year}/{month}/{day}");
            return persianDateString;
        } 
        
        public static string ToPersianDateWithTime(this DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            string year = persianCalendar.GetYear(date).ToString();
            string month = persianCalendar.GetMonth(date).ToString().PadLeft(2, '0');
            string day = persianCalendar.GetDayOfMonth(date).ToString().PadLeft(2, '0');
            string Time = date.ToString("HH:mm");
            string persianDateString = string.Format($"{year}/{month}/{day} - {Time}");
            return persianDateString;
        }
    }
}
