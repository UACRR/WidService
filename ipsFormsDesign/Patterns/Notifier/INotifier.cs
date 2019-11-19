namespace ipsFormsDesign.Patterns.Notifier
{
    public interface INotifier
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void NotifySubscribers();
    }
}