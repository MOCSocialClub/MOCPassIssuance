/*
 * JsonPassbookFieldConverter.cs
 *     Created: 2024-10-27T21:23:27-04:00
 *    Modified: 2024-10-27T21:23:28-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 © 2024 Dr. David Gerard, All Rights Reserved, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Converters;

public class JsonPassbookFieldConverter : JsonConverter<Field>
{
    public override Field? Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
    {
        var jObject = JDoc.Parse(reader.GetString()).RootElement;
        var fieldType = jObject.GetProperty(nameof(Field.FieldType)).GetString();
        switch (fieldType)
        {
            case string s when s.Equals(FieldType.Text):
                return new StandardField(
                    jObject.GetProperty(nameof(StandardField.Key)).GetString() ?? string.Empty,
                    jObject.GetProperty(nameof(StandardField.Label)).GetString() ?? string.Empty,
                    jObject.GetProperty(nameof(StandardField.Value)).GetString() ?? string.Empty,
                    jObject.GetProperty(nameof(StandardField.AttributedValue)).GetString()
                        ?? string.Empty,
                    Enum.TryParse<DataDetectorTypes>(
                        jObject.GetProperty(nameof(DataDetectorTypes)).GetString(),
                        out var dataDetectorTypes
                    )
                        ? dataDetectorTypes
                        : DataDetectorTypes.PKDataDetectorAll
                );
            case string s when s.Equals(nameof(FieldType.Date)):
                return new DateField(
                    jObject.GetProperty(nameof(StandardField.Key)).GetString(),
                    jObject.GetProperty(nameof(StandardField.Label)).GetString(),
                    Enum.TryParse<FieldDateTimeStyle>(
                        jObject.GetProperty(nameof(DateField.DateStyle)).GetString(),
                        out var dateStyle
                    )
                        ? dateStyle
                        : FieldDateTimeStyle.Unspecified,
                    Enum.TryParse<FieldDateTimeStyle>(
                        jObject.GetProperty(nameof(DateField.TimeStyle)).GetString(),
                        out var timeStyle
                    )
                        ? dateStyle
                        : FieldDateTimeStyle.Unspecified,
                    DateTime.TryParse(
                        jObject.GetProperty(nameof(StandardField.Value)).GetString(),
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out var value
                    )
                        ? value
                        : default
                );
        }
        // [nameof(Field.FieldType)];
        //         switch (type)
        //         {
        //             case string s when s.Equals(FieldType.Text):
        //                 fields.Add(
        //                     new StandardField(
        //                         item[nameof(StandardField.Key)] ?? string.Empty,
        //                         item[nameof(StandardField.Label)] ?? string.Empty,
        //                         item[nameof(StandardField.Value)] ?? string.Empty,
        //                         item[nameof(StandardField.AttributedValue)] ?? string.Empty,
        //                         Enum.TryParse<DataDetectorTypes>(
        //                             item[nameof(DataDetectorTypes)],
        //                             out var dataDetectorTypes
        //                         )
        //                             ? dataDetectorTypes
        //                             : DataDetectorTypes.PKDataDetectorAll
        //                     )
        //                 );
        //                 break;
        //             case string s when s.Equals(nameof(FieldType.Date)):
        //                 fields.Add(
        //                     new DateField(
        //                         item[nameof(StandardField.Key)],
        //                         item[nameof(StandardField.Label)],
        //                         Enum.TryParse<FieldDateTimeStyle>(
        //                             item[nameof(DateField.DateStyle)],
        //                             out var dateStyle
        //                         )
        //                             ? dateStyle
        //                             : FieldDateTimeStyle.Unspecified,
        //                         Enum.TryParse<FieldDateTimeStyle>(
        //                             item[nameof(DateField.TimeStyle)],
        //                             out var timeStyle
        //                         )
        //                             ? dateStyle
        //                             : FieldDateTimeStyle.Unspecified,
        //                         DateTime.TryParse(
        //                             item[nameof(StandardField.Value)],
        //                             System.Globalization.CultureInfo.InvariantCulture,
        //                             System.Globalization.DateTimeStyles.None,
        //                             out var value
        //                         )
        //                             ? value
        //                             : default
        //                     )
        //                 );
        //                 break;
        //         }
        return default;
    }

    public override void Write(
        Utf8JsonWriter writer,
        Passbook.Generator.Fields.Field value,
        JsonSerializerOptions options
    )
    {
        writer.WriteStartObject();
        writer.WriteString(nameof(Field.FieldType), value.FieldType.ToString());
        switch (value)
        {
            case StandardField standardField:
                writer.WriteString(nameof(StandardField.Key), standardField.Key);
                writer.WriteString(nameof(StandardField.Label), standardField.Label);
                writer.WriteString(nameof(StandardField.Value), standardField.Value);
                writer.WriteString(
                    nameof(StandardField.AttributedValue),
                    standardField.AttributedValue
                );
                writer.WriteString(
                    nameof(DataDetectorTypes),
                    standardField.DataDetectorTypes.ToString()
                );
                break;
            case DateField dateField:
                writer.WriteString(nameof(StandardField.Key), dateField.Key);
                writer.WriteString(nameof(StandardField.Label), dateField.Label);
                writer.WriteString(nameof(DateField.DateStyle), dateField.DateStyle.ToString());
                writer.WriteString(nameof(DateField.TimeStyle), dateField.TimeStyle.ToString());
                writer.WriteString(nameof(StandardField.Value), dateField.Value.ToString());
                break;
        }
        writer.WriteEndObject();
    }
}
