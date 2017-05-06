using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CATM.DevTools.Extensions
{
    /// <summary>
    /// Contiene metodos nuevos para la clase XDocument
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Valida si una cadena tiene un formato valido
        /// </summary>
        /// <param name="xDoc">XDocument actual</param>
        /// <param name="xml">Cadena a validar</param>
        /// <returns>bool</returns>
        public static bool TryParse(ref XDocument xDoc, string xml)
        {
            try
            {
                xDoc = XDocument.Parse(xml);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Valida si existe un elemento
        /// </summary>
        /// <param name="xElement">XElement actual</param>
        /// <param name="name">Nombre del elemento</param>
        /// <returns>bool</returns>
        public static bool ElementExists(this XElement xElement, string name)
        {
            return xElement.Element(name) != null;
        }
    }
}
