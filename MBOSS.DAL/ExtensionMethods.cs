using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Mboss.DataAccess
{
    public static class SqlDataReaderExtensionMethods
    {
        public static Guid GetGuid(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetGuid(dr.GetOrdinal(columnName));
            return Guid.Empty;
        }

        public static string GetString(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetString(dr.GetOrdinal(columnName));
            return string.Empty;
        }
        public static int GetInt(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetInt32(dr.GetOrdinal(columnName));
            return 0;
        }
        public static bool GetBoolean(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetBoolean(dr.GetOrdinal(columnName));
            return false;
        }
        public static DateTime GetUtcDateTime(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return DateTime.SpecifyKind(dr.GetDateTime(dr.GetOrdinal(columnName)), DateTimeKind.Utc);
            return DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        }

        public static DateTime GetDateTime(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetDateTime(dr.GetOrdinal(columnName));
            return DateTime.MinValue;
        }

        public static double GetDouble(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetDouble(dr.GetOrdinal(columnName));
            return 0.0;
        }

        public static decimal GetDecimal(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetDecimal(dr.GetOrdinal(columnName));
            return 0;
        }

        public static long GetLong(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetInt64(dr.GetOrdinal(columnName));
            return 0;
        }

        public static float GetFloat(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
                return dr.GetFloat(dr.GetOrdinal(columnName));
            return 0;
        }

        public static System.Globalization.CultureInfo GetCulture(this System.Data.IDataRecord dr, string columnName)
        {
            var culture = GetString(dr, columnName);

            if (culture != null)
            {
                return new System.Globalization.CultureInfo(culture);
            }
            return System.Globalization.CultureInfo.InvariantCulture;
        }

        public static byte[] GetBytes(this System.Data.IDataRecord dr, string columnName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(columnName)))
            {
                long len = dr.GetBytes(dr.GetOrdinal(columnName), 0, null, 0, 0);
                Byte[] buffer = new Byte[len];
                dr.GetBytes(dr.GetOrdinal(columnName), 0, buffer, 0, (int)len);
                return buffer;
            }
            return null;
        }
    }
}
