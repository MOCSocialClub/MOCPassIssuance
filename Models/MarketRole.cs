/*
 * MarketRole.cs
 *     Created: 2024-10-17T19:33:47-04:00
 *    Modified: 2024-10-17T19:33:47-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Enums;

public enum MarketRole
{
    [Display(Name = "None selected", ShortName = "none")]
    None = 0,

    [Display(Name = "\"Mare\"", ShortName = "mare")]
    Mare = 1,

    [Display(Name = "\"Stallion\"", ShortName = "stallion")]
    Stallion = 2
}
