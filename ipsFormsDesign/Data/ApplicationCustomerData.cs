using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
using ipsFormsDesign.Patterns.Notifier;

namespace ipsFormsDesign.Data
{
    public class ApplicationCustomerData: INotifier
    {
        private static ApplicationCustomerData _this;
        private readonly List<ISubscriber> _subscribers;

        private ApplicationCustomerData()
        {
            _subscribers = new List<ISubscriber>();
        }

        public static ApplicationCustomerData GetInstance()
        {
            if (_this == null)
                _this = new ApplicationCustomerData();

            return _this;
        }

        private Customer _customer;
        public Customer CurrentCustomer
        {
            get => _customer;
            set
            {
                _customer = value;
                NotifySubscribers();
            }
        }

        public string CustomerName { get; set; }

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void NotifySubscribers()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.UpdateOnNotified();
            }
        }
    }
}
