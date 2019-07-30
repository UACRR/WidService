using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.ViewModels.ObjectsRight;
using IpsCommonTypes.Types;
using IpsCommonTypes.Views;

namespace ipsFormsDesign.Dictionary
{
    public class RegisterItemViewModel : INotifyPropertyChanged
    {
        private const string WIDSource = "WID";

        public int RegId { get; set; }
        public int RegIitemId { get; set; }

        public int MdId { get; set; }
        public int LicId { get; set; }
        public int? LicVersion { get; set; }

        public string Genre { get; set; }
        public decimal? Rate { get; set; }

        public string ItemName { get; set; }
        public int? CategoryCode { get; set; }
        public string Performer { get; set; }
        public string AuthorMusic { get; set; }
        public string AuthorText { get; set; }
        public int? CountUse { get; set; }
        public TimeSpan? DurationUse { get; set; }
        public TimeSpan? DurationItem { get; set; }
        public int CodeItem { get; set; }

        private int? _objId;
        public int? ObjId
        {
            get => _objId;
            set
            {
                _objId = value;
                OnPropertyChanged(nameof(ObjId));
            }
        }

        private int? _wic;
        public int? Wic
        {
            get => _wic;
            set
            {
                ObjectSource = value.HasValue ? WIDSource : string.Empty;
                _wic = value;
            }
        }

        private string _objectName;
        public string ObjectName
        {
            get => _objectName;
            set
            {
                _objectName = value;
                OnPropertyChanged(nameof(ObjectName));
            }
        }

        private string _objectPerformers;
        public string ObjectPerformers
        {
            get => _objectPerformers;
            set
            {
                _objectPerformers = value;
                OnPropertyChanged(nameof(ObjectPerformers));
            }
        }

        private string _objectAuthors;
        public string ObjectAuthors
        {
            get => _objectAuthors;
            set
            {
                _objectAuthors = value;
                OnPropertyChanged(nameof(ObjectAuthors));
            }
        }

        private TimeSpan? _objectDurations;
        public TimeSpan? ObjectDuration
        {
            get => _objectDurations;
            set
            {
                _objectDurations = value;
                OnPropertyChanged(nameof(ObjectDuration));
            }
        }

        public string ObjectSource { get; set; }
        public double? SumAllTogether { get; set; }

        private bool _isAuto;
        public bool IsAuto
        {
            get => _isAuto;
            set
            {
                _isAuto = value;
                OnPropertyChanged(nameof(IsAuto));
            }
        }

        public int? GenreType { get; set; }

        public RegisterItemFix RegisterItemFix { get; set; }

        public List<RegisterExtra> RegisterExtraList { get; set; } = new List<RegisterExtra>();

        public RegisterItemViewModel()
        {
            RegisterItemFix = new RegisterItemFix();
        }

        public RegisterItemViewModel(MusicalDesign musicalDesign) : this()
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

        public void SetObjectData(object obj, bool resetIsAuto = true)
        {
            if (obj is ObjectRightMainView objectRight)
            {
                ObjId = objectRight.ObjId;
                ObjectName = objectRight.Name;
                ObjectAuthors = objectRight.Author;
                ObjectPerformers = objectRight.Performer;
                Wic = objectRight.Wic;

                if (resetIsAuto)
                    IsAuto = false;
            }
            else if (obj is RegisterItemViewModel registerItem)
            {
                ObjId = registerItem.ObjId;
                ObjectName = registerItem.ObjectName;
                ObjectAuthors = registerItem.ObjectAuthors;
                ObjectPerformers = registerItem.ObjectPerformers;
                Wic = registerItem.Wic;
            }
            else if (obj is ObjectRightWithWID objectRightWithWid)
            {

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
    }
}
