using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ActivityType : IActivityType
    {
        public ActivityType()
        {
            ActivityTypeTr = new ObservableListSource<ActivityTypeTr>();
            AnketaCompany = new ObservableListSource<AnketaCompany>();
            ReqCustomer = new ObservableListSource<ReqCustomer>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<ActivityTypeTr> ActivityTypeTr { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public ObservableListSource<ReqCustomer> ReqCustomer { get; set; }
    }
}

