using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Extensions
{
    public abstract class IPSViewModel<T> : ViewModelBase where T: class, new()
    {
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

        private T _loc = new T();
        public T LOC
        {
            get => _loc;
            set
            {
                _loc = value;
                OnPropertyChanged(() => LOC);
            }
        }

        protected bool IsLoaded { get; set; }

        protected bool IsDataLoaded { get; set; }

        protected bool IsReloadData { get; set; }
    }
}
