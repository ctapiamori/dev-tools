using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATM.DevTools.Extensions
{
    public static class IComparableExtensions
    {
        /// <summary>
        /// Devuelve un valor booleano que indica si el valor de origen está dentro del rango mínimo y máximo especificado (ambos inclusive).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">El valor de origen a comprobar.</param>
        /// <param name="min">El valor mínimo del rango a comprobar.</param>
        /// <param name="max">El valor máximo del rango a comprobar.</param>
        /// <returns></returns>
        public static bool InRange<T>(this T source, T min, T max)
            where T : IComparable
        {
            return source.CompareTo(min) >= 0 && source.CompareTo(max) <= 0;
        }
    }
}
