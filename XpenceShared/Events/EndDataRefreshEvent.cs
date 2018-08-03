using Prism.Events;

namespace XpenceShared.Events
{
    /// <summary>
    /// Generated when the data refresh is finished. Main purpose to hide the Waiting icon
    /// </summary>
    public class EndDataRefreshEvent: PubSubEvent<string>
    {
        
    }
}