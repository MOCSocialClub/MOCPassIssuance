/*
 * StringExtensions.cs
 *     Created: 2024-10-17T19:29:56-04:00
 *    Modified: 2024-10-17T19:29:56-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService;

using System.Security;

public static class StringExtensions
{
    public static SecureString ToSecureString(this string s) =>
        s.ToCharArray()
            .Aggregate(
                new SecureString(),
                (ss, ch) =>
                {
                    ss.AppendChar(ch);
                    return ss;
                }
            );
}
