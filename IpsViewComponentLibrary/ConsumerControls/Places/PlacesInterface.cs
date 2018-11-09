using System.Drawing;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public interface IPlacesControl
    {
        object BusinessPlaceDataSource { get; set; }
        MeasurementOfPlaces PlaceType { get; set; }
        bool ButtonsVisible { get; set; }
    }
}