using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATM.DevTools.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWeekdays(this DateTime date, int days)
        {
            var sign = days < 0 ? -1 : 1;
            var unsignedDays = Math.Abs(days);
            var weekdaysAdded = 0;
            while (weekdaysAdded < unsignedDays)
            {
                date = date.AddDays(sign);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    weekdaysAdded++;
            }
            return date;
        }

        public static DateTime SetTime(this DateTime date, int hour)
        {
            return date.SetTime(hour, 0, 0, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute)
        {
            return date.SetTime(hour, minute, 0, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
        {
            return date.SetTime(hour, minute, second, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
        }

        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static string ToString(this DateTime? date)
        {
            return date.ToString(null, Globalization.DateTimeFormatInfo.CurrentInfo);
        }

        public static string ToString(this DateTime? date, string format)
        {
            return date.ToString(format, Globalization.DateTimeFormatInfo.CurrentInfo);
        }

        public static string ToString(this DateTime? date, IFormatProvider provider)
        {
            return date.ToString(null, provider);
        }

        public static string ToString(this DateTime? date, string format, IFormatProvider provider)
        {
            if (date.HasValue)
                return date.Value.ToString(format, provider);

            return string.Empty;
        }

        public static string ToRelativeDateString(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.Now);
        }

        public static string ToRelativeDateStringUtc(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.UtcNow);
        }


        public static DateTime AddBusinessDays(this DateTime date, int days)
        {
            var sign = Convert.ToDouble(Math.Sign(days));
            var unsignedDays = Math.Sign(days) * days;
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    date = date.AddDays(sign);
                }
                while (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday);
            }
            return date;
        }

        private static string GetRelativeDateValue(DateTime date, DateTime comparedTo)
        {
            TimeSpan diff = comparedTo.Subtract(date);

            if (diff.TotalDays >= 365)
                return string.Concat("on ", date.ToString("MMMM d, yyyy"));

            if (diff.TotalDays >= 7)
                return string.Concat("on ", date.ToString("MMMM d"));

            if (diff.TotalDays > 1)
                return string.Format("{0:N0} days ago", diff.TotalDays);

            if (diff.TotalDays.Equals(1d))
                return "yesterday";

            if (diff.TotalHours >= 2)
                return string.Format("{0:N0} hours ago", diff.TotalHours);

            if (diff.TotalMinutes >= 60)
                return "more than an hour ago";

            if (diff.TotalMinutes >= 5)
                return string.Format("{0:N0} minutes ago", diff.TotalMinutes);

            if (diff.TotalMinutes >= 1)
                return "a few minutes ago";

            return "less than a minute ago";
        }

        /// <summary>
        /// Calcula la edad de una persona.
        /// </summary>
        /// <param name="dteDateBirth">Fecha de nacimiento.</param>
        /// <returns>Edad de la la persona</returns>
        public static byte CalculateAge(this DateTime dteDateBirth)
        {
            DateTime dteDateCurrent = DateTime.Now;
            int intYearCurrent = dteDateCurrent.Year;
            int intMonthCurrent = dteDateCurrent.Month;
            int inDayCurrent = dteDateCurrent.Day;

            int intYearBirth = dteDateBirth.Year;
            int intMonthBirth = dteDateBirth.Month;
            int inDayBirth = dteDateBirth.Day;

            try
            {
                return (byte)((((365 * intYearCurrent) - (365 * (intYearBirth))) + (intMonthCurrent - intMonthBirth) * 30 + (inDayCurrent - inDayBirth)) / 365);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es igual a la fecha proporcionada.
        /// </summary>
        /// <param name="dteBase">Clase extendida con el valor de la fecha y hora.</param>
        /// <param name="dteCompare">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool IsIgual(this DateTime dteBase, DateTime dteCompare)
        {
            return dteBase.Year == dteCompare.Year && dteBase.Month == dteCompare.Month && dteBase.Day == dteCompare.Day;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es mayor a la fecha proporcionada.
        /// </summary>
        /// <param name="date">Clase extendida con el valor de la fecha y hora.</param>
        /// <param name="dteCompare">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool IsGreater(this DateTime date, DateTime dteCompare)
        {
            if (date.Year > dteCompare.Year)
                return true;
            if (date.Year == dteCompare.Year)
            {
                if (date.Month > dteCompare.Month)//Comparo meses
                    return true;
                if (date.Month == dteCompare.Month)//Comparo días                
                    return date.Day > dteCompare.Day;
                return false;
            }
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es mayor o igual a la fecha proporcionada.
        /// </summary>
        /// <param name="date">Clase extendida con el valor de la fecha y hora.</param>
        /// <param name="dteCompare">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool IsGreaterOrEqual(this DateTime date, DateTime dteCompare)
        {
            if (date.Year > dteCompare.Year)
                return true;
            if (date.Year == dteCompare.Year)
            {
                if (date.Month > dteCompare.Month)//Comparo meses
                    return true;
                if (date.Month == dteCompare.Month)//Comparo días                
                    return date.Day >= dteCompare.Day;
                return false;
            }
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es menor a la fecha proporcionada.
        /// </summary>
        /// <param name="date">Clase extendida con el valor de la fecha y hora.</param>
        /// <param name="dteCompare">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool IsLower(this DateTime date, DateTime dteCompare)
        {
            if (date.Year < dteCompare.Year)
                return true;
            if (date.Year == dteCompare.Year)
            {
                if (date.Month < dteCompare.Month)//Comparo meses
                    return true;
                if (date.Month == dteCompare.Month)//Comparo días                
                    return date.Day < dteCompare.Day;

                return false;
            }
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha es menor o igual a la fecha proporcionada.
        /// </summary>
        /// <param name="date">Clase extendida con el valor de la fecha y hora.</param>
        /// <param name="dteCompare">Fecha y hora con la cual se realiza la comparación.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool IsLowerOrEqual(this DateTime date, DateTime dteCompare)
        {
            if (date.Year < dteCompare.Year)
                return true;
            if (date.Year == dteCompare.Year)
            {
                if (date.Month < dteCompare.Month)//Comparo meses
                    return true;
                if (date.Month == dteCompare.Month)//Comparo días
                {
                    return date.Day <= dteCompare.Day;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Función que indica si el valor de la fecha se encuentra entre 2 fechas.
        /// </summary>
        /// <param name="date">Clase extendida con el valor de la fecha y hora.</param>
        /// <param name="dteInicial">Fecha inicial.</param>
        /// <param name="dteFinal">Fecha final.</param>
        /// <returns>Valor booleano que indica la conformidad del proceso.</returns>
        public static bool IsBetween(this DateTime date, DateTime dteInicial, DateTime dteFinal)
        {
            return date.IsLowerOrEqual(dteFinal) && date.IsGreaterOrEqual(dteInicial);
        }

        /// <summary>
        /// Devuelve el primer día del mes
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfTheMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Devuelve si la fecha y hora es en fin de semana.
        /// </summary>
        /// <param name="dt">El DateTime a evaluar.</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime dt)
        {
            return (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        /// Indica si el DateTime es en un día de la semana.
        /// </summary>
        /// <param name="dt">El valor de origen a evaluar.</param>
        /// <returns></returns>
        public static bool IsWeekDay(this DateTime dt)
        {
            return !dt.IsWeekend();
        }

        /// <summary>
        /// Devuelve el tiempo ajustado a "23:59:59" de la fecha especificada. El último momento del día.
        /// </summary>
        /// <param name="dt">El valor de origen a evaluar</param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }

        /// <summary>
        /// Devuelve el tiempo ajustado a "00:00:00" de la fecha especificada. El primer momento del día..
        /// </summary>
        /// <param name="dt">el valor de origen a evaluar</param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

        /// <summary>
        /// Devuelve el primer día del mes de la fecha especificada, con el tiempo ajustado a "00:00:00".
        /// </summary>
        /// <param name="dt">el valor de origen a evaluar</param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1).StartOfDay();
        }

        /// <summary>
        /// Devuelve el último día del mes de la fecha especificada, con el tiempo ajustado a "23:59:59".
        /// </summary>
        /// <param name="dt">el valor de origen a evaluar</param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt)
        {
            return dt.AddMonths(1).StartOfMonth().AddDays(-1).EndOfDay();
        }

        /// <summary>
        /// Devuelve el primer día del año de la fecha especificada, con el tiempo ajustado a "00:00:00".
        /// </summary>
        /// <param name="dt">el valor de origen a evaluar</param>
        /// <returns></returns>
        public static DateTime StartOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1).StartOfDay();
        }

        /// <summary>
        /// Devuelve el último día del año de la fecha especificada, con el tiempo ajustado a "23:59:59".
        /// </summary>
        /// <param name="dt">el valor de origen a evaluar</param>
        /// <returns></returns>
        public static DateTime EndOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 12, 31).EndOfDay();
        }

        /// <summary>
        /// Devuelve el inicio del día para el primer día de la semana del DateTime especificado.
        /// </summary>
        /// <param name="dt">el valor de origen a evaluar</param>
        /// <param name="startDayOfWeek">Opcional. El DayOfWeek que es el primer día de la semana. El valor predeterminado es el domingo.</param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startDayOfWeek = DayOfWeek.Sunday)
        {
            var start = dt.StartOfDay();

            if (start.DayOfWeek != startDayOfWeek)
            {
                var d = startDayOfWeek - start.DayOfWeek;
                if (startDayOfWeek <= start.DayOfWeek)
                {
                    return start.AddDays(d);
                }
                else
                {
                    return start.AddDays(-7 + d);
                }
            }

            return start;
        }

        /// <summary>
        /// Devuelve el inicio del dia párr El último Día de la Semana del DateTime Especificado.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startDayOfWeek">Opcional. El DayOfWeek representa al primer día de la semana. El valor predeterminado es el domingo.</param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startDayOfWeek = DayOfWeek.Sunday)
        {
            var end = dt.StartOfDay();
            var endDayOfWeek = startDayOfWeek - 1;
            if (endDayOfWeek < 0)
            {
                endDayOfWeek = DayOfWeek.Saturday;
            }

            if (end.DayOfWeek != endDayOfWeek)
            {
                var d = endDayOfWeek - end.DayOfWeek;
                if (endDayOfWeek == end.DayOfWeek)
                {
                    return end.AddDays(6);
                }
                else if (endDayOfWeek < end.DayOfWeek)
                {
                    return end.AddDays(7 - (end.DayOfWeek - endDayOfWeek));
                }
                else
                {
                    return end.AddDays(endDayOfWeek - end.DayOfWeek);
                }
            }

            return end;
        }

        /// <summary>
        /// Redondea el DateTime en el número especificado de minutos más cercana
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static DateTime RoundToNearest(this DateTime dt, int minutes)
        {
            return dt.RoundToNearest(minutes.Minutes());
        }

        /// <summary>
        /// Redondea el DateTime con una precisión especifica TimeSpan interna
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static DateTime RoundToNearest(this DateTime dt, TimeSpan timeSpan)
        {
            var roundDown = false;
            var mod = (dt.Ticks % timeSpan.Ticks);
            if (mod != 0 && mod < (timeSpan.Ticks / 2))
            {
                roundDown = true;
            }

            var ticks = (((dt.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks) - (roundDown ? 1 : 0)) * timeSpan.Ticks;

            var addticks = ticks - dt.Ticks;

            return dt.AddTicks(addticks);
        }

        /// <summary>
        /// Devuelve el número de milisegundos desde 1 de enero 1970 hasta el DateTime especificado
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static double MillisecondsSince1970(this DateTime dt)
        {
            return dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
        }

    }
}
