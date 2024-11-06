/*
 * JsonStringEnumDisplayNameConverter.cs
 *     Created: 2024-10-27T20:05:04-04:00
 *    Modified: 2024-10-27T20:05:04-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 © 2024 Dr. David Gerard, All Rights Reserved, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Converters;

public class JsonStringEnumDisplayNameConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
    {
        if (reader.TokenType != JTokenType.String)
        {
            throw new JException($"Expected a string value, but got {reader.TokenType}.");
        }

        var enumString = reader.GetString();
        foreach (var e in Enum.GetValues<TEnum>())
        {
            if (e.GetDisplayName() == enumString || e.ToString() == enumString)
            {
                return e;
            }
        }

        throw new JException(
            $"Could not convert the string value '{enumString}' to an enum value of type {typeof(TEnum).Name}."
        );
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, Jso options)
    {
        var displayName = value.GetDisplayName();
        writer.WriteStringValue(displayName);
    }
}
