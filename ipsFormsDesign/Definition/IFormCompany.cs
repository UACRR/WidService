using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipsFormsDesign.Definition
{
    public interface IFormCompany : ICustCompany
    {
        // Подія збереження
        event Func<bool> Save;
        void SetData(Customer data);
        void getData(Customer data);

        void SetDictionary(AnketaDictionaties dic);

    }
}
