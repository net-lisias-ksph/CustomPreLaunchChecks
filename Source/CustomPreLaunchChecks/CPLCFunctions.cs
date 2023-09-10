using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomPreLaunchChecks;

namespace CustomPreLaunchChecks
{
    internal class CPLCFunctions
    {
        public PreFlightCheck NewPreflightCheck(string launchSiteName)
        {
            //Log.Normal("using injected call");

            PreFlightCheck check = (PreFlightCheck)CustomPreLaunchChecks.preFlightCheckDetour.CallOriginal(EditorLogic.fetch, new object[] { launchSiteName });
            // Spawn the launchSite before we use it


            foreach (var lsCheck in CustomPreLaunchChecks.allChecks)
            {
                check.AddTest(lsCheck.Invoke(launchSiteName));
            }
           
            return check;
        }
    }
}
