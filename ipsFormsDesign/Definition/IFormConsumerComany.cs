using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Definition
{
    public interface IFormConsumerComany : IConsumerCompany
    {
        // Подія збереження
        void SetData(Customer data);
        void getData(Customer data);

    }
}
