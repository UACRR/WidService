using ipsFormsDesign.Model;
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

        public int MdId { get; set; }
        public int LicId { get; set; }
        public int? LicVersion { get; set; }

        public int? ObjId { get; set; }
        public string ItemName { get; set; }
        public int? CategoryCode { get; set; }
        public string Performer { get; set; }
        public string AuthorMusic { get; set; }
        public string AuthorText { get; set; }
        public int? CountUse { get; set; }
        public TimeSpan? DurationUse { get; set; }
        public TimeSpan? DurationItem { get; set; }
        public int CodeItem { get; set; }

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
        private bool _isAuto;
        public bool IsAuto
        {
            get { return _isAuto; }
            set
            {
                _isAuto = value;
                OnPropertyChanged(nameof(IsAuto));
            }
        }

        public RegisterItemViewModel() { }

        public RegisterItemViewModel(MusicalDesign musicalDesign)
        {

            ItemName = musicalDesign.ObjName;
            AuthorMusic = musicalDesign.NameMusician;
            AuthorText = musicalDesign.AuthorText;
            CountUse = musicalDesign.NumbPerfom;
            DurationItem = musicalDesign.Duration;
            Performer = musicalDesign.NameSinger;
            MdId = musicalDesign.MdId;
            LicId = musicalDesign.LicId;
            //LicVersion = musicalDesign.LicVersion;

            if (musicalDesign.Obj != null)
            {
                SetObjectData(
                    musicalDesign.Objid,
                    musicalDesign.Obj.Name,
                    musicalDesign.Obj.Author,
                    musicalDesign.Obj.Performer,
                    musicalDesign.Obj.MediaTrack?.Duration,
                    resetIsAuto: false
                );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetObjectData(int? objId, string name, string authors, string performers, TimeSpan? duration, bool resetIsAuto = true)
        {
            if (objId.HasValue)
            {
                ObjId = objId.Value;
                ObjectName = name;
                ObjectAuthors = authors;
                ObjectPerformers = performers;
                ObjectDuration = duration;

                if (resetIsAuto)
                    IsAuto = false;
            }
            else
            {
                ClearObjectData();
            }
        }

        public void ClearObjectData()
        {
            ObjId = null;
            ObjectName = null;
            ObjectAuthors = null;
            ObjectPerformers = null;
            ObjectDuration = null;
            IsAuto = false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<RegisterExtra> RegisterExtraList { get; set; } = new List<RegisterExtra>();
    }
}
