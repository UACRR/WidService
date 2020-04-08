using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Extensions
{
    /// <summary>
    /// Базовий клас для класів ViewModel. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class IPSViewModel<T> : ViewModelBase, ILazyLoadData where T: class, new()
    {
        protected DataTable TempDataTable { get; set; }

        /// <summary>
        /// Делегат для лінивого завантаження даних
        /// </summary>
        public Action LazyLoadDataAction { get; set; }

        private bool _isBusy;
        /// <summary>
        /// Індщикатор зайнятості
        /// </summary>
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
        /// <summary>
        /// Об'єкт локалізації
        /// </summary>
        public T LOC
        {
            get => _loc;
            set
            {
                _loc = value;
                OnPropertyChanged(() => LOC);
            }
        }

        private bool IsLoaded { get; set; }

        private bool IsDataLoaded { get; set; }

        /// <summary>
        /// Виконує процес завантаження контрола в обгорткі
        /// </summary>
        /// <param name="actionOnLoad">метод </param>
        public void ControlLoad(Action actionOnLoad)
        {
            if (IsLoaded)
                return;

            actionOnLoad?.Invoke();

            IsLoaded = true;
        }

        public void LazyLoadData()
        {
            if (LazyLoadDataAction == null || IsDataLoaded)
                return;

            LazyLoadDataAction.Invoke();

            IsDataLoaded = true;
        }
    }
}
