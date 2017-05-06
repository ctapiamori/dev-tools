using System.IO;

namespace CATM.DevTools.Utils
{
    /// <summary>
    /// Utilidades para los Bytes (Byte)
    /// </summary>
    public class ByteUtil
    {
        /// <summary>
        /// Convierte un Objeto Stream en un Array de Bytes
        /// </summary>
        /// <param name="input">Objeto Stream</param>
        /// <returns>Array de Bytes</returns>
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
