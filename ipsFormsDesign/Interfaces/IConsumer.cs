using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;


namespace ipsFormsDesign.Interfaces
{
    public interface IConsumerPresenter
    {
        Control view { get; }
        void SetFilter(ConsumerFilterEnum what);
    }
    
    public interface IConsumerForm
    {
        event Func<bool> Save; 
        Func<IList<ConsumerMainView>> getMainViewData { get; set; }
        Func<int, Customer> NewCustomer { get; set; }
        Func<int, Customer> GetCustomer { get; set; }
        Func<Customer, bool> SaveCustomer { get; set; }
        Func<string, IList<AutoCompleteData>> GetAutoCompList { get; set; }
        void EndPresenterLink();

        void SetData(ICustomer data);
        void GetData(ICustomer data);

        void SetDictionary(AnketaDictionaties dic);
    }

}
