
namespace CATM.DevTools.Utils
{
    /// <summary>
    /// Utilidades para los Enteros (Int)
    /// </summary>
    public class IntUtil
    {
        /// <summary>
        /// Analiza el Texto (String) para obtener un Entero (Int)
        /// </summary>
        /// <param name="number">Texto (String) a analizar</param>
        /// <returns>Número Entero (Int)</returns>
        public static int Parse(string number)
        {
            var result = 0;
            int.TryParse(number, out result);
            return result;
        }

        /// <summary>
        /// Verifica si un Entero (Int) se encuentra entre dos valores Enteros (Int)
        /// </summary>
        /// <param name="number">Entero (Int) a verificar</param>
        /// <param name="compareStart">Enero (Int) inicial a comparar</param>
        /// <param name="compareEnd">Enero (Int) final a comparar</param>
        /// <returns>Booleano</returns>
        public static bool Between(int number, int compareStart, int compareEnd)
        {
            return number >= compareStart && number <= compareEnd;
        }

        /// <summary>
        /// Verifica si un Entero (Int) es menor a otro Entero (Int)
        /// </summary>
        /// <param name="number">Entero (Int) a verificar</param>
        /// <param name="compare">Entero (Int) a comparar</param>
        /// <returns>Booleano</returns>
        public static bool IsLess(int number, int compare)
        {
            return number < compare;
        }

        /// <summary>
        /// Verifica si un Entero (Int) es menor o igual a otro Entero (Int)
        /// </summary>
        /// <param name="number">Entero (Int) a verificar</param>
        /// <param name="compare">Entero (Int) a comparar</param>
        /// <returns>Booleano</returns>
        public static bool IsLessOrEqual(int number, int compare)
        {
            return number <= compare;
        }

        /// <summary>
        /// Verifica si un Entero (Int) es mayor a otro Entero (Int)
        /// </summary>
        /// <param name="number">Entero (Int) a verificar</param>
        /// <param name="compare">Entero (Int) a comparar</param>
        /// <returns>Booleano (boolean)</returns>
        public static bool IsGreater(int number, int compare)
        {
            return number > compare;
        }

        /// <summary>
        /// Verifica si un Entero (Int) es mayor o igual a otro Entero (Int)
        /// </summary>
        /// <param name="number">Entero (Int) a verificar</param>
        /// <param name="compare">Entero (Int) a comparar</param>
        /// <returns>Booleano (boolean)</returns>
        public static bool IsGreaterOrEqual(int number, int compare)
        {
            return number >= compare;
        }

        /// <summary>
        /// Obtiene un Booleano (boolean) que indica si un Número (Int) es Impar.
        /// </summary>
        /// <param name="number">Número a Comparar</param>
        /// <returns>Booleano (boolean)</returns>
        public static bool IsOdd(int number)
        {
            return (number % 2) != 0;
        }

        /// <summary>
        /// Obtiene un Booleano (boolean) que indica si un Número (Int) es Par.
        /// </summary>
        /// <param name="number">Número a Comparar</param>
        /// <returns>Booleano (boolean)</returns>
        public static bool IsEven(int number)
        {
            return (number % 2) == 0;
        }
    }
}
