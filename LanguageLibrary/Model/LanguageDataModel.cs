using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LanguageLibrary.Model
{
    public class LanguageDataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _containerName;
        public string ContainerName
        {
            get => _containerName;
            set
            {
                _containerName = value;
                OnPropertyChanged(nameof(ContainerName));
            }
        }

        private string _propertyName;
        public string PropertyName
        {
            get => _propertyName;
            set
            {
                _propertyName = value;
                OnPropertyChanged(nameof(PropertyName));
            }
        }

        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _defaultContent;
        public string DefaultContent
        {
            get => _defaultContent;
            set
            {
                _defaultContent = value;
                OnPropertyChanged(nameof(DefaultContent));
            }
        }
    }
}
