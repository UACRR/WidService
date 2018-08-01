
namespace ipsFormsDesign.EventAggregator
{
    public interface ISubscriber<TEventType>
    {
        void HandleEvent(TEventType e);
    }
}
