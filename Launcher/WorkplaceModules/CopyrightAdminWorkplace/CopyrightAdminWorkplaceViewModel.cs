using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace Launcher.WorkplaceModules.CopyrightAdminWorkplace
{
    public class CopyrightAdminWorkplaceViewModel : ViewModelBase
    {

        #region * * * PROPERTIES * * *

        private LM_CopyrightAdminWorkplace _loc = new LM_CopyrightAdminWorkplace();
        public LM_CopyrightAdminWorkplace LOC
        {
            get => _loc;
            set
            {
                _loc = value;
                OnPropertyChanged(() => LOC);
            }
        }

        #endregion

    }
}
