using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IPSModulesLibrary.FinishingWorks
{
    public class FinishingWorksViewModel : IPSViewModel<LM_FinishingWorks>
    {
        private DispatcherTimer _timer;

        #region * * * BEHAVIORS PROPERTIES * * *

        private Visibility _distributionInProcessVisibility = Visibility.Visible;
        public Visibility DistributionInProcessVisibility
        {
            get => _distributionInProcessVisibility;
            set
            {
                _distributionInProcessVisibility = value;
                OnPropertyChanged(() => DistributionInProcessVisibility);
            }
        }

        private Visibility _distributionStoppedVisibility = Visibility.Collapsed;
        public Visibility DistributionStoppedVisibility
        {
            get => _distributionStoppedVisibility;
            set
            {
                _distributionStoppedVisibility = value;
                OnPropertyChanged(() => DistributionStoppedVisibility);
            }
        }

        private DistributionProcessStatus _distributionProcessStatus;
        public DistributionProcessStatus DistributionProcessStatus
        {
            get => _distributionProcessStatus;
            set
            {
                _distributionProcessStatus = value;

                if (value == DistributionProcessStatus.InProcess)
                {
                    DistributionInProcessVisibility = Visibility.Visible;
                    DistributionStoppedVisibility = Visibility.Collapsed;
                }
                else if (value == DistributionProcessStatus.Stopped)
                {

                    DistributionInProcessVisibility = Visibility.Collapsed;
                    DistributionStoppedVisibility = Visibility.Visible;
                }
                else
                {
                    DistributionInProcessVisibility = Visibility.Collapsed;
                    DistributionStoppedVisibility = Visibility.Collapsed;
                }
            }
        }

        #endregion


        #region * * * DATA PROPERTIES * * *

        private DateTime? _stopDate;
        public DateTime? StopDate
        {
            get => _stopDate;
            set
            {
                _stopDate = value;
                OnPropertyChanged(() => StopDate);
            }
        }

        private DateTime? _selectedStopDate;
        public DateTime? SelectedStopDate
        {
            get => _selectedStopDate;
            set
            {
                if (value >= DateTime.Now)
                {
                    _selectedStopDate = value;
                }
                else
                {
                    _selectedStopDate = DateTime.Now;
                }

                OnPropertyChanged(() => StopDate);
            }
        }


        #endregion

        #region * * * METHODS * * *

        private DateTime ProcessDate(DateTime? dateTime)
        {
            var value = dateTime.Value;
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 10), DispatcherPriority.Normal,
                async delegate
                {
                    if (DistributionProcessStatus == DistributionProcessStatus.InProcess && StopDate.HasValue && StopDate <= ProcessDate(DateTime.Now))
                    {
                        IsBusy = true;
                        await Task.Delay(1500);
                        
                        DistributionProcessStatus = DistributionProcessStatus.Stopped;
                        
                        IsBusy = false;
                    }
                }, Dispatcher.CurrentDispatcher);
        }

        public ICommand StopDistributionCommand => new IPSDelegateCommand(StopDistributionCommandExecute);
        private void StopDistributionCommandExecute(object o)
        {
            string message = $"Автоматичний розподіл буде зупинено {SelectedStopDate:d} {SelectedStopDate:t}. Підтвердити дію?";
            var result = ShowMessage.ConfirmAction(message);

            if (SelectedStopDate < DateTime.Now)
                SelectedStopDate = DateTime.Now;

            if (result == MessageBoxResult.Yes)
            {
                StopDate = ProcessDate(SelectedStopDate);
            }
        }

        public ICommand RunDistributionProcessCommand => new IPSDelegateCommand(RunDistributionProcessCommandExecute);
        private void RunDistributionProcessCommandExecute(object o)
        {

            string message = $"Запустити автоматичний розподіл?";
            var result = ShowMessage.ConfirmAction(message);

            if (result == MessageBoxResult.Yes)
            {
                StopDate = null;
                DistributionProcessStatus = DistributionProcessStatus.InProcess;
            }

        }

        public ICommand FinalEnrollmentCommand => new IPSDelegateCommand(FinalEnrollmentCommandExecute);
        private void FinalEnrollmentCommandExecute(object o)
        {

        }

        public ICommand RollbackCommand => new IPSDelegateCommand(RollbackCommandExecute);
        private void RollbackCommandExecute(object o)
        {

        }

        #endregion

    }
    public enum DistributionProcessStatus
    {
        None,
        InProcess,
        Stopped,
    }
}
