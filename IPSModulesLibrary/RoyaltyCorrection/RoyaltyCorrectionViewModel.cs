using System.Windows.Input;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IPSModulesLibrary.RoyaltyCorrection
{
    public class RoyaltyCorrectionViewModel : IPSViewModel<LM_RoyaltyCorrection>
    {
        #region * * * PROPERTIES * * *


        #endregion

        #region * * * METHODS * * *


        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {

        }


        #endregion
    }
}
