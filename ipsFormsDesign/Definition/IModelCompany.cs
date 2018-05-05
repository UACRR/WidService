using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsFormsDesign.Definition
{
    interface IModelCompany : ICustCompany
    {
        void FieldChanging(object sender, EventHandler e);
    }
}
