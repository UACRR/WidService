using ipsFormsDesign.Interfaces;
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

    }
}
