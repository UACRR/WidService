using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;
using LanguageService.Model;
using Telerik.Windows.Controls;

namespace LanguageService.ViewModel
{
    public class LanguageServiceViewModel : ViewModelBase
    {
        public LanguageServiceViewModel()
        {
            
        }

        #region * * * BEHAVIOR PROPERTIES * * *

        private XmlLanguage _language;
        public XmlLanguage Language
        {
            get
            {
                if (_language == null)
                    return XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);

                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged(() => Language);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        private LanguageCompletenessModel _currentLanguageCompleteness;
        public LanguageCompletenessModel CurrentLanguageCompleteness
        {
            get => _currentLanguageCompleteness;
            set
            {
                _currentLanguageCompleteness = value;
                OnPropertyChanged(() => CurrentLanguageCompleteness);
            }
        }

        private ObservableCollection<LanguageInfoModel> _languagesItemSource;
        public ObservableCollection<LanguageInfoModel> LanguagesItemSource
        {
            get => _languagesItemSource;
            set
            {
                _languagesItemSource = value;
                OnPropertyChanged(() => LanguagesItemSource);
            }
        }

        private LanguageInfoModel _currentLanguage;
        public LanguageInfoModel CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                _currentLanguage = value;
                OnPropertyChanged(() => CurrentLanguage);
            }
        }

        #endregion

        #region * * * METHODS * * *



        #endregion

        #region * * * COMMANDS * * *



        #endregion

    }
}
