using Telerik.Windows.Controls;

namespace IPSModulesLibrary.ObjectsRightList
{
    public class LM_ObjectsRightList : ViewModelBase
    {
        private string _extSearchExp = "Розширений пошук";
        private string _tvCatState = "Стан";
        private string _tv_all = "Всі";
        private string _tv_no_accept = "Не підтверджені";
        private string _tv_no_attach = "Не прив'язані";
        private string _tv_no_distrib = "Не розподілені";
        private string _btn_update = "Оновити";
        private string _btn_create_obj = "Додати";
        private string _gv_in_code = "Шифр твору";
        private string _gv_obj_name = "Назва твору";
        private string _gv_bs_cat_name = "В/М";
        private string _gvtt_bs_cat_name = "Об'єкт великих/малих прав";
        private string _gv_genre = "Жанр";
        private string _gv_author = "Автори";
        private string _gv_performer = "Виконавець";
        private string _gv_rate = "Спільний % володіння";
        private string _gv_undistrib_money = "Нерозподілена сума";

        public string TV_CAT_STATE
        {
            get => _tvCatState;
            set
            {
                _tvCatState = value;
                OnPropertyChanged(nameof(TV_CAT_STATE));
            }
        }

        public string TV_ALL
        {
            get => _tv_all;
            set
            {
                _tv_all = value;
                OnPropertyChanged(nameof(TV_ALL));
            }
        }

        public string TV_NO_ACCEPT
        {
            get => _tv_no_accept;
            set
            {
                _tv_no_accept = value;
                OnPropertyChanged(nameof(TV_NO_ACCEPT));
            }
        }

        public string TV_NO_ATTACH
        {
            get => _tv_no_attach;
            set
            {
                _tv_no_attach = value;
                OnPropertyChanged(nameof(TV_NO_ATTACH));
            }
        }

        public string TV_NO_DISTRIB
        {
            get => _tv_no_distrib;
            set
            {
                _tv_no_distrib = value;
                OnPropertyChanged(nameof(TV_NO_DISTRIB));
            }
        }

        public string BTN_UPDATE
        {
            get => _btn_update;
            set
            {
                _btn_update = value;
                OnPropertyChanged(nameof(BTN_UPDATE));
            }
        }

        public string BTN_CREATE_OBJ
        {
            get => _btn_create_obj;
            set
            {
                _btn_create_obj = value;
                OnPropertyChanged(nameof(BTN_CREATE_OBJ));
            }
        }

        public string GV_IN_CODE
        {
            get => _gv_in_code;
            set
            {
                _gv_in_code = value;
                OnPropertyChanged(nameof(GV_IN_CODE));
            }
        }

        public string GV_OBJ_NAME
        {
            get => _gv_obj_name;
            set
            {
                _gv_obj_name = value;
                OnPropertyChanged(nameof(GV_OBJ_NAME));
            }
        }

        public string GV_BS_CAT_NAME
        {
            get => _gv_bs_cat_name;
            set
            {
                _gv_bs_cat_name = value;
                OnPropertyChanged(nameof(GV_BS_CAT_NAME));
            }
        }

        public string GVTT_BS_CAT_NAME
        {
            get => _gvtt_bs_cat_name;
            set
            {
                _gvtt_bs_cat_name = value;
                OnPropertyChanged(nameof(GVTT_BS_CAT_NAME));
            }
        }

        public string GV_GENRE
        {
            get => _gv_genre;
            set
            {
                _gv_genre = value;
                OnPropertyChanged(nameof(GV_GENRE));
            }
        }

        public string GV_AUTHOR
        {
            get => _gv_author;
            set
            {
                _gv_author = value;
                OnPropertyChanged(nameof(GV_AUTHOR));
            }
        }

        public string GV_PERFORMER
        {
            get => _gv_performer;
            set
            {
                _gv_performer = value;
                OnPropertyChanged(nameof(GV_PERFORMER));
            }
        }

        public string GV_RATE
        {
            get => _gv_rate;
            set
            {
                _gv_rate = value;
                OnPropertyChanged(nameof(GV_RATE));
            }
        }

        public string GV_UNDISTRIB_MONEY
        {
            get => _gv_undistrib_money;
            set
            {
                _gv_undistrib_money = value;
                OnPropertyChanged(nameof(GV_UNDISTRIB_MONEY));
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