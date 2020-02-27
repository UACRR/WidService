using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace Launcher.WorkplaceModules.CopyrightAdminWorkplace
{
    public class LM_CopyrightAdminWorkplace : ViewModelBase
    {
        private string _title = "Робоче місце адмінстратора права";
        private string _rh1 = "Правовласники";
        private string _rh2 = "Список правовласників";
        private string _rhChange = "Зміна правовласника";
        private string _rhRequest = "Запити";
        private string _or = "Об'єкти права";
        private string _partners = "Товариства";
        private string _pubSub = "Видавництва/Субвидаництва";

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(() => Title);
            }
        }

        public string RH_1
        {
            get => _rh1;
            set
            {
                _rh1 = value;
                OnPropertyChanged(() => RH_1);
            }
        }

        public string RH_2
        {
            get => _rh2;
            set
            {
                _rh2 = value;
                OnPropertyChanged(() => RH_2);
            }
        }

        public string RH_CHANGE
        {
            get => _rhChange;
            set
            {
                _rhChange = value;
                OnPropertyChanged(() => RH_CHANGE);
            }
        }

        public string RH_REQUEST
        {
            get => _rhRequest;
            set
            {
                _rhRequest = value;
                OnPropertyChanged(() => RH_REQUEST);
            }
        }

        public string OR
        {
            get => _or;
            set
            {
                _or = value;
                OnPropertyChanged(() => OR);
            }
        }

        public string PARTNERS
        {
            get => _partners;
            set
            {
                _partners = value;
                OnPropertyChanged(() => PARTNERS);
            }
        }

        public string PUB_SUB
        {
            get => _pubSub;
            set
            {
                _pubSub = value;
                OnPropertyChanged(() => PUB_SUB);
            }
        }
    }
}
