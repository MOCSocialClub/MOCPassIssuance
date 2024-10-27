/*
 * OptionsConfigurator.cs
 *     Created: 2024-10-19T00:27:45-04:00
 *    Modified: 2024-10-19T00:27:45-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Options;

public class OptionsConfigurator(IConfiguration configuration)
    : IConfigureOptions<MOCSocialClubPassbookOptions>
{
    public void Configure(MOCSocialClubPassbookOptions options)
    {
        options.TeamId = configuration[nameof(options.TeamId)]!;
        options.PassTypeIdentifier = configuration[nameof(options.PassTypeIdentifier)]!;
        options.OrganizationName = configuration[nameof(options.OrganizationName)]!;
        options.LogoText = configuration[nameof(options.LogoText)]!;
        options.BackgroundColor = configuration[nameof(options.BackgroundColor)]!;
        options.LabelColor = configuration[nameof(options.LabelColor)]!;
        options.ForegroundColor = configuration[nameof(options.ForegroundColor)]!;
        options.Style = Enum.TryParse<PassStyle>(
            configuration[nameof(options.Style)]!,
            out var style
        )
            ? style
            : PassStyle.Generic;
    }
}
