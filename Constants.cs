/*
 * Constants.cs
 *     Created: 2024-10-17T19:37:57-04:00
 *    Modified: 2024-10-17T19:37:57-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService;

public static class Constants
{
    public static class HttpMethods
    {
        public const string GetPass = "GETPASS";
    }

    public const string DotCounter = ".counter";
    public const string PkPassMimeType = "application/vnd.apple.pkpass";
    public const string DefaultFilename = "pass.pkpass";

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
    }
}