namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public interface IPlacesControl
    {
        /// <summary>
        /// Джерело даних майданчиків/приміщень
        /// </summary>
        object BusinessPlaceDataSource { get; set; }

        /// <summary>
        /// Тип приміщення
        /// </summary>
        MeasurementOfPlaces PlaceType { get; set; }
        
        bool ButtonsVisible { get; set; }
    }
}