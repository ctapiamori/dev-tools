using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATM.DevTools.Extensions
{
    public static class TimeSpanExtensions
    {
        #region "Ago"

        /// <summary>
        /// Returns the Current DateTime with the specified TimeSpan subtracted from it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime Ago(this System.TimeSpan ts)
        {
            return DateTime.Now.Subtract(ts);
        }

        /// <summary>
        /// Returns the Current Coordinated Universal Time (UTC) with the specified TimeSpan subtracted from it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime UtcAgo(this TimeSpan ts)
        {
            return DateTime.UtcNow.Subtract(ts);
        }

        #endregion

        #region "FromNow"

        /// <summary>
        /// Returns the Current DateTime with the specified TimeSpan added to it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime FromNow(this TimeSpan ts)
        {
            return DateTime.Now.Add(ts);
        }

        /// <summary>
        /// Returns the Current Coordinated Universal Time (UTC) with the specified TimeSpan added to it.
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime UtcFromNow(this TimeSpan ts)
        {
            return DateTime.UtcNow.Add(ts);
        }

        #endregion
    }
}
