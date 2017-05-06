using System.Text.RegularExpressions;

namespace CATM.DevTools.Utils
{
    /// <summary>
    /// Utilidades para los Booleanos (Boolean)
    /// </summary>
    public class BooleanUtil
    {
        /// <summary>
        /// Analizador de Texto (String) para obtener un Booleano (Boolean)
        /// </summary>
        /// <param name="boolean">Texto (String) ha analizar</param>
        /// <returns>Valor Booleano (Boolean)</returns>
        public static bool Parse(string boolean)
        {
            string pattern = @"(true|1|True)";
            return Regex.IsMatch(boolean, pattern);
        }
    }
}
