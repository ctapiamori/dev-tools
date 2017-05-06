using System;

namespace CATM.DevTools.Utils
{
    /// <summary>
    /// Utilidades para las Fechas (DateTime)
    /// </summary>
    public class DateTimeUtil
    {
        /// <summary>
        /// Obtiene la Edad desde la fecha de nacimiento hasta la fecha actual
        /// </summary>
        /// <param name="birthdate">Fecha de nacimiento</param>
        /// <returns>Edad</returns>
        public static long GetYearOld(DateTime birthdate)
        {
            return DateTime.Today.AddTicks(-birthdate.Ticks).Year - 1;
        }

        /// <summary>
        /// Obtiene la Edad desde la fecha de nacimiento hasta la fecha indicada
        /// </summary>
        /// <param name="birthdate">Fecha de nacimiento</param>
        /// <param name="dateTimeValidate">Fecha para calcular la Edad</param>
        /// <returns>Edad</returns>
        public static long GetYearOld(DateTime birthdate, DateTime dateTimeValidate)
        {
            return dateTimeValidate.AddTicks(-birthdate.Ticks).Year - 1;
        }

        /// <summary>
        /// Analiza el Texto (String) para convertir a Fecha (DateTime) según el Formato
        /// </summary>
        /// <param name="fecha">Texto (String) ha analizar</param>
        /// <param name="format">Formato de fecha</param>
        /// <returns>DateTime</returns>
        public static DateTime Parse(string fecha, string format)
        {
            return DateTime.ParseExact(fecha, format, null);
        }

        /// <summary>
        /// Analiza el Texto (String) en formato dd/MM/yyyy para convertir a Fecha
        /// </summary>
        /// <param name="fecha">Texto (String) ha analizar</param>
        /// <returns>DateTime</returns>
        public static DateTime ParseDDMMYYYY(string fecha)
        {
            return DateTime.ParseExact(fecha, DateTimeFormats.FORMAT_ddMMyyyy, null);
        }

        /// <summary>
        /// Analiza el Texto (String) en formato dd/MM/yyyy para convertir a Fecha (DateTime), si el Texto (String) no es correcto devuelve Null
        /// </summary>
        /// <param name="fecha">Texto (String) ha analizar</param>
        /// <returns>Nullable<DateTime></returns>
        public static DateTime? ParseNullableDDMMYYYY(string fecha)
        {
            DateTime fechaNull;
            var succed = DateTime.TryParseExact(fecha, DateTimeFormats.FORMAT_ddMMyyyy, null, System.Globalization.DateTimeStyles.None, out fechaNull);
            if (!succed) return null;
            return fechaNull;
        }

        /// <summary>
        /// Analiza el Texto (String) en formato yyyyMMdd para convertir a Fecha (DateTime)
        /// </summary>
        /// <param name="fecha">Texto (String) ha analizar</param>
        /// <returns>DateTime</returns>
        public static DateTime ParseYYYYMMDD(string fecha)
        {
            return DateTime.ParseExact(fecha, DateTimeFormats.FORMAT_yyyyMMdd, null);
        }

        /// <summary>
        /// Analiza el Texto (String) en formato yyyy-MM-dd para convertir a Fecha (DateTime) 
        /// </summary>
        /// <param name="fecha">Texto (String) ha analizar</param>
        /// <returns>DateTime</returns>
        public static DateTime ParseEstandar(string fecha)
        {
            return DateTime.ParseExact(fecha, DateTimeFormats.FORMAT_STANDAR, null);
        }

        /// <summary>
        /// Analiza el Fecha (DateTime) para convertirlo en Texto (String) en formato dd/MM/yyyy
        /// </summary>
        /// <param name="fecha">Fecha (DateTime) ha analizar</param>
        /// <returns>String en Formato dd/MM/yyyy</returns>
        public static string ToStringDDMMYYYY(DateTime? fecha)
        {
            return fecha.GetValueOrDefault().ToString(DateTimeFormats.FORMAT_ddMMyyyy);
        }


        /// <summary>
        /// Obtiene la diferencia de Meses entre dos fechas
        /// </summary>
        /// <param name="dateFirst">Fecha (DateTime) inicial</param>
        /// <param name="dateLast">Fecha (DateTime) final</param>
        /// <returns>Diferencia de Meses</returns>
        public static double GetMonths(DateTime dateFirst, DateTime dateLast)
        {
            return dateLast.Subtract(dateFirst).Days / (365.25 / 12);
        }

        /// <summary>
        /// Verifica si dos Fechas son iguales
        /// </summary>
        /// <param name="dateFirst">Fecha (DateTime) a verificar</param>
        /// <param name="dateLast">Fecha (DateTime) a comprara</param>
        /// <returns>Boolean</returns>
        public static bool IsEqual(DateTime dateFirst, DateTime dateLast)
        {
            return DateTime.Compare(dateFirst, dateLast) == 0;
        }

        /// <summary>
        /// Verifica si la fecha es Menor
        /// </summary>
        /// <param name="dateFirst">Fecha (DateTime) a verificar</param>
        /// <param name="dateLast">Fecha (DateTime) a comparar</param>
        /// <returns></returns>
        public static bool IsLess(DateTime dateFirst, DateTime dateLast)
        {
            return DateTime.Compare(dateFirst, dateLast) < 0;
        }

        /// <summary>
        /// Verifica si la fecha es Mayor
        /// </summary>
        /// <param name="dateFirst">Fecha (DateTime) a verificar</param>
        /// <param name="dateLast">Fecha (DateTime) a compara</param>
        /// <returns></returns>
        public static bool IsGreater(DateTime dateFirst, DateTime dateLast)
        {
            return DateTime.Compare(dateFirst, dateLast) > 0;
        }
    }

    /// <summary>
    /// Formatos de Fecha
    /// </summary>
    public class DateTimeFormats
    {
        public const string FORMAT_ddMMyyyy = "dd/MM/yyyy";
        public const string FORMAT_yyyyMMdd = "yyyyMMdd";
        public const string FORMAT_STANDAR = "yyyy-MM-dd";
    }
}
