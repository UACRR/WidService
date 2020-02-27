using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace Launcher.General.Model
{
    public class LauncherPermits : ViewModelBase
    {
        private bool _rightsAdmin;
        public bool RightsAdmin
        {
            get => _rightsAdmin;
            set
            {
                _rightsAdmin = value;
                OnPropertyChanged(() => RightsAdmin);
            }
        }
 
        public bool RoyaltyAdmin { get; set; }
        public bool SRightsWp { get; set; }
        public bool BRightsWp { get; set; }
        public bool PRAdmin { get; set; }
        public bool Violation { get; set; }
        public bool Directory { get; set; }

        private bool _userAdmin;
        public bool UserAdmin
        {
            get => _userAdmin;
            set
            {
                _userAdmin = value;
                OnPropertyChanged(() => UserAdmin);
            }
        }
    }
}
