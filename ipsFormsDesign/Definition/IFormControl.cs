using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipsFormsDesign.Definition
{
    public interface IFormControl
    {
        void FieldValueChanged( Control element, object value );
    }
}
