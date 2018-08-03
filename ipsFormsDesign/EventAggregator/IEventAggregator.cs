using System;

namespace ipsFormsDesign.EventAggregator
{
    public interface IEventAggregator
    {
        void PublishEvent<TEventType>(TEventType eventToPublish);

        void SubsribeEvent(Object subscriber);
    }
}
