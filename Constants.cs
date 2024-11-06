/*
 * Constants.cs
 *     Created: 2024-10-17T19:37:57-04:00
 *    Modified: 2024-10-17T19:37:57-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

using Org.BouncyCastle.Asn1.Ess;

namespace MOCSocialClubPassWebService;

public static class Constants
{
    public static class HttpMethods
    {
        public const string GetPass = "GETPASS";
    }

    public static class Defaults
    {
        public const string PassTypeIdentifier = "pass.com.mymoc.socialclub";
        public const string TeamId = "[REPLACE_ME]";
        public const string OrganizationName = "MOC Social Club";
        public const string LogoText = "MOC";
        public const string BackgroundColor = "rgb(255, 255, 255)";
        public const string LabelColor = "rgb(0, 0, 0)";
        public const string ForegroundColor = "rgb(0, 0, 0)";
        public const PassStyle PassStyle = Passbook.Generator.PassStyle.Generic;

        public const string UnknownAvatarUrlString = "/images/unknown-avatar.png";

        public static readonly Uri UnknownAvatarUri = new(UnknownAvatarUrlString);
    }

    public const string DotCounter = ".counter";
    public const string PkPassMimeType = "application/vnd.apple.pkpass";
    public const string PkPassRequestMimeType = "application/x-moc-social-club-pass-request+json";
    public const string DefaultFilename = "pass.pkpass";

    public static class Headers
    {
        public const string ClientId = "clientId";
    }

    public static class Fields
    {
        public static class FirstName
        {
            public const string Key = "first_name";
            public const string Label = "First name";
        }

        public static class LastName
        {
            public const string Key = "last_name";
            public const string Label = "Last name";
        }

        public static class Name
        {
            public const string Key = "name";
            public const string Label = "Name";
        }

        public static class PhoneNumber
        {
            public const string Key = "phone_nuumber";
            public const string Label = "Phone number";
        }

        public static class Email
        {
            public const string Key = "email_address";
            public const string Label = "Email address";
        }

        public static class MemberId
        {
            public const string Key = "member_id";
            public const string Label = "Member ID";
        }

        public static class MarketRole
        {
            public const string Key = "market_role";
            public const string Label = "Market role";
        }

        public static class ExpirationDate
        {
            public const string Key = "expiration_date";
            public const string Label = "Valid until";
        }

        public static class AvatarUrl
        {
            public const string Key = "avatar_url";
            public const string Label = "Avatar URL";
        }
    }
}
