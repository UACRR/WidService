using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace ipsFormsDesign.Data
{
    public sealed class CurrentClient
    {
        public int CustId { get; set; }
        public int AgrId { get; set; }
        public ObservableListSource<ClnBusinessPlace> ClnBusinessPlaceCollection{ get; set; }
    }
}
