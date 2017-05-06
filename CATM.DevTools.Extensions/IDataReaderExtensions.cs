using System;
using System.Data;

namespace CATM.DevTools.Extensions
{
    /// <summary>
    /// Extencsión de la Interface IDataReader
    /// </summary>
    public static class IDataReaderExtensions
    {
        /// <summary>
        /// Este método extiende el método GetString del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor String</param>
        /// <returns></returns>
        public static string GetString(this IDataReader reader, string field)
        {
            return reader.GetString(field, null);
        }

        /// <summary>
        /// Este método extiende el método GetString del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor String</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString(this IDataReader reader, string field, string defaultValue)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetString(ordinal);
        }

        /// <summary>
        /// Este método extiende el método GetInt16 del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Int16</param>
        /// <returns></returns>
        public static short GetInt16(this IDataReader reader, string field)
        {
            return reader.GetInt16(field, 0);
        }

        /// <summary>
        /// Este método extiende el método GetInt16 del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Int16</param>
        /// <param name="defaultValue"></param>
        /// <returns>Entero corto (Short)</returns>
        public static short GetInt16(this IDataReader reader, string field, short defaultValue)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetInt16(ordinal);
        }

        /// <summary>
        /// Este método extiende el método GetInt32 del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Int32</param>
        /// <returns>Entero (Int)</returns>
        public static int GetInt32(this IDataReader reader, string field)
        {
            return reader.GetInt32(field, 0);
        }

        /// <summary>
        /// Este método extiende el método GetInt32 del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Int32</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt32(this IDataReader reader, string field, int defaultValue)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetInt32(ordinal);
        }

        public static int? GetNullableInt32(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? null : (int?)reader.GetInt32(ordinal);
        }

        public static DateTime GetDateTime(this IDataReader reader, string field)
        {
            return reader.GetDateTime(field, DateTime.MinValue);
        }

        /// <summary>
        /// Este método extiende el método GetDateTime del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor DateTime</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this IDataReader reader, string field, DateTime defaultValue)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetDateTime(ordinal);
        }

        public static DateTime? GetNullableDateTime(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? null : (DateTime?)reader.GetDateTime(ordinal);
        }

        /// <summary>
        /// Este método extiende el método GetBoolean del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Boolean</param>
        /// <returns></returns>
        public static bool GetBoolean(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);

            if (!reader.IsDBNull(ordinal))
            {
                try
                {
                    return reader.GetBoolean(ordinal);
                }
                catch (InvalidCastException)
                {
                    //We will swallow this exception as it's expected if our value has a dataType of bit. 
                    //We will try and handle that by casting to an Int16.
                    //If it fails here, we will allow the exception to get thrown
                    return (reader.GetInt16(ordinal) == 1);
                }
            }
            return false;
        }

        public static bool? GetNullableBoolean(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);

            if (!reader.IsDBNull(ordinal))
            {
                try
                {
                    return (bool?)reader.GetBoolean(ordinal);
                }
                catch (InvalidCastException)
                {
                    return (bool?)(reader.GetInt16(ordinal) == 1);
                }
            }
            return null;
        }

        public static bool IsDBNull(this IDataReader reader, string field)
        {
            return reader.IsDBNull(reader.GetOrdinal(field));
        }

        public static decimal GetDecimal(this IDataReader reader, string field)
        {
            return reader.GetDecimal(field, 0m);
        }

        /// <summary>
        /// Este método extiende el método GetDecimal del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Decimal</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal GetDecimal(this IDataReader reader, string field, decimal defaultValue)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetDecimal(ordinal);
        }

        public static decimal? GetNullableDecimal(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? null : (decimal?)reader.GetDecimal(ordinal);
        }

        public static double GetDouble(this IDataReader reader, string field)
        {
            return reader.GetDouble(field, 0d);
        }

        /// <summary>
        /// Este método extiende el método GetDouble del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Double</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDouble(this IDataReader reader, string field, double defaultValue)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetDouble(ordinal);
        }

        public static double? GetNullableDouble(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? null : (double?)reader.GetDouble(ordinal);
        }

        public static float GetFloat(this IDataReader reader, string field)
        {
            return reader.GetFloat(field, 0f);
        }

        /// <summary>
        /// Este método extiende el método GetFloat del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Float</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetFloat(this IDataReader reader, string field, float defaultValue)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetFloat(ordinal);
        }

        public static float? GetNullableFloat(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? null : (float?)reader.GetFloat(ordinal);
        }

        /// <summary>
        /// Este método extiende el método GetGuid del data reader para permitir que llame por el nombre del campo
        /// </summary>
        /// <param name="reader">El objeto que estamos extendiendo</param>
        /// <param name="field">El nombre del campo que estamos recibiendo para obtener el valor Guid</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid GetGuid(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? Guid.Empty : reader.GetGuid(ordinal);
        }

        public static Guid? GetNullableGuid(this IDataReader reader, string field)
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? null : (Guid?)reader.GetGuid(ordinal);
        }

        public static byte GetByte(this IDataReader reader, string field, byte defaultValue = default(byte))
        {
            var ordinal = reader.GetOrdinal(field);
            return reader.IsDBNull(ordinal) ? defaultValue : Convert.ToByte(reader.GetValue(ordinal));
        }

        public static byte[] GetBytes(this IDataReader reader, string field)
        {
            return reader.ToByteArray(field);
        }

        public static byte[] ToByteArray(this IDataReader reader, string field)
        {
            byte[] blob = null;
            if (reader[field] != DBNull.Value)
            {
                try
                {
                    blob = new byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                    reader.GetBytes(0, 0, blob, 0, blob.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception ToByteArray: " + e.Message);
                }
            }
            return blob;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="field"></param>
        /// <example>reader.GetValueOrDefault< Type/Type? >("field")</example>
        /// <returns></returns>
        public static T GetValueOrDefault<T>(this IDataReader reader, string field)
        {
            //Example: 
            object value = reader[field];
            if (DBNull.Value == value) return default(T);
            return (T)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="ordinal"></param>
        /// <example>reader.GetValueOrDefault< Type/Type? >(ordinal)</example>
        /// <returns></returns>
        public static T GetValueOrDefault<T>(this IDataReader reader, int ordinal)
        {
            //Example: reader.GetValueOrDefault<decimal?>(ordinal)
            if (reader.IsDBNull(ordinal)) return default(T);
            return (T)reader[ordinal];
        }

        /// <summary>
        /// This method extends the HasColumn
        /// </summary>
        /// <param name="dataReader">El objeto que estamos extendiendo</param>
        /// <param name="columnName">Nombre de columna</param>
        /// <returns></returns>
        public static bool HasColumn(this IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static DataTable ToDataTable(this IDataReader reader)
        {
            var table = new DataTable();
            for (var i = 0; i > reader.FieldCount; ++i)
            {
                table.Columns.Add(new DataColumn
                {
                    ColumnName = reader.GetName(i),
                    DataType = reader.GetFieldType(i)
                }
                                    );
            }

            while (reader.Read())
            {
                var row = table.NewRow();
                reader.GetValues(row.ItemArray);
                table.Rows.Add(row);
            }

            return table;
        }

        public static DataSet ToDataSet(this IDataReader reader, string tableName = "readerTable")
        {
            var dataSet = new DataSet();
            dataSet.Load(reader, LoadOption.PreserveChanges, tableName);

            return dataSet;
        }

    }
}
