using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public class RightholderMainView
    {
        public int CustId { get; set; }
        public int Status { get; set; }
        public string InnerCode { get; set;  }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public DateTime RegistrDate { get; set; }
        public int  CntObj { get; set; }
        public int YearProfit { get; set; }
    }

    public interface IRightHolderService : IModel
    {
        IList<RightholderMainView> GetMainView();
        IList<RightholderMainView> GetMainViewByStatus(RightholderStatusType rightholderStatus);
    }
}
