using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.ViewModels.Consumer;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsCommonTypes.Views;
using IPSComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.RegisterControls
{

    public class RegisterCCIDPresenter
    {
        private readonly RegisterService _registerService;
        private readonly ConsumerService _consumerService;
        
        private readonly RegisterCCIDView _view;

        private Register _register;
        private ConsumerSmallRightView _consumer;
        
        public RegisterCCIDPresenter(RegisterCCIDView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;
            _view.Load += View_Load;
            _registerService = registerService;
            _consumerService = new ConsumerService();
        }

        private async void View_Load(object sender, System.EventArgs e)
        {
            _view.IsBusy = true;
            _view.CCIDRegisterItems = await _registerService.GetCCIDRegisterItems(_register.RegId);
            _view.IsBusy = false;
        }

        public void Show(int regId)
        {
            _register = _registerService.GetCCIDRegister(regId);
            _consumer = _consumerService.GetShortInfoById(_register.CustId);

            UpdateDataBindings();

            _view.Run();
        }

        public async void BeginSync()
        {
            var isConfirm = MessageShow.ConfirmAction("Запустити процедуру синхронізації?") == DialogResult.Yes;
            if (isConfirm)
            {
                _view.IsBusy = true;
                var result = await _registerService.ExecuteSyncProcedure(_register.RegId);
                _view.IsBusy = false;

                MessageShow.ShowInfoByResult(result.Message, result.IsSuccess);
                UpdateRegister();
            }
        }

        public async void BeginDistribution()
        {
            var isConfirm = MessageShow.ConfirmAction("Запустити процедуру розподілу?") == DialogResult.Yes;
            if (isConfirm)
            {
                _view.IsBusy = true;
                var result = await _registerService.ExecuteDistributionProcedure(_register.RegId);
                _view.IsBusy = false;

                MessageShow.ShowInfoByResult(result.Message, result.IsSuccess);
                UpdateRegister();
            }
        }

        public async void BeginPayment()
        {
            var isConfirm = MessageShow.ConfirmAction("Запустити процедуру оплати?") == DialogResult.Yes;
            if (isConfirm)
            {
                _view.IsBusy = true;
                var result = await _registerService.ExecutePaymentProcedure(_register.RegId);
                _view.IsBusy = false;

                MessageShow.ShowInfoByResult(result.Message, result.IsSuccess);
                UpdateRegister();
            }
        }

        /// <summary>
        /// Оновити дані звіту після запуску процедур
        /// </summary>
        private void UpdateRegister()
        {
            _register = _registerService.GetCCIDRegister(_view.Register.RegId);
            _view.Register = _register;
        }

        /// <summary>
        /// Синхронізувати дані
        /// </summary>
        private void UpdateDataBindings()
        {
            _view.Register = _register;
            _view.ConsumerInfo = _consumer;
        }
    }
}