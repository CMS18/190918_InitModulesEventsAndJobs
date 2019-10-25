using System;
using System.Threading;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;

namespace InitModulesEventsAndJobs.Demo
{
    [ScheduledPlugIn(DisplayName = "MoreAdvancedScheduledJob")]
    public class MoreAdvancedScheduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        public MoreAdvancedScheduledJob()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

            //Add implementation

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                OnStatusChanged(String.Format("Working on {0}", i));
                if (_stopSignaled) break;
            }


            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Done";
        }
    }
}
