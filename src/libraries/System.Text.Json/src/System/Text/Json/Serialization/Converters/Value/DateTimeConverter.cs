// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Text.Json.Serialization.Converters
{
    /// <summary>
    /// todo
    /// </summary>
    public sealed class DateTimeConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// todo
        /// </summary>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDateTime();
        }

        /// <summary>
        /// todo
        /// </summary>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }

        internal override DateTime ReadWithQuotes(ref Utf8JsonReader reader)
        {
            return reader.GetDateTimeNoValidation();
        }

        internal override void WriteWithQuotes(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options, ref WriteStack state)
        {
            writer.WritePropertyName(value);
        }
    }
}
