using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipsFormsDesign.Definition
{
    public interface IForm
    {
        void FieldStateChanged(Control element, int state);
        void FormStateChanged(int formState);
    }
}
