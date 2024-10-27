/*
 * Counter.cs
 *     Created: 2024-10-18T01:39:30-04:00
 *    Modified: 2024-10-18T01:39:30-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 Dr. David Gerard, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService;

public class Counter
{
    private static readonly object _lockRoot = new object();

    public static int Next
    {
        get
        {
            lock (_lockRoot)
            {
                if (!File.Exists(Constants.DotCounter))
                {
                    File.WriteAllText(Constants.DotCounter, "0");
                }
                var currentNumber = int.TryParse(File.ReadAllText(Constants.DotCounter), out var i)
                    ? i
                    : 0;
                File.WriteAllText(Constants.DotCounter, currentNumber++.ToString());
                return currentNumber;
            }
        }
    }
}
