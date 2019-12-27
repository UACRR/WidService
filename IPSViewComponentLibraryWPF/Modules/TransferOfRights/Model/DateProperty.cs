using System;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class DateProperty : ViewModelBase
    {
        private readonly DateTime? _minDate = new DateTime(1900,01,01);
        private readonly DateTime? _maxDate = new DateTime(3000,01,01);

        private void CheckBetween(ref DateTime? date, DateTime? value)
        {
            if (value < _minDate)
                date = _minDate;

            if (value > _maxDate)
                date = _maxDate;
        }

        private DateTime? _dateBegin;
        public DateTime? DateBegin
        {
            get => _dateBegin;
            set
            {
                CheckBetween(ref _dateBegin, value);
                OnPropertyChanged(() => DateBegin);
            }
        }

        private DateTime? _dateEnd;
        public DateTime? DateEnd
        {
            get => _dateEnd;
            set
            {
                CheckBetween(ref _dateEnd, value);
                OnPropertyChanged(() => DateEnd);
            }
        }
    }
}
