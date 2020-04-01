using Telerik.Windows.Controls;

namespace IPSModulesLibrary.RightholdersList
{
    public class LM_RightholdersList : ViewModelBase
    {
        private string _btnUpdate = "Оновити";
        private string _ddbtnAddRh = "Додати правовласника УААСП";
        private string _ddbtnAddExternalRh = "Додати зовнішнього правовласника";
        private string _btnRhPhis = "Фізична особа";
        private string _btnRhJur = "Юридична особа";
        private string _btnExtRh = "Правовласник";
        private string _btnExtPubl = "Видавництво";
        private string _gvRhCode = "Шифр автор/правовласника";
        private string _gvRhName = "Правовласник";
        private string _gvAgrDate = "Дата договору";
        private string _gvCountObj = "К-сть об'єктів";
        private string _gvRhProfit = "Дохід з початку року";
        private string _gvRhType = "Тип правовласника";
        private string _tvCatAllRh = "Всі правовласники";
        private string _tvCatOcmRh = "Правовласники ОКУ";
        private string _tvCatExternalRh = "Зовнішні правовласники";
        private string _tvAll = "Всі";
        private string _tvNoAccepted = "Не підтверджені";
        private string _tvOnAccepted = "На акцепті";
        private string _tvActive = "Активний";
        private string _tvClosed = "Закритий";
        private string _tvHeritage = "Оформлення спадщини";
        private string _tvBlocked = "Заблокований";
        private string _createRhExtSuccMsg = "Нового зовнішнього правовласника/видавництво додано!";
        private string _createRhExtErrMsg = "Неможливо додати нового зовнішнього правовласника/видавництво!";
        private string _extSearchExp = "Розширений пошук";

        public string BTN_UPDATE
        {
            get => _btnUpdate;
            set
            {
                _btnUpdate = value;
                OnPropertyChanged(nameof(BTN_UPDATE));
            }
        }

        public string DDBTN_ADD_RH
        {
            get => _ddbtnAddRh;
            set
            {
                _ddbtnAddRh = value;
                OnPropertyChanged(nameof(DDBTN_ADD_RH));
            }
        }

        public string DDBTN_ADD_EXTERNAL_RH
        {
            get => _ddbtnAddExternalRh;
            set
            {
                _ddbtnAddExternalRh = value;
                OnPropertyChanged(nameof(DDBTN_ADD_EXTERNAL_RH));
            }
        }

        public string BTN_RH_PHIS
        {
            get => _btnRhPhis;
            set
            {
                _btnRhPhis = value;
                OnPropertyChanged(nameof(BTN_RH_PHIS));
            }
        }

        public string BTN_RH_JUR
        {
            get => _btnRhJur;
            set
            {
                _btnRhJur = value;
                OnPropertyChanged(nameof(BTN_RH_JUR));
            }
        }

        public string BTN_EXT_RH
        {
            get => _btnExtRh;
            set
            {
                _btnExtRh = value;
                OnPropertyChanged(nameof(BTN_EXT_RH));
            }
        }

        public string BTN_EXT_PUBL
        {
            get => _btnExtPubl;
            set
            {
                _btnExtPubl = value;
                OnPropertyChanged(nameof(BTN_EXT_PUBL));
            }
        }

        public string GV_RH_CODE
        {
            get => _gvRhCode;
            set
            {
                _gvRhCode = value;
                OnPropertyChanged(nameof(GV_RH_CODE));
            }
        }

        public string GV_RH_NAME
        {
            get => _gvRhName;
            set
            {
                _gvRhName = value;
                OnPropertyChanged(nameof(GV_RH_NAME));
            }
        }

        public string GV_AGR_DATE
        {
            get => _gvAgrDate;
            set
            {
                _gvAgrDate = value;
                OnPropertyChanged(nameof(GV_AGR_DATE));
            }
        }

        public string GV_COUNT_OBJ
        {
            get => _gvCountObj;
            set
            {
                _gvCountObj = value;
                OnPropertyChanged(nameof(GV_COUNT_OBJ));
            }
        }

        public string GV_RH_PROFIT
        {
            get => _gvRhProfit;
            set
            {
                _gvRhProfit = value;
                OnPropertyChanged(nameof(GV_RH_PROFIT));
            }
        }

        public string GV_RH_TYPE
        {
            get => _gvRhType;
            set
            {
                _gvRhType = value;
                OnPropertyChanged(nameof(GV_RH_TYPE));
            }
        }

        public string TV_CAT_ALL_RH
        {
            get => _tvCatAllRh;
            set
            {
                _tvCatAllRh = value;
                OnPropertyChanged(nameof(TV_CAT_ALL_RH));
            }
        }

        public string TV_CAT_OCM_RH
        {
            get => _tvCatOcmRh;
            set
            {
                _tvCatOcmRh = value;
                OnPropertyChanged(nameof(TV_CAT_OCM_RH));
            }
        }

        public string TV_CAT_EXTERNAL_RH
        {
            get => _tvCatExternalRh;
            set
            {
                _tvCatExternalRh = value;
                OnPropertyChanged(nameof(TV_CAT_EXTERNAL_RH));
            }
        }

        public string TV_ALL
        {
            get => _tvAll;
            set
            {
                _tvAll = value;
                OnPropertyChanged(nameof(TV_ALL));
            }
        }

        public string TV_NO_ACCEPTED
        {
            get => _tvNoAccepted;
            set
            {
                _tvNoAccepted = value;
                OnPropertyChanged(nameof(TV_NO_ACCEPTED));
            }
        }

        public string TV_ON_ACCEPTED
        {
            get => _tvOnAccepted;
            set
            {
                _tvOnAccepted = value;
                OnPropertyChanged(nameof(TV_ON_ACCEPTED));
            }
        }

        public string TV_ACTIVE
        {
            get => _tvActive;
            set
            {
                _tvActive = value;
                OnPropertyChanged(nameof(TV_ACTIVE));
            }
        }

        public string TV_CLOSED
        {
            get => _tvClosed;
            set
            {
                _tvClosed = value;
                OnPropertyChanged(nameof(TV_CLOSED));
            }
        }

        public string TV_HERITAGE
        {
            get => _tvHeritage;
            set
            {
                _tvHeritage = value;
                OnPropertyChanged(nameof(TV_HERITAGE));
            }
        }

        public string TV_BLOCKED
        {
            get => _tvBlocked;
            set
            {
                _tvBlocked = value; 
                OnPropertyChanged(nameof(TV_BLOCKED));
            }
        }

        public string CREATE_RH_EXT_SUCC_MSG
        {
            get => _createRhExtSuccMsg;
            set
            {
                _createRhExtSuccMsg = value; 
                OnPropertyChanged(nameof(CREATE_RH_EXT_SUCC_MSG));
            }
        }

        public string CREATE_RH_EXT_ERR_MSG
        {
            get => _createRhExtErrMsg;
            set
            {
                _createRhExtErrMsg = value;
                OnPropertyChanged(nameof(CREATE_RH_EXT_ERR_MSG));
            }
        }

        public string EXT_SEARCH_EXP
        {
            get => _extSearchExp;
            set
            {
                _extSearchExp = value;
                OnPropertyChanged(nameof(EXT_SEARCH_EXP));
            }
        }
    }
}
