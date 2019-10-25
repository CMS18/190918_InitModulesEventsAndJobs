using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using EPiServer.PlugIn;

namespace InitModulesEventsAndJobs.Demo
{
    [ScheduledPlugIn(DisplayName = "Simple Job")]
    public static class SimpleJob
    {
        public static string Execute()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            // Do some work...

            return "OK - Did work. " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}