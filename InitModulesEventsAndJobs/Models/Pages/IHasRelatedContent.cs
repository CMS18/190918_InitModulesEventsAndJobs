using EPiServer.Core;

namespace InitModulesEventsAndJobs.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
