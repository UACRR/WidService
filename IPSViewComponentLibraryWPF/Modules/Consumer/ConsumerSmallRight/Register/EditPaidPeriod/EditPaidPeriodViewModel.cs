using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using IPSViewComponentLibraryWPF.IPSExtensions;
using ipsFormsDesign.Services;
using ipsFormsDesign.Model;
using IPSComponentLibrary.Extensions;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.EditPaidPeriod
{
    public class EditPaidPeriodViewModel : ViewModelBase
    {
        public EditPaidPeriodViewModel() { }

        private bool _isBusy;
        /// <summary>
        /// Changing state of busy indicator
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

        private PaidPeriod _period;
        public PaidPeriod Period
        {
            get => _period;
            set
            {
                _period = value;
                OnPropertyChanged(() => Period);
            }
        }

        /// <summary>
        /// Зберегти зміни
        /// </summary>
        public ICommand SaveCommand => new IPSDelegateCommand(SaveCommandExecute);
        private async void SaveCommandExecute(object o)
        {
            var window = o as Window;
            if (window == null)
                return;

            if (!Validate())
                return;

            IsBusy = true;
            var result = await ConsumerRegisterService.GetInstance().EditPaidPeriod(Period);
            IsBusy = false;
            MessageShow.ShowInfoByResult(result);

            if (result.IsSuccess)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        /// <summary>
        /// Закрити вікно
        /// </summary>
        public ICommand CloseWindowCommand => new IPSDelegateCommand(CloseWindowCommandExecue);
        private void CloseWindowCommandExecue(object o)
        {
            var window = o as Window;
            if (window == null)
                return;

            window.DialogResult = false;
            window.Close();
        }

        private bool Validate()
        {
            bool isValid = true;
            if (Period.BeginDate > Period.EndDate)
            {
                MessageShow.ShowError($"Дата початку періоду ({Period.BeginDate:dd.MM.yyyy}) не може бути більшою дати завершення ({Period.EndDate:dd.MM.yyyy})!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(Period.PeriodName))
            {
                MessageShow.ShowError($"Введіть назву періоду!");
                isValid = false;
            }
            
            return isValid;
        }
    }
}
