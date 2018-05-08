using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Definition
{
    interface IFormConsumerComany : IConsumerCompany
    {
        // Подія збереження
        event Func<bool> Save;
        void SetData(Customer data);
        void getData(Customer data);

        void SetDictionary(AnketaDictionaties dic);
    }
}
