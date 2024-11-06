/*
 * PassbookImageFileConfigurator.cs
 *     Created: 2024-10-18T09:11:28-04:00
 *    Modified: 2024-10-18T09:11:28-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Options;

public class PassbookImageFileConfigurator(
    IConfiguration configuration,
    ILogger<PassbookImageFileConfigurator> logger
) : IConfigureOptions<MOCSocialClubPassbookOptions>, ILog
{
    public ILogger Logger => logger;

    public virtual void Configure(MOCSocialClubPassbookOptions options)
    {
        Configure(
            options.Images,
            configuration.GetSection(nameof(MOCSocialClubPassbookOptions.Images))
        );
    }

    public virtual void Configure(
        Dictionary<PassbookImage, IPassbookImageFile> images,
        IConfiguration configuration
    )
    {
        foreach (var item in configuration.GetChildren())
        {
            var base64 = item[nameof(IPassbookImageFile.Base64)];
            var path = item[nameof(IPassbookImageFile.Path)];
            var type = Enum.TryParse<PassbookImage>(
                item[nameof(IPassbookImageFile.Type)],
                out var t
            )
                ? t
                : PassbookImage.Icon;
            if (!base64!.IsPresent() && !path!.IsPresent())
            {
                Logger.ImagePathNotProvided();
            }
            else if (path!.IsPresent())
            {
                Logger.AddingPassbookImageFile(
                    item[nameof(IPassbookImageFile.Path)] ?? string.Empty
                );
                images.Add(
                    type,
                    new PhysicalPassbookImageFile(
                        item[nameof(IPassbookImageFile.Path)] ?? string.Empty
                    )
                );
            }
            else
            {
                images.Add(
                    type,
                    new VirtualPassbookImageFile(
                        Path.GetFileName(
                            item[nameof(IPassbookImageFile.Filename)]
#pragma warning disable S3928, CA2208
                                ?? throw new ArgumentException(
                                    "The passbook filename is required.",
                                    $"{nameof(IPassbookImageFile)}.{nameof(IPassbookImageFile.Filename)}"
                                )
                        ),
                        base64
                            ?? throw new ArgumentException(
                                "The passbook image base64 data is required.",
                                nameof(base64)
                            )
#pragma warning restore S3928, CA2208
                    )
                );
            }
        }
    }
}
