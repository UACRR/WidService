using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace ipsFormsDesign.Interfaces
{

    public interface IConsumerForm
    {
        event Func<bool> Save; 
        Func<IList<ConsumerMainView>> getMainViewData { get; set; }
        Func<int, Customer> NewCustomer { get; set; }
        Func<int, Customer> GetCustomer { get; set; }
        Func<Customer, bool> SaveCustomer { get; set; }
        void EndPresenterLink();

        void SetData(ICustomer data);
        void GetData(ICustomer data);

        void SetDictionary(AnketaDictionaties dic);
    }

}
