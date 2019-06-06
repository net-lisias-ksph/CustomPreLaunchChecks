using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomPreLaunchChecks
{
    public class API
    {
        public static void RegisterCheck(Func<string, PreFlightTests.IPreFlightTest> check)
        {
            if (!CustomPreLaunchChecks.allChecks.Contains(check))
            {
                CustomPreLaunchChecks.allChecks.Add(check);
            }
        }
    }
}
