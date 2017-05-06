
namespace CATM.DevTools.Utils
{
    /// <summary>
    /// Utilidades para los Textos (String)
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// Obtiene un Texto (String) desde una posición de un Texto (String) Divido usando un Caracter (Char) como separador, si no existe devuelve un valor por defecto.
        /// </summary>
        /// <param name="value">Texto (String) a dividir</param>
        /// <param name="caracter">Caracter (char) separador del Texto</param>
        /// <param name="position">Posición del Texto que se desea obtener</param>
        /// <param name="defaultValue">Valor por defecto si no se encuentra la posición</param>
        /// <returns>Texto (String)</returns>
        public static string SplitValue(string value, char caracter, int position, string defaultValue = "")
        {
            var valueSplit = value.Split(caracter);
            return valueSplit.Length > position ? valueSplit[position] : defaultValue;
        }

        /// <summary>
        /// Obtiene un Texto (String) desde una posición de un Array de Textos (String[]), si no existe devuelve un valor por defecto.
        /// </summary>
        /// <param name="values">Array de Textos (String[])</param>
        /// <param name="position">Posición del Texto que se desea obtener</param>
        /// <param name="defaultValue">Valor por defecto si no se encuentra la posición</param>
        /// <returns>Texto (String)</returns>
        public static string Value(string[] values, int position, string defaultValue = "")
        {
            return values.Length > position ? values[position] : defaultValue;
        }
    }
}
