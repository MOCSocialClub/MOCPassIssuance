/*
 * Settings.cs
 *     Created: 2024-10-17T19:31:51-04:00
 *    Modified: 2024-10-17T19:31:51-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Options;

public record class MOCSocialClubPassbookOptions
{
    public string TeamId { get; set; } = string.Empty;
    public string PassTypeIdentifier { get; set; } = string.Empty;
    public string OrganizationName { get; set; } = string.Empty;

    public string LogoText { get; set; } = string.Empty;
    public string BackgroundColor { get; set; } = string.Empty;
    public string LabelColor { get; set; } = string.Empty;
    public string ForegroundColor { get; set; } = string.Empty;

    public PassStyle PassStyle { get; set; } = PassStyle.Generic;

    public Dictionary<PassbookImage, IPassbookImageFile> Images { get; set; } = [];

    public List<Field> PrimaryFields { get; private set; } = [];
    public List<Field> SecondaryFields { get; private set; } = [];
    public List<Field> HeaderFields { get; private set; } = [];
    public List<Field> BackFields { get; private set; } = [];
    public List<Field> AuxiliaryFields { get; private set; } = [];

    public PassStyle Style { get; set; }

    public Certificate SigningCertificate { get; set; }

    public Certificate CaCertificate { get; set; }

    public virtual async Task<PassGeneratorRequest> ToPassGeneratorRequestAsync()
    {
        var request = new PassGeneratorRequest()
        {
            PassTypeIdentifier = PassTypeIdentifier,
            TeamIdentifier = TeamId,
            Description = "MOC Social Club Membership Card",
            OrganizationName = OrganizationName,
            LogoText = LogoText,
            BackgroundColor = BackgroundColor,
            LabelColor = LabelColor,
            ForegroundColor = ForegroundColor,
            Style = Style,
            Images = await Task.WhenAll(
                    Images.Select(async kvp => new
                    {
                        kvp.Key,
                        Value = await kvp.Value.AsBytesAsync(),
                    })
                )
                .ContinueWith(t => t.Result.ToDictionary(x => x.Key, x => x.Value)),
        };

        request.PrimaryFields.AddRange(PrimaryFields);
        request.SecondaryFields.AddRange(SecondaryFields);
        request.HeaderFields.AddRange(HeaderFields);
        request.BackFields.AddRange(BackFields);
        request.AuxiliaryFields.AddRange(AuxiliaryFields);
        request.AppleWWDRCACertificate = CaCertificate.AsX509Certificate();
        request.PassbookCertificate = SigningCertificate.AsX509Certificate();
        return request;
    }
}

public interface IPassbookImageFile
{
    public PassbookImage Type { get; set; }
    public string Filename { get; }
    public string Base64 { get; }
    public string Path { get; }

    public Task<byte[]> AsBytesAsync();
}

public record class PhysicalPassbookImageFile(string Path) : IPassbookImageFile
{
    public virtual PassbookImage Type { get; set; } = PassbookImage.Icon;

    public string Filename => System.IO.Path.GetFileName(Path);

    public string Base64 => System.Convert.ToBase64String(AsBytesAsync().Result);

    public Task<byte[]> AsBytesAsync() =>
        File.Exists(Filename)
            ? File.ReadAllBytesAsync(Filename)
            : throw new FileNotFoundException($"Couldn't find a file at path {Path}");
}

public record class VirtualPassbookImageFile(string Filename, string Base64) : IPassbookImageFile
{
    public virtual PassbookImage Type { get; set; } = PassbookImage.Icon;

    // public string Filename { get; set; }

    public string Path => Filename;

    // public string Base64 { get; set; }

    public Task<byte[]> AsBytesAsync() => Task.FromResult(System.Convert.FromBase64String(Base64));
}

public readonly record struct Certificate
{
    public string? Base64 { get; }
    public string? Password { get; }
    public string? Filename { get; }

    public byte[] AsBytes() =>
        Base64.IsPresent() ? FromBase64String(Base64)
        : Filename!.IsPresent() && File.Exists(Filename) ? File.ReadAllBytes(Filename)
        : [];

    public X509Certificate2 AsX509Certificate() =>
        !Password!.IsPresent() ? new(AsBytes()) : new(AsBytes(), Password);
}
