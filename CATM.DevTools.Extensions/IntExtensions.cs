using System;

namespace CATM.DevTools.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Devuelve un valor booleano que indica si el numero entero es un numero impar.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsOdd(this int i)
        {
            return (i % 2) != 0;
        }

        /// <summary>
        /// Devuelve un valor booleano que indica si el numero entero es un numero par.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsEven(this int i)
        {
            return (i % 2) == 0;
        }

        /// <summary>
        /// Repite desde el Int. través del stopAt especificado y llama a la acción especificada para cada paso en el iterador.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="stopAt"></param>
        /// <param name="action"></param>
        public static void UpTo(this int i, int stopAt, Action<int> action)
        {
            for (var a = i; a <= stopAt; a++)
            {
                action(a);
            }
        }

        /// <summary>
        /// Devuelve un valor booleano que indica que el número entero esta entre los valores low y high especificados.
        /// </summary>
        /// <example>
        /// 1 is between 0 and 2, but 0 or 2 are not
        /// </example>
        /// <param name="i"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static bool Between(this int i, int low, int high)
        {
            return i > low && i < high;
        }

        /// <summary>
        /// Devuelve un valor booleano que indica que el número entero es "mayor" al valor iCompare especificado.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iCompare"></param>
        /// <returns></returns>
        public static bool IsGreater(this int i, int iCompare)
        {
            if (i.IsNull()) return false;
            return i > iCompare;
        }

        /// <summary>
        /// Devuelve un valor booleano que indica que el número entero es "mayor" o "igual" al valor iCompare especificado.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iCompare"></param>
        /// <returns></returns>
        public static bool IsGreaterOrEqual(this int i, int iCompare)
        {
            if (i.IsNull()) return false;
            return i >= iCompare;
        }

        /// <summary>
        /// Devuelve un valor booleano que indica que el número entero es "inferior" al valor iCompare especificado.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iCompare"></param>
        /// <returns></returns>
        public static bool IsLower(this int i, int iCompare)
        {
            if (i.IsNull()) return false;
            return i < iCompare;
        }

        /// <summary>
        /// Devuelve un valor booleano que indica que el número entero es "inferior" o "igual" al valor iCompare especificado.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iCompare"></param>
        /// <returns></returns>
        public static bool IsLowerOrEqual(this int i, int iCompare)
        {
            if (i.IsNull()) return false;
            return i <= iCompare;
        }

        /// <summary>
        /// Devuelve un valor booleano que indica uqe el numero entero no es igual al valor compare especificado.
        /// </summary>
        /// <param name="i">El valor origen a comprobar</param>
        /// <param name="compare">El valor a comparar</param>
        /// <returns></returns>
        public static bool NotEquals(this int i, int compare)
        {
            return !i.Equals(compare);
        }


        #region Times

        /// <summary>
        /// Ejecuta la acción especificada el número de veces especificado, pasando el valor iterador cada vez.
        /// </summary>
        /// <param name="i">El valor origen</param>
        /// <param name="action"></param>
        public static void Times(this int i, Action<int> action)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException("i", "i must be not be less than zero.");
            }

            for (var c = 0; c < i; c++)
            {
                action(c);
            }
        }

        #endregion

        #region "TimeSpan extensions"

        /// <summary>
        /// Devuelve un TimeSpan que representa el número entero en milisegundos
        /// </summary>
        /// <param name="i">El valor origen</param>
        /// <returns></returns>
        public static TimeSpan Milliseconds(this int i)
        {
            return TimeSpan.FromMilliseconds(i);
        }

        /// <summary>
        /// Devuelve un TimeSpan que representa el número entero en segundos
        /// </summary>
        /// <param name="i">El valor origen</param>
        /// <returns></returns>
        public static TimeSpan Seconds(this int i)
        {
            return TimeSpan.FromSeconds(i);
        }

        /// <summary>
        /// Devuelve un TimeSpan que representa el número entero en minutos
        /// </summary>
        /// <param name="i">El valor origen</param>
        /// <returns></returns>
        public static TimeSpan Minutes(this int i)
        {
            return TimeSpan.FromMinutes(i);
        }

        /// <summary>
        /// Devuelve un TimeSpan que representa el número entero de horas
        /// </summary>
        /// <param name="i">El valor origen</param>
        /// <returns></returns>
        public static TimeSpan Hours(this int i)
        {
            return TimeSpan.FromHours(i);
        }

        /// <summary>
        /// Devuelve un TimeSpan que representa el número entero de días
        /// </summary>
        /// <param name="i">El valor origen</param>
        /// <returns></returns>
        public static TimeSpan Days(this int i)
        {
            return TimeSpan.FromDays(i);
        }

        /// <summary>
        /// Devuelve un TimeSpan que representa el entero en semanas
        /// </summary>
        /// <param name="i">El valor origen</param>
        /// <returns></returns>
        public static TimeSpan Weeks(this int i)
        {
            return ((TimeSpanWrapper)i.Days() * 7);
        }

        #endregion

    }
}
