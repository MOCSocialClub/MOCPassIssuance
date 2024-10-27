/*
 * FieldsConfigurator.cs
 *     Created: 2024-10-18T02:20:40-04:00
 *    Modified: 2024-10-18T02:20:40-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Options;

public class FieldsConfigurator(IConfiguration configuration, ILogger<FieldsConfigurator> logger)
    : IConfigureOptions<MOCSocialClubPassbookOptions>,
        ILog
{
    public ILogger Logger => logger;

    public virtual void Configure(MOCSocialClubPassbookOptions options)
    {
        Configure(
            configuration.GetSection(nameof(MOCSocialClubPassbookOptions.PrimaryFields)),
            options.PrimaryFields
        );
        Configure(
            configuration.GetSection(nameof(MOCSocialClubPassbookOptions.SecondaryFields)),
            options.SecondaryFields
        );
        Configure(
            configuration.GetSection(nameof(MOCSocialClubPassbookOptions.AuxiliaryFields)),
            options.AuxiliaryFields
        );
        Configure(
            configuration.GetSection(nameof(MOCSocialClubPassbookOptions.BackFields)),
            options.BackFields
        );
        Configure(
            configuration.GetSection(nameof(MOCSocialClubPassbookOptions.HeaderFields)),
            options.HeaderFields
        );
    }

    public virtual void Configure(IConfigurationSection configuration, List<Field> fields)
    {
        foreach (var item in configuration.GetChildren())
        {
            var type = item[nameof(Field.FieldType)];
            switch (type)
            {
                case string s when s.Equals(FieldType.Text):
                    fields.Add(
                        new StandardField(
                            item[nameof(StandardField.Key)],
                            item[nameof(StandardField.Label)],
                            item[nameof(StandardField.Value)],
                            item[nameof(StandardField.AttributedValue)],
                            Enum.TryParse<DataDetectorTypes>(
                                item[nameof(DataDetectorTypes)],
                                out var dataDetectorTypes
                            )
                                ? dataDetectorTypes
                                : DataDetectorTypes.PKDataDetectorAll
                        )
                    );
                    break;
                case string s when s.Equals(nameof(FieldType.Date)):
                    fields.Add(
                        new DateField(
                            item[nameof(StandardField.Key)],
                            item[nameof(StandardField.Label)],
                            Enum.TryParse<FieldDateTimeStyle>(
                                item[nameof(DateField.DateStyle)],
                                out var dateStyle
                            )
                                ? dateStyle
                                : FieldDateTimeStyle.Unspecified,
                            Enum.TryParse<FieldDateTimeStyle>(
                                item[nameof(DateField.TimeStyle)],
                                out var timeStyle
                            )
                                ? dateStyle
                                : FieldDateTimeStyle.Unspecified,
                            DateTime.TryParse(
                                item[nameof(StandardField.Value)],
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None,
                                out var value
                            )
                                ? value
                                : default
                        )
                    );
                    break;
            }
        }
    }
}
