using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipsFormsDesign.Definition
{
    interface IFormCompany : ICustCompany
    {
        // Подія при зміні значення поля форми
        event EventHandler FieldsValueChanged ;
    }
}
