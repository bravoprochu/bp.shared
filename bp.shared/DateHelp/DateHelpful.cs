using bp.shared.DTO;
using System;

namespace bp.shared.DateHelp
{
    public static partial class DateHelpful
    {
        public static string FormatDateToYYYYMMDD(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string DateFormatClassic()
        {
            return "yyyy-MM-dd";
        }
        public static string DateTimeFormatClassic()
        {
            return "yyyy-MM-ddTHH:mm:ssZ";
        }

        public static DateTime DataStalaGodzina(DateTime d, int godz = 9)
        {
            return new DateTime(d.Year, d.Month, d.Day, godz, 0, 0);
        }

        public static DateTime Kwartal()
        {
            DateTime kwartalTemu = DateTime.Now.AddMonths(-3);
            return new DateTime(kwartalTemu.Year, kwartalTemu.Month, 1);
        }

        public static DateRangeDTO DateRangeFixedHours(DateRangeDTO dateRange) {
            var s = dateRange.DateStart;
            var e = dateRange.DateEnd;
            return new DateRangeDTO
            {
                DateStart = new DateTime(s.Year, s.Month, s.Day, 0, 0, 0).ToUniversalTime(),
                DateEnd = new DateTime(e.Year, e.Month, e.Day, 23, 59, 59).ToUniversalTime()
            };
        }

        public static DateTime DateRangeDateTo(DateTime dateEnd)
        {
            return new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
        }

        public static DateRangeDTO DateRangeOstKwartal()
        {
            return new DateRangeDTO
            {
                DateEnd = DateTime.Now,
                DateStart = Kwartal()
            };
        }
    }
}