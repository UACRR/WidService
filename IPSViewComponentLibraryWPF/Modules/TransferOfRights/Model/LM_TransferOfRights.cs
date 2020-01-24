using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class LM_TransferOfRights : ViewModelBase
    {
        private string _transferType = "Вид передачі";
        public string TransferType
        {
            get => _transferType;
            set
            {
                _transferType = value;
                OnPropertyChanged(() =>  TransferType);
            }
        }

        private string _alienation = "Відчудження";
        public string Alienation
        {
            get => _alienation;
            set
            {
                _alienation = value;
                OnPropertyChanged(() => Alienation);
            }
        }


        private string _defaultTransfer = "Передача";
        public string DefaultTransfer
        {
            get => _defaultTransfer;
            set
            {
                _defaultTransfer = value;
                OnPropertyChanged(() => DefaultTransfer);
            }
        }

        private string _heritage = "Спадщина";
        public string Heritage
        {
            get => _heritage;
            set
            {
                _heritage = value;
                OnPropertyChanged(() => Heritage);
            }
        }

        private string _transferPubSub = "Передача між Видавництво/Субвидавництво";
        public string TransferPubSub
        {
            get => _transferPubSub;
            set
            {
                _transferPubSub = value;
                OnPropertyChanged(() => TransferPubSub);
            }
        }

        private string _rightholder = "Правовласник";
        public string Rightholder
        {
            get => _rightholder;
            set
            {
                _rightholder = value;
                OnPropertyChanged(() => Rightholder);
            }
        }

        private string _rightholderAdd = "Додатково правовласник";
        public string RightholderAdd
        {
            get => _rightholderAdd;
            set
            {
                _rightholderAdd = value;
                OnPropertyChanged(() => RightholderAdd);
            }
        }

        private string _profitByStartYear = "Дохід з початку року";
        public string ProfitByStartYear
        {
            get => _profitByStartYear;
            set
            {
                _profitByStartYear = value;
                OnPropertyChanged(() => ProfitByStartYear);
            }
        }

        private string _anketa = "Анкета";
        public string Anketa
        {
            get => _anketa;
            set
            {
                _anketa = value;
                OnPropertyChanged(() => Anketa);
            }
        }

        private string _gvcObjCode = "Шифр твору";
        internal string gvc_ObjCode
        {
            get => _gvcObjCode;
            set
            {
                _gvcObjCode = value;
                OnPropertyChanged(() => gvc_ObjCode);
            }
        }

        #region видавництво/субвидавництво

        private string _pubSub = "Видавництво/Субвидавництво";
        public string PubSub
        {
            get => _pubSub;
            set
            {
                _pubSub = value;
                OnPropertyChanged(() => PubSub);
            }
        }

        private string _pubSubTransferType = "Оберіть тип передачі";
        public string PubSubTransferType
        {
            get => _pubSubTransferType;
            set
            {
                _pubSubTransferType = value;
                OnPropertyChanged(() => PubSubTransferType);
            }
        }

        #endregion


        public void UpdateLanguageLocalization()
        {

        }
    }
}
