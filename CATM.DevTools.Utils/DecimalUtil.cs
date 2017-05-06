
namespace CATM.DevTools.Utils
{
    /// <summary>
    /// Utilidades para los Números Enteros (Decimal)
    /// </summary>
    public class DecimalUtil
    {
        /// <summary>
        /// Analiza el Texto (String) para obtener un Número Decimal (Decimal)
        /// </summary>
        /// <param name="numero">Texto (String) a analizar</param>
        /// <returns>Número Decimal (Decimal)</returns>
        public static decimal Parse(string numero)
        {
            var result = 0m;
            decimal.TryParse(numero, out result);
            return result;
        }
    }
}
