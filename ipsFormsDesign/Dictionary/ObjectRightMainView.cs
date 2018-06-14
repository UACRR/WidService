using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectRightMainView
    {
        public int ObjId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string GenreName { get; set; }
        public double Duration { get; set; } // which units?
        public string SpecName { get; set; } // pereklad, obrobka - maight be one-to-many relations?
        public double RateTotal { get; set; }
        public string Performer { get; set; }
        public double Profit { get; set; }
        // no need for genre Type
    }

    public class ViewCustomer
    {
        public int custId { get; set; }
        public int custType { get; set; }
        public string name { get; set; }
        public int isClient { get; set; }
        public int isRHolder { get; set; }
        public int isPartner { get; set; }
    }

    public class ContainerForObjectRihgt
    {
        public ObjectRight objectRight { get; set; }
        public IList<ViewCustomer> rhList { get; set; }
    }
}
