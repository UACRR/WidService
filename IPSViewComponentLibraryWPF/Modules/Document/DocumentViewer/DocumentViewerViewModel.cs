using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Document.DocumentViewer
{
    public class DocumentViewerViewModel : ViewModelBase
    {
        public DocumentViewerViewModel() { }

        private string _title = "Перегляд документу";
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(() => Title);
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        private string _documentSource;
        public string DocumentSource
        {
            get => _documentSource;
            set
            {
                _documentSource = value;
                OnPropertyChanged(() => DocumentSource);
            }
        }
    }
}
