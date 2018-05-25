using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public class RightHolderMainView
    {
        public string innerCode { get; set;  }
        public string interCode { get; set; }
        public string name { get; set; }
        public DateTime registrDate { get; set; }
        public int  cntObj { get; set; }
        public int yearProfit { get; set; }
    }

    interface IRightHolderService : IModel
    {
        IList<ConsumerMainView> getMainView();
    }
}
