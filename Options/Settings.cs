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
    public string Base64 { get; }
    public string? Password { get; }

    public byte[] AsBytes() => Base64.IsPresent() ? FromBase64String(Base64) : [];

    public X509Certificate2 AsX509Certificate() =>
        string.IsNullOrEmpty(Password) ? new(AsBytes()) : new(AsBytes(), Password);
}
