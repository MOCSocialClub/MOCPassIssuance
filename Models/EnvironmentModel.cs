/*
 * EnvironmentModel.cs
 *     Created: 2024-10-18T22:00:51-04:00
 *    Modified: 2024-10-18T22:00:51-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Models;

public class EnvironmentModel
{
    public int AccountId { get; set; }

    public string ClientId { get; set; } =
        "set client id from settings / security / authorized applications";

    public string ClientSecret { get; set; } =
        "set client secret from settings / security / authorized applications";

    public string OAuthServiceUrl { get; set; } = "https://oauth.wildapricot.org";

    public string OAuthTokenEndpoint
    {
        get { return this.OAuthServiceUrl + "/auth/token"; }
    }

    public string PublicApiUrl { get; set; } = "https://api.wildapricot.org";

    public string AssociationWebSiteUrl { get; set; } = "https://yourassociation.wildapricot.org";

    public string AuthFormUrl
    {
        get { return this.AssociationWebSiteUrl + "/sys/login/OAuthLogin"; }
    }
    public string LogoutUrl
    {
        get { return this.AssociationWebSiteUrl + "/sys/login/logout"; }
    }
    public string LogoutNonceUrl
    {
        get { return this.AssociationWebSiteUrl + "/sys/login/LogoutNonce"; }
    }

    public string Scope { get; set; } = "auto";
}
