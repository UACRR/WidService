using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ipsFormsDesign.Services;
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
                    IsEnabledStopDistributionButton = true;
                    IsEnabledRunDistributionButton = false;
                    ChangeStopDateButtonVisibility = Visibility.Collapsed;
                    IsEnabledFinalEnrollment = false;
                    StopDistributionDateInfoPanelVisibility = Visibility.Collapsed;

                }
                else if (value == DistributionProcessStatus.Stopped)
                {
                    DistributionInProcessVisibility = Visibility.Collapsed;
                    DistributionStoppedVisibility = Visibility.Visible;
                    IsEnabledStopDistributionButton = false;
                    IsEnabledRunDistributionButton = true;
                    ChangeStopDateButtonVisibility = Visibility.Visible;
                    IsEnabledFinalEnrollment = true;
                    StopDistributionDateInfoPanelVisibility = Visibility.Visible;
                }
                else
                {
                    DistributionInProcessVisibility = Visibility.Collapsed;
                    DistributionStoppedVisibility = Visibility.Collapsed;
                }
            }
        }

        private bool _isEnabledStopDistributionButton = true;
        public bool IsEnabledStopDistributionButton
        {
            get => _isEnabledStopDistributionButton;
            set
            {
                _isEnabledStopDistributionButton = value;
                OnPropertyChanged(() => IsEnabledStopDistributionButton);
            }
        }

        private bool _isEnabledStopDate = true;
        public bool IsEnabledStopDate
        {
            get => _isEnabledStopDate;
            set
            {
                _isEnabledStopDate = value;
                OnPropertyChanged(() => IsEnabledStopDate);
            }
        }

        private Visibility _changeStopDateButtonVisibility = Visibility.Visible;
        public Visibility ChangeStopDateButtonVisibility
        {
            get => _changeStopDateButtonVisibility;
            set
            {
                _changeStopDateButtonVisibility = value;
                OnPropertyChanged(() => ChangeStopDateButtonVisibility);
            }
        }

        private Visibility _stopDistributionDateInfoPanelVisibility = Visibility.Visible;
        public Visibility StopDistributionDateInfoPanelVisibility
        {
            get => _stopDistributionDateInfoPanelVisibility;
            set
            {
                _stopDistributionDateInfoPanelVisibility = value;
                OnPropertyChanged(() => StopDistributionDateInfoPanelVisibility);
            }
        }

        private Visibility _stopAutoInfoPanelVisibility = Visibility.Visible;
        public Visibility StopAutoInfoPanelVisibility
        {
            get => _stopAutoInfoPanelVisibility;
            set
            {
                _stopAutoInfoPanelVisibility = value;
                OnPropertyChanged(() => StopAutoInfoPanelVisibility);
            }
        }

        private bool _isEnabledRunDistributionButton = true;
        public bool IsEnabledRunDistributionButton
        {
            get => _isEnabledRunDistributionButton;
            set
            {
                _isEnabledRunDistributionButton = value;
                OnPropertyChanged(() => IsEnabledRunDistributionButton);
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

        private string _defaultRrollbackContent = "ROLLBACK: залишилось";
        private string _rollbackContent = "ROLLBACK: залишилось";
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

        public bool IsStopAuto { get; set; }

        private DateTime? _stopDateAuto;
        public DateTime? StopDateAuto
        {
            get => _stopDateAuto;
            set
            {
                _stopDateAuto = value;
                OnPropertyChanged(() => StopDateAuto);
            }
        }

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

        private DateTime? _selectedStopDate = DateTime.Today.AddDays(1);
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

                    var time = RollbackTimeRemaining.Value;
                    RollbackContent = $"{_defaultRrollbackContent} {time.Days * 24 + time.Hours}:{time.Minutes:00}:{time.Seconds:00}";
                    RollbackTimeRemaining = RollbackTimeRemaining.Value.Subtract(TimeSpan.FromSeconds(1));

                    if (RollbackTimeRemaining <= TimeSpan.Zero)
                    {
                        RollbackTimeRemaining = null;
                        UpdateSystemState();
                    }
                }, Dispatcher.CurrentDispatcher);
        }

        private async void UpdateSystemState()
        {
            var service = FinishingWorksService.GetInstance();

            IsBusy = true;
            
            await Task.Delay(1000);

            var data = await service.GetSystemState();
            
            // автозупинка
            IsStopAuto = (data.Data.StatusAvto ?? 0) == 1;

            bool inProcess = (data.Data.Status ?? 0) == 0;

            DistributionProcessStatus = inProcess && !IsStopAuto ? DistributionProcessStatus.InProcess : DistributionProcessStatus.Stopped;

            if (IsStopAuto)
            {
                //var date = data.Data.DateStop > data.Data.DateStopAvto ? data.Data.DateStop : data.Data.DateStopAvto;
                RollbackTimeRemaining = data.Data.DateStopAvto - DateTime.Now;
                
                StartDate = data.Data.DateStopBegin; 
                StopDate = data.Data.DateStop; 
                
                StopDateAuto = data.Data.DateStopAvto;
                
                StopAutoInfoPanelVisibility = Visibility.Visible;
                IsEnabledRunDistributionButton = false;

                IsEnabledFinalEnrollment = false;
            }
            else
            {
                RollbackTimeRemaining = null;
                
                if (!inProcess)
                {
                    StartDate = data.Data.DateStopBegin;
                    StopDate = data.Data.DateStop;
                    StopDistributionDateInfoPanelVisibility = Visibility.Visible;
                }

                StopAutoInfoPanelVisibility = Visibility.Collapsed;
            }

            IsBusy = false;
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            CreateRollbackTimer();
            UpdateSystemState();
        }

        public ICommand UpdateCommand => new IPSDelegateCommand(UpdateCommandExecute);
        private void UpdateCommandExecute(object o)
        {
            UpdateSystemState();
        }

        public ICommand StopDistributionCommand => new IPSDelegateCommand(StopDistributionCommandExecute);
        private async void StopDistributionCommandExecute(object o)
        {
            if (!SelectedStopDate.HasValue)
                return;

            if (SelectedStopDate < DateTime.Now)
                SelectedStopDate = DateTime.Now;

            string message = $"Автоматичний розподіл буде зупинено до {SelectedStopDate:d} {SelectedStopDate:t}. Підтвердити дію?";
            
            var confirmAction = ShowMessage.ConfirmAction(message);

            if (confirmAction == MessageBoxResult.Yes)
            {
                if (SelectedStopDate < DateTime.Now)
                    SelectedStopDate = DateTime.Now;

                StartDate = DateTime.Now;
                StopDate = ProcessDate(SelectedStopDate);

                var service = FinishingWorksService.GetInstance();
                
                IsBusy = true;
                var result = await service.StopPayment(StopDate.Value);
                IsBusy = false;

                if (!result.IsSuccess)
                    ShowMessage.ShowError(result.Exception);

                UpdateSystemState();
            }
        }

        public ICommand ChangeStopDateCommand => new IPSDelegateCommand(ChangeStopDateCommandExecute);
        private async void ChangeStopDateCommandExecute(object o)
        {
            string message = $"Змінити дату та час до якого буде діяти зупинка розподілу? Автоматичний розподіл буде зупинено до {SelectedStopDate:d} {SelectedStopDate:t}.";

            var confirmAction = ShowMessage.ConfirmAction(message);

            if (confirmAction == MessageBoxResult.Yes)
            {
                var service = FinishingWorksService.GetInstance();
                
                if (SelectedStopDate < DateTime.Now)
                    SelectedStopDate = DateTime.Now;

                IsBusy = true;
                
                StopDate = ProcessDate(SelectedStopDate);
                
                await Task.Delay(1500);
                
                var result = await service.ChangeDateStop(StopDate.Value);
                
                IsBusy = false;

                if (!result.IsSuccess)
                    ShowMessage.ShowError(result.Exception);

                UpdateSystemState();
            }
        }

        public ICommand RunDistributionProcessCommand => new IPSDelegateCommand(RunDistributionProcessCommandExecute);
        private async void RunDistributionProcessCommandExecute(object o)
        {
            string message = $"Запустити автоматичний розподіл?";

            if (RollbackButtonVisibility == Visibility.Visible)
                message += $"\n\nУвага! Після запуску розподілу «процес відкату» буде недоступний!\nПідтвердити дію?";
            
            var confirmAction = ShowMessage.ConfirmAction(message);

            if (confirmAction == MessageBoxResult.Yes)
            {
                var service = FinishingWorksService.GetInstance();

                IsBusy = true;
                var result = await service.RunPayment();
                IsBusy = false;

                if (!result.IsSuccess)
                    ShowMessage.ShowError(result.Exception);

                UpdateSystemState();
            }
        }

        public ICommand FinalEnrollmentCommand => new IPSDelegateCommand(FinalEnrollmentCommandExecute);
        private async void FinalEnrollmentCommandExecute(object o)
        {
            string message = $"Запустити процес остаточного зарахування?";

            var confirmAction = ShowMessage.ConfirmAction(message);
            if (confirmAction == MessageBoxResult.Yes)
            {
                var service = FinishingWorksService.GetInstance();
                
                IsBusy = true;
                var result = await service.RunFinalEnrollment();
                IsBusy = false;

                if (!result.IsSuccess)
                    ShowMessage.ShowError(result.Exception);

                UpdateSystemState();
            }
        }

        public ICommand RollbackCommand => new IPSDelegateCommand(RollbackCommandExecute);
        private async void RollbackCommandExecute(object o)
        {
            string message = $"Виконати відкат процесу оплати?";
            _rollbackTimer.Stop();

            var confirmAction = ShowMessage.ConfirmAction(message);
            if (confirmAction == MessageBoxResult.Yes)
            {
                var service = FinishingWorksService.GetInstance();
                
                IsBusy = true;
                var result = await service.RollbackLastFinalEnrollment();
                IsBusy = false;

                if (!result.IsSuccess)
                    ShowMessage.ShowError(result.Exception);
                
                UpdateSystemState();
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
