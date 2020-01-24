using System;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    /*
     *  передані права вступають в силу мінімум з наступного дня
     */
    public class DateProperty : ViewModelBase
    {
        public DateProperty()
        {
            DateBegin = _minDate;
        }

        private readonly DateTime _minDate = DateTime.Today.AddDays(1);
        private readonly DateTime _maxDate = new DateTime(3000,01,01);

        private void CheckBetween(ref DateTime? date, DateTime? value)
        {
            if (value < _minDate)
                date = _minDate;
            else if (value > _maxDate)
                date = _maxDate;
            else
                date = value;
        }

        private void CheckValidRange()
        {
            if (_dateBegin == _maxDate)
                _dateBegin = _maxDate.AddDays(-1);

            if (_dateBegin >= _dateEnd)
                _dateEnd = _dateBegin.Value.AddDays(1);
        }

        private DateTime? _dateBegin;
        public DateTime? DateBegin
        {
            get => _dateBegin;
            set
            {
                CheckBetween(ref _dateBegin, value);
                CheckValidRange();
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
                CheckValidRange();
                OnPropertyChanged(() => DateEnd);
            }
        }
    }
}
