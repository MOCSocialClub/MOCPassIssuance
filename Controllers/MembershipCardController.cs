/*
 * MembershipCardController.cs
 *     Created: 2024-10-17T19:22:53-04:00
 *    Modified: 2024-10-17T19:22:53-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Controllers;

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Routing;
using Models;
using Options;
using static System.IO.File;

[ApiController]
[Route("api/passes")]
public class MembershipCardController(IOptions<MOCSocialClubPassbookOptions>? settings)
    : ControllerBase
{
    private readonly MOCSocialClubPassbookOptions _settings =
        settings?.Value ?? throw new ArgumentNullException(nameof(settings));

    [HttpPost("/api/passes/mares/my")]
    [Produces(Constants.PkPassMimeType)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(typeof(MOCMembershipCardRequest), Application.Json.DisplayName)]
    public async Task<IActionResult> GetMyMareMembershipCard(
        [FromBody] MOCMembershipCardRequest request
    )
    {
        PassGeneratorRequest passGeneratorRequest = new PassGeneratorRequest
        {
            PassTypeIdentifier = _settings.PassTypeIdentifier,
            TeamIdentifier = _settings.TeamId,
            SerialNumber = Counter.Next.ToString(),
            Description = "MOC Social Club Mare Membership Card",
            OrganizationName = _settings.OrganizationName,
            LogoText = _settings.LogoText,
            BackgroundColor = _settings.BackgroundColor,
            LabelColor = _settings.LabelColor,
            ForegroundColor = _settings.ForegroundColor,
            Style = _settings.PassStyle,
        };

        passGeneratorRequest.UserInfo[Constants.Fields.FirstName.Key] = "David";
        passGeneratorRequest.UserInfo[Constants.Fields.LastName.Key] = "Gerard";
        passGeneratorRequest.UserInfo[Constants.Fields.Name.Key] = "David Gerard";
        passGeneratorRequest.Images.Add(
            PassbookImage.Logo,
            await ReadAllBytesAsync("./images/moc.png")
        );
        passGeneratorRequest.Images.Add(
            PassbookImage.Thumbnail,
            await ReadAllBytesAsync("./images/thumbnail.png")
        );

        passGeneratorRequest.PrimaryFields.Add(
            new StandardField(
                Constants.Fields.Name.Key,
                Constants.Fields.Name.Label,
                "David Gerard"
            )
        );
        passGeneratorRequest.SecondaryFields.Add(
            new StandardField(
                Constants.Fields.MarketRole.Key,
                Constants.Fields.MarketRole.Label,
                "\"Mare\""
            )
        );

        passGeneratorRequest.ExpirationDate = DateTimeOffset.Now.AddYears(1);
        passGeneratorRequest.SharingProhibited = true;
        passGeneratorRequest.PassbookCertificate = _settings.SigningCertificate.AsX509Certificate();

        passGeneratorRequest.Images = _settings.Images.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.AsBytesAsync().Result
        );
        passGeneratorRequest.Style = PassStyle.Generic;

        var generator = new PassGenerator();

        passGeneratorRequest.AppleWWDRCACertificate = _settings.CaCertificate.AsX509Certificate();

        var pass = generator.Generate(passGeneratorRequest);
        return File(
            pass,
            Constants.PkPassMimeType,
            request.OutputFilename ?? Constants.DefaultFilename
        );
    }
}
