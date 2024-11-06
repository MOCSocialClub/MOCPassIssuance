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
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Models;
using Options;
using static System.IO.File;

[ApiController]
[Route("api/passes")]
public class MembershipCardController(
    IOptions<MOCSocialClubPassbookOptions>? settings,
    HttpClient httpClient
) : ControllerBase
{
    private readonly MOCSocialClubPassbookOptions _settings =
        settings?.Value ?? throw new ArgumentNullException(nameof(settings));

    [HttpPost]
    [Produces(Constants.PkPassMimeType)]
    [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK, Constants.PkPassMimeType)]
    [Consumes(typeof(Models.Json.MocMembershipCardRequest), Constants.PkPassRequestMimeType)]
    public async Task<IActionResult> GetMyMareMembershipCard(
        Models.Json.MocMembershipCardRequest request
    )
    {
        PassGeneratorRequest passGeneratorRequest = await _settings.ToPassGeneratorRequestAsync();
        passGeneratorRequest.UserInfo[Constants.Fields.MemberId.Key] = request.MemberId.ToString();
        passGeneratorRequest.UserInfo[Constants.Fields.FirstName.Key] =
            request.FirstName ?? "[no first name]";
        passGeneratorRequest.UserInfo[Constants.Fields.LastName.Key] =
            request.LastName ?? "[no last name]";
        passGeneratorRequest.UserInfo[Constants.Fields.Name.Key] =
            request.DisplayName ?? "[no name]";
        passGeneratorRequest.UserInfo[Constants.Fields.Email.Key] =
            request.Email ?? "[no email address]";
        passGeneratorRequest.UserInfo[Constants.Fields.PhoneNumber.Key] =
            request.Phone.ToString() ?? "[no phone number]";
        passGeneratorRequest.SecondaryFields.Add(
            new StandardField(
                Constants.Fields.MarketRole.Key,
                Constants.Fields.MarketRole.Label,
                request.MarketPosition.Join(", ")
            )
        );

        passGeneratorRequest.PrimaryFields.Add(
            new StandardField(
                Constants.Fields.Name.Key,
                Constants.Fields.Name.Label,
                passGeneratorRequest.UserInfo[Constants.Fields.Name.Key]?.ToString()!
            )
        );

        passGeneratorRequest.SecondaryFields.Add(
            new StandardField(
                Constants.Fields.MemberId.Key,
                Constants.Fields.MemberId.Label,
                request.MemberId.ToString()
            )
        );

        passGeneratorRequest.BackFields.Add(
            new DateField(
                Constants.Fields.ExpirationDate.Key,
                Constants.Fields.ExpirationDate.Label,
                FieldDateTimeStyle.PKDateStyleShort,
                FieldDateTimeStyle.PKDateStyleNone,
                request.RenewalDue.DateTime
            )
        );
        passGeneratorRequest.BackFields.Add(
            new StandardField(
                Constants.Fields.Email.Key,
                Constants.Fields.Email.Label,
                passGeneratorRequest.UserInfo[Constants.Fields.Email.Key]?.ToString()!
            )
        );
        passGeneratorRequest.BackFields.Add(
            new StandardField(
                Constants.Fields.FirstName.Key,
                Constants.Fields.FirstName.Label,
                passGeneratorRequest.UserInfo[Constants.Fields.FirstName.Key]?.ToString()!
            )
        );
        passGeneratorRequest.BackFields.Add(
            new StandardField(
                Constants.Fields.LastName.Key,
                Constants.Fields.LastName.Label,
                passGeneratorRequest.UserInfo[Constants.Fields.LastName.Key]?.ToString()!
            )
        );
        passGeneratorRequest.ExpirationDate = request.RenewalDue.DateTime;
        passGeneratorRequest.SharingProhibited = false;
        passGeneratorRequest.ExpirationDate = request.RenewalDue;
        // passGeneratorRequest.SharingProhibited = true;
        // passGeneratorRequest.PassbookCertificate = _settings.SigningCertificate.AsX509Certificate();

        passGeneratorRequest.Images[PassbookImage.Thumbnail] = await request.Avatar.GetBytesAsync(
            httpClient
        );
        // passGeneratorRequest.Images[PassbookImage.Strip] = await request.
        foreach (var image in _settings.Images)
        {
            passGeneratorRequest.Images[image.Key] = await image.Value.AsBytesAsync();
        }
        passGeneratorRequest.Style = PassStyle.Generic;

        var generator = new PassGenerator();

        passGeneratorRequest.AppleWWDRCACertificate = _settings.CaCertificate.AsX509Certificate();
        passGeneratorRequest.PassbookCertificate = _settings.SigningCertificate.AsX509Certificate();

        var pass = generator.Generate(passGeneratorRequest);
        return File(
            pass,
            Constants.PkPassMimeType,
            request.OutputFilename ?? Constants.DefaultFilename
        );
    }
}
