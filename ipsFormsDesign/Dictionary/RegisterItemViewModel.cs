using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class RegisterItemViewModel : INotifyPropertyChanged
    {
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int? ObjId { get; set; }
        public string ItemName { get; set; }
        public int? CategoryCode { get; set; }
        public string Performer { get; set; }
        public string AuthorMusic { get; set; }
        public string AuthorText { get; set; }
        public int? CountUse { get; set; }
        public TimeSpan? DurationUse { get; set; }
        public TimeSpan? DurationItem { get; set; }

        private string _objectName;
        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                _objectName = value;
                OnPropertyChanged(nameof(ObjectName));
            }
        }
        private string _objectPerformers;
        public string ObjectPerformers
        {
            get { return _objectPerformers; }
            set
            {
                _objectPerformers = value;
                OnPropertyChanged(nameof(ObjectPerformers));
            }
        }
        private string _objectAuthors;
        public string ObjectAuthors
        {
            get { return _objectAuthors; }
            set
            {
                _objectAuthors = value;
                OnPropertyChanged(nameof(ObjectAuthors));
            }
        }
        private TimeSpan? _objectDurations;
        public TimeSpan? ObjectDuration
        {
            get { return _objectDurations; }
            set
            {
                _objectDurations = value;
                OnPropertyChanged(nameof(ObjectDuration));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetObjectData(int? objId, string name, string authors, string performers, TimeSpan? duration)
        {
            ObjId = objId;

            if (objId != null)
            {
                ObjectName = name;
                ObjectAuthors = authors;
                ObjectPerformers = performers;
                ObjectDuration = duration;
            }
            else
            {
                ObjectName = null;
                ObjectAuthors = null;
                ObjectPerformers = null;
                ObjectDuration = null;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
