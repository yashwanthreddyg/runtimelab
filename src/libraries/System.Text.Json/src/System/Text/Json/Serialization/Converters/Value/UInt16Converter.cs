// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Text.Json.Serialization.Converters
{
    /// <summary>
    /// todo
    /// </summary>
    [CLSCompliant(false)]
    public sealed class UInt16Converter : JsonConverter<ushort>
    {
        /// <summary>
        /// todo
        /// </summary>
        public UInt16Converter()
        {
            IsInternalConverterForNumberType = true;
        }

        /// <summary>
        /// todo
        /// </summary>
        public override ushort Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetUInt16();
        }

        /// <summary>
        /// todo
        /// </summary>
        public override void Write(Utf8JsonWriter writer, ushort value, JsonSerializerOptions options)
        {
            // For performance, lift up the writer implementation.
            writer.WriteNumberValue((long)value);
        }

        internal override ushort ReadWithQuotes(ref Utf8JsonReader reader)
        {
            return reader.GetUInt16WithQuotes();
        }

        internal override void WriteWithQuotes(Utf8JsonWriter writer, ushort value, JsonSerializerOptions options, ref WriteStack state)
        {
            writer.WritePropertyName(value);
        }

        internal override ushort ReadNumberWithCustomHandling(ref Utf8JsonReader reader, JsonNumberHandling handling)
        {
            if (reader.TokenType == JsonTokenType.String &&
                (JsonNumberHandling.AllowReadingFromString & handling) != 0)
            {
                return reader.GetUInt16WithQuotes();
            }

            return reader.GetUInt16();
        }

        internal override void WriteNumberWithCustomHandling(Utf8JsonWriter writer, ushort value, JsonNumberHandling handling)
        {
            if ((JsonNumberHandling.WriteAsString & handling) != 0)
            {
                writer.WriteNumberValueAsString(value);
            }
            else
            {
                // For performance, lift up the writer implementation.
                writer.WriteNumberValue((long)value);
            }
        }
    }
}
