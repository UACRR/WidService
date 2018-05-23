using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public interface IConsumerMainView
    {
        int custID { get; }
        int innokpo { get; }
        int name { get; }
        int countAgree { get; }
        int undistribamount { get; }
    }
    public interface IConsumerModel : IModel
    {
        IList<IConsumerMainView> getMainView();
    }
}
