using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.ViewModels
{
    public class PublisherSubpublisherListViewModel : ViewModelBase
    {


        #region * * * COMMANDS * * *

        /// <summary>
        /// Завантаження
        /// </summary>
        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {

        }

        #endregion
    }
}
