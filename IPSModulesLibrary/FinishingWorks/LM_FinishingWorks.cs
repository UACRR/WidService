using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace IPSModulesLibrary.FinishingWorks
{
    public class LM_FinishingWorks : ViewModelBase
    {
        private string _descriptionProcessP1 = "Зупинка розподілу необхідна для перенесення нарахованих роялті на рахунки \"до виплати\" для Правовласників.";
        public string DescriptionProcess_p1
        {
            get => _descriptionProcessP1;
            set
            {
                _descriptionProcessP1 = value;
                OnPropertyChanged(() => DescriptionProcess_p1);
            }
        }

        private string _descriptionProcessP2 = "Зупинка розподілу зупиняє процес розрахунку та нарахування роялті - по усім звітам, що будуть завантажені та опрацьовані після зупинки розподілу, необхідні обчислення та зарахування сум на відповідні системні рахунки, виконаються автоматично після дати запуску.";
        public string DescriptionProcess_p2
        {
            get => _descriptionProcessP2;
            set
            {
                _descriptionProcessP2 = value;
                OnPropertyChanged(() => DescriptionProcess_p2);
            }
        }

        private string _descriptionProcessP3 = "1. Ви можите зупинити розподіл вручну в будь який час. Для цього натисніть \"STOP\".";
        public string DescriptionProcess_p3
        {
            get => _descriptionProcessP3;
            set
            {
                _descriptionProcessP3 = value;
                OnPropertyChanged(() => DescriptionProcess_p3);
            }
        }

        private string _descriptionProcessP4 = "* Період по замовчуванню, на який зупиняється розподіл - поточна доба.";
        public string DescriptionProcess_p4
        {
            get => _descriptionProcessP4;
            set
            {
                _descriptionProcessP4 = value;
                OnPropertyChanged(() => DescriptionProcess_p4);
            }
        }

        private string _descriptionProcessP5 = "* Ви можете встановити період зупинки більшим ніж по замовчуванню, для цього змініть дату та час у полі \"ДО\" на натисніть \"Змінити\"";
        public string DescriptionProcess_p5
        {
            get => _descriptionProcessP5;
            set
            {
                _descriptionProcessP5 = value;
                OnPropertyChanged(() => DescriptionProcess_p5);
            }
        }

        private string _descriptionProcessP6 = "2. Для перенесення коштів натисніть \"Виконати зарахування коштів\".";
        public string DescriptionProcess_p6
        {
            get => _descriptionProcessP6;
            set
            {
                _descriptionProcessP6 = value;
                OnPropertyChanged(() => DescriptionProcess_p6);
            }
        }

        private string _descriptionProcessP7 = "3. Розподіл автоматично запуститься по закінченню встановленого періоду зупинки (навіть якщо не було активовано перенесення коштів).";
        public string DescriptionProcess_p7
        {
            get => _descriptionProcessP7;
            set
            {
                _descriptionProcessP7 = value;
                OnPropertyChanged(() => DescriptionProcess_p7);
            }
        }

        private string _descriptionProcessP8 = "* Ви можите запустити розподіл вручну в будь який час, якщо не було виконано зарахування коштів. ";
        public string DescriptionProcess_p8
        {
            get => _descriptionProcessP8;
            set
            {
                _descriptionProcessP8 = value;
                OnPropertyChanged(() => DescriptionProcess_p8);
            }
        }

        private string _descriptionProcessP9 = "* Після зарахування коштів, запуск розподілу вручну можливий до дати закінчення періоду (дата \"ДО\") але не раніше дати \"автоблокування STARTy до\".";
        public string DescriptionProcess_p9
        {
            get => _descriptionProcessP9;
            set
            {
                _descriptionProcessP9 = value;
                OnPropertyChanged(() => DescriptionProcess_p9);
            }
        }

        private string _descriptionProcessP10 = "* Ви можете відмінити зарахування протягом визначеного часу на кнопці ROLLBACK. Після відміни зарахування ви можете вручну увімкнути розподіл.";
        public string DescriptionProcess_p10
        {
            get => _descriptionProcessP10;
            set
            {
                _descriptionProcessP10 = value;
                OnPropertyChanged(() => DescriptionProcess_p10);
            }
        }
    }
}
