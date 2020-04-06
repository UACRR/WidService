using Telerik.Windows.Controls;

namespace IPSModulesLibrary.CommunitiesList
{
    public class LM_CommunitiesList: ViewModelBase
    {
        private string _createCommSuccMsg = "Нове товариство додано!";
        private string _createCommErrMsg = "Неможливо додати нове товариство!";
        private string _btnUpdate = "Оновити";
        private string _extSearchExp = "Розширений пошук";
        private string _gvInCode = "Шифр";
        private string _gvCommunityName = "Назва товариства";
        private string _gvCommRegDate = "Дата створення";
        private string _gvAuthCount = "К-сть авторів";
        private string _btnCreateCommunity = "Додати нове товариство";

        public string CREATE_COMM_SUCC_MSG
        {
            get => _createCommSuccMsg;
            set
            {
                _createCommSuccMsg = value; 
                OnPropertyChanged(nameof(CREATE_COMM_SUCC_MSG));
            }
        }

        public string CREATE_COMM_ERR_MSG
        {
            get => _createCommErrMsg;
            set
            {
                _createCommErrMsg = value;
                OnPropertyChanged(nameof(CREATE_COMM_ERR_MSG));
            }
        }

        public string BTN_UPDATE
        {
            get => _btnUpdate;
            set
            {
                _btnUpdate = value;
                OnPropertyChanged(nameof(BTN_UPDATE));
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

        public string GV_IN_CODE
        {
            get => _gvInCode;
            set
            {
                _gvInCode = value;
                OnPropertyChanged(nameof(GV_IN_CODE));
            }
        }

        public string GV_COMMUNITY_NAME
        {
            get => _gvCommunityName;
            set
            {
                _gvCommunityName = value;
                OnPropertyChanged(nameof(GV_COMMUNITY_NAME));
            }
        }

        public string GV_COMM_REG_DATE
        {
            get => _gvCommRegDate;
            set
            {
                _gvCommRegDate = value;
                OnPropertyChanged(nameof(GV_COMM_REG_DATE));
            }
        }

        public string GV_AUTH_COUNT
        {
            get => _gvAuthCount;
            set
            {
                _gvAuthCount = value;
                OnPropertyChanged(nameof(GV_AUTH_COUNT));
            }
        }

        public string BTN_CREATE_COMMUNITY
        {
            get => _btnCreateCommunity;
            set
            {
                _btnCreateCommunity = value;
                OnPropertyChanged(nameof(BTN_CREATE_COMMUNITY));
            }
        }
    }
}
