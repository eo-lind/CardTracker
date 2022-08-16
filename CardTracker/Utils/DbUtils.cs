﻿using Microsoft.Data.SqlClient;
using System;

namespace CardTracker.Utils
{
    public class DbUtils
    {
        ///  Get a string from a data reader object and gracefully handle NULL values
        public static string GetString(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }

            return reader.GetString(ordinal);
        }

        ///  Get an int from a data reader object.
        ///  This method assumes the value is not NULL.
        public static int GetInt(SqlDataReader reader, string column)
        {
            return reader.GetInt32(reader.GetOrdinal(column));
        }

        ///  Get a DateTime from a data reader object.
        ///  This method assumes the value is not NULL.
        public static DateTime GetDateTime(SqlDataReader reader, string column)
        {
            return reader.GetDateTime(reader.GetOrdinal(column));
        }

        ///  Get an int? (nullable int) from a data reader object and gracefully handle NULL values
        public static int? GetNullableInt(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }

            return reader.GetInt32(ordinal);
        }

        ///  Get a DateTime? (nullable DateTime) from a data reader object and gracefully handle NULL values
        public static DateTime? GetNullableDateTime(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }

            return reader.GetDateTime(ordinal);
        }

        /// Get a string? (nullable string) from a data reader object and gracefully handle NULL values
        //public static string? GetNullableString(SqlDataReader reader, string column)
        //{
        //    var ordinal = reader.GetOrdinal(column);
        //    if (reader.IsDBNull(ordinal))
        //    {
        //        return null;
        //    }

        //    return reader.GetString(ordinal);
        //}

        ///  Determine if the value a given column is NULL
        public static bool IsDbNull(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column));
        }

        ///  Determine if the value a given column is not NULL
        public static bool IsNotDbNull(SqlDataReader reader, string column)
        {
            return !IsDbNull(reader, column);
        }

        ///  Add a parameter to the given SqlCommand object and gracefully handle null values.
        public static void AddParameter(SqlCommand cmd, string name, object value)
        {
            if (value == null)
            {
                cmd.Parameters.AddWithValue(name, DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue(name, value);
            }
        }
    }
}
