/*
 * MOCMembershipCardRequest.cs
 *     Created: 2024-10-17T18:49:31-04:00
 *    Modified: 2024-10-17T18:49:31-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Models;

using Enums;

public class MOCMembershipCardRequest()
{
    private string? _serialNumber;

    public virtual string SerialNumber
    {
        get => _serialNumber ??= Counter.Next.ToString();
        set => _serialNumber = value;
    }

    public string OutputFilename { get; set; } = Constants.DefaultFilename;
    public MarketRole MarketRole { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AvatarUrl { get; set; }
}
