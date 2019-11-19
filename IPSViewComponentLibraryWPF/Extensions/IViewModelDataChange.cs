namespace IPSViewComponentLibraryWPF.Extensions
{
    public interface IViewModelDataChange
    {
        /// <summary>
        /// Reset data as set data from Object to ViewModel
        /// </summary>
        void ResetData();
        /// <summary>
        /// Update data as set data from ViewModel to Object
        /// </summary>
        void UpdateData();
    }
}