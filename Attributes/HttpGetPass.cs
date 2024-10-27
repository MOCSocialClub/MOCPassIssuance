/*
 * HttpGetPass.cs
 *     Created: 2024-10-18T14:45:21-04:00
 *    Modified: 2024-10-18T14:45:22-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Mvc.Routing;

namespace MOCSocialClubPassWebService;

public class HttpGetPass([@StringSyntax("Route")] string? template = default)
    : HttpMethodAttribute(Methods, template)
{
    public static readonly string[] Methods = [Constants.HttpMethods.GetPass];
}
