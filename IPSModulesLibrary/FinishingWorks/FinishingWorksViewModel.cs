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

        public TimeSpan TimeRemaining { get; set; } = new TimeSpan(0,5, 17);

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
                    RollbackContent = $"{_defaultRrollbackContent} {TimeRemaining.Hours:00}:{TimeRemaining.Minutes:00}:{TimeRemaining.Seconds:00}";
                    TimeRemaining = TimeRemaining.Subtract(TimeSpan.FromSeconds(1));

                    if (RollbackButtonVisibility == Visibility.Hidden)
                        RollbackButtonVisibility = Visibility.Visible;

                    if (TimeRemaining <= TimeSpan.Zero)
                    {
                        RollbackButtonVisibility = Visibility.Hidden;
                        _rollbackTimer.Stop();
                    }
                },Dispatcher.CurrentDispatcher);
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            CreateRollbackTimer();

            IsEnabledStopDistributionPanel = true;
            IsEnabledRunDistributionPanel = false;

            RollbackButtonVisibility = Visibility.Hidden;

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

                    if (DistributionProcessStatus == DistributionProcessStatus.Stopped)
                    {
                        IsEnabledFinalEnrollment = true;
                    }

                }, Dispatcher.CurrentDispatcher);
        }

        public ICommand StopDistributionCommand => new IPSDelegateCommand(StopDistributionCommandExecute);
        private void StopDistributionCommandExecute(object o)
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
                IsEnabledStopDistributionPanel = true;
                IsEnabledRunDistributionPanel = false;
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
                DistributionProcessStatus = DistributionProcessStatus.InProcess;
                IsEnabledStopDistributionPanel = false;
                IsEnabledRunDistributionPanel = false;
                
                TimeRemaining = new TimeSpan(0, 30,00);
                if (!_rollbackTimer.IsEnabled)
                    _rollbackTimer.Start();

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
                TimeRemaining = TimeSpan.Zero;
                RollbackButtonVisibility = Visibility.Hidden;
                IsEnabledFinalEnrollment = true;
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
