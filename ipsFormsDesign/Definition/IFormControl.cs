using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipsFormsDesign.Definition
{
    public interface IFormControl
    {
        void SetForm( IForm form );
        void GetDefaultTreeData();
        void GetFilteredTreeData(string search);
        void GetDefaultDicData();
        void GetFilteredDicData(string search);
    }
}
