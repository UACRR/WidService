using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public class ConsumerMainView
    {
        public int custId { get; set; }
        public string innokpo { get; set; }
        public string name { get; set;  }
        public int countAgree { get; set; }
        public decimal undistribamount { get; set; }
    }

    public interface IConsumerService : IModel
    {
        IList<ConsumerMainView> getMainView();
        IList<AutoCompleteData> getAutoCompleteList(string filter);
    }
}
