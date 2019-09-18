using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace InitModulesEventsAndJobs.Demo
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class MyInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var events = ServiceLocator.Current.GetInstance<IContentEvents>();

            events.MovingContent += BeforeMovingContent;

        }

        private void BeforeMovingContent(object sender, EPiServer.ContentEventArgs e)
        {
            if (e.Content.Name.StartsWith("Fredrik"))
            {
                e.CancelAction = true;
                e.CancelReason = "You can not move Fredrik around!";
            }
            
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}