namespace ipsFormsDesign.Patterns.Notifier
{
    public interface ISubscriber
    {
        void UpdateOnNotified(object o);
    }
}