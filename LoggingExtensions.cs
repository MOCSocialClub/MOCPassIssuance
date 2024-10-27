/*
 * LoggingExtensison.cs
 *     Created: 2024-10-18T14:26:13-04:00
 *    Modified: 2024-10-18T14:26:13-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService;

public static partial class LoggingExtensions
{
    [LoggerMessage(
        LogLevel.Warning,
        "Image path not provided and no base64 contents were found either."
    )]
    public static partial void ImagePathNotProvided(this ILogger logger);

    [LoggerMessage(LogLevel.Information, "Adding passbook image file at path: {Path}")]
    public static partial void AddingPassbookImageFile(this ILogger logger, string path);

    [LoggerMessage(LogLevel.Trace, "Entering {Method}")]
    public static partial void EnteringMethod(
        this ILogger logger,
        [CallerMemberName] string method = ""
    );
}
