using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATM.DevTools.Utils
{
    /// <summary>
    /// Utilidades para Json
    /// </summary>
    public class JsonUtil
    {
        /// <summary>  
        /// Convierte un Objeto (object) a Texto (String) en formato Json. 
        /// </summary>  
        /// <remarks>
        /// Dependencias: <see cref="System.Web.Extensions"/>
        /// </remarks>
        /// <param name="obj">Objeto (object) a convertir</param>  
        /// <returns>Texto (String) en formato Json</returns>  
        public static string ToJSON(object obj)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                return serializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
