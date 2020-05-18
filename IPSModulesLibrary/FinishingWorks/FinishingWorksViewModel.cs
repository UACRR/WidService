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
        private DispatcherTimer _rollbackTimer;

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

        private bool _isEnabledStopDistributionPanel;
        public bool IsEnabledStopDistributionPanel
        {
            get => _isEnabledStopDistributionPanel;
            set
            {
                _isEnabledStopDistributionPanel = value;
                OnPropertyChanged(() => IsEnabledStopDistributionPanel);
            }
        }

        private bool _isEnabledRunDistributionPanel;
        public bool IsEnabledRunDistributionPanel
        {
            get => _isEnabledRunDistributionPanel;
            set
            {
                _isEnabledRunDistributionPanel = value;
                OnPropertyChanged(() => IsEnabledRunDistributionPanel);
            }
        }

        private bool _isEnabledFinalEnrollment;
        public bool IsEnabledFinalEnrollment
        {
            get => _isEnabledFinalEnrollment;
            set
            {
                _isEnabledFinalEnrollment = value;
                OnPropertyChanged(() => IsEnabledFinalEnrollment);
            }
        }

        private Visibility _rollbackButtonVisibility = Visibility.Visible;
        public Visibility RollbackButtonVisibility
        {
            get => _rollbackButtonVisibility;
            set
            {
                _rollbackButtonVisibility = value;
                OnPropertyChanged(() => RollbackButtonVisibility);
            }
        }

        private string _defaultRrollbackContent = "Откат: осталось";
        private string _rollbackContent = "Откат: осталось";
        public string RollbackContent
        {
            get => _rollbackContent;
            set
            {
                _rollbackContent = value;
                OnPropertyChanged(() => RollbackContent);
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

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(() => StartDate);
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

        private TimeSpan? _rollbackTimeRemaining;
        public TimeSpan? RollbackTimeRemaining
        {
            get => _rollbackTimeRemaining;
            set
            {
                _rollbackTimeRemaining = value;
                if (value.HasValue)
                {
                    _rollbackTimer.Start();
                    RollbackButtonVisibility = Visibility.Visible;
                }
                else
                {
                    _rollbackTimer.Stop();
                    RollbackButtonVisibility = Visibility.Hidden;
                }
            }
        }

        #endregion

        #region * * * METHODS * * *

        private DateTime ProcessDate(DateTime? dateTime)
        {
            var value = dateTime.Value;
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
        }

        private void CreateRollbackTimer()
        {
            _rollbackTimer = new DispatcherTimer(new TimeSpan(0,0,1), DispatcherPriority.Normal,
                delegate
                {
                    if (!RollbackTimeRemaining.HasValue)
                        return;

                    RollbackContent = $"{_defaultRrollbackContent} {RollbackTimeRemaining.Value.Hours:00}:{RollbackTimeRemaining.Value.Minutes:00}:{RollbackTimeRemaining.Value.Seconds:00}";
                    RollbackTimeRemaining = RollbackTimeRemaining.Value.Subtract(TimeSpan.FromSeconds(1));

                    if (RollbackTimeRemaining <= TimeSpan.Zero)
                        RollbackTimeRemaining = null;

                }, Dispatcher.CurrentDispatcher);
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            CreateRollbackTimer();
            // get data
            // init 
            //RollbackTimeRemaining = new TimeSpan(0, 5, 17);
            RollbackTimeRemaining = null;

            IsEnabledStopDistributionPanel = true;
            IsEnabledRunDistributionPanel = false;
        }

        public ICommand StopDistributionCommand => new IPSDelegateCommand(StopDistributionCommandExecute);
        private async void StopDistributionCommandExecute(object o)
        {
            if (!SelectedStopDate.HasValue)
                return;

            string message = $"Автоматичний розподіл буде зупинено {SelectedStopDate:d} {SelectedStopDate:t}. Підтвердити дію?";
            var result = ShowMessage.ConfirmAction(message);

            if (SelectedStopDate < DateTime.Now)
                SelectedStopDate = DateTime.Now;

            if (result == MessageBoxResult.Yes)
            {
                StopDate = ProcessDate(SelectedStopDate);
                IsEnabledStopDistributionPanel = false;
                IsEnabledRunDistributionPanel = true;

                IsBusy = true;
                await Task.Delay(1400);
                IsBusy = false;

                DistributionProcessStatus = DistributionProcessStatus.Stopped;
                IsEnabledFinalEnrollment = true;
            }
        }

        public ICommand RunDistributionProcessCommand => new IPSDelegateCommand(RunDistributionProcessCommandExecute);
        private async void RunDistributionProcessCommandExecute(object o)
        {
            string message = $"Запустити автоматичний розподіл?";

            if (RollbackButtonVisibility == Visibility.Visible)
                message += $"\n\nУвага! Після запуску розподілу «процес відкату» буде недоступний!\nПідтвердити дію?";
            
            var result = ShowMessage.ConfirmAction(message);

            if (result == MessageBoxResult.Yes)
            {
                IsBusy = true;
                await Task.Delay(1147);
                IsBusy = false;

                StopDate = null;
                DistributionProcessStatus = DistributionProcessStatus.InProcess;
                IsEnabledStopDistributionPanel = true;
                IsEnabledRunDistributionPanel = false;
             
                RollbackTimeRemaining = null;
                IsEnabledFinalEnrollment = false;
            }
        }

        public ICommand FinalEnrollmentCommand => new IPSDelegateCommand(FinalEnrollmentCommandExecute);
        private async void FinalEnrollmentCommandExecute(object o)
        {
            string message = $"Запустити процес остаточного зарахування?";
            var result = ShowMessage.ConfirmAction(message);

            if (result == MessageBoxResult.Yes)
            {
                IsBusy = true;
                await Task.Delay(1737);
                IsBusy = false;

                StopDate = null;
                IsEnabledStopDistributionPanel = false;
                
                RollbackTimeRemaining = new TimeSpan(0, 3,30);
                IsEnabledFinalEnrollment = false;
            }
        }

        public ICommand RollbackCommand => new IPSDelegateCommand(RollbackCommandExecute);
        private async void RollbackCommandExecute(object o)
        {
            string message = $"Виконати відкат процесу оплати?";
            _rollbackTimer.Stop();

            var result = ShowMessage.ConfirmAction(message);
            if (result == MessageBoxResult.Yes)
            {
                IsBusy = true;
                await Task.Delay(4250);
                IsBusy = false;

                RollbackTimeRemaining = null;
                RollbackButtonVisibility = Visibility.Hidden;
                IsEnabledFinalEnrollment = true;
                IsEnabledRunDistributionPanel = true;
            }
            else
            {
                _rollbackTimer.Start();
            }
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
