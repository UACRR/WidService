namespace IpsCommonTypes.Enums
{
    /// <summary>
    /// Типи документів Великих прав для запиту
    /// </summary>
    public enum ConsumersBigRightCategoryFilter
    {
        None = 0,
        // General agreement
        GenAgreement = 2,
        // License agreement
        License = 3,
        // Request
        Request = 4,
        // Reference
        Reference = 5,
        // All documents
        All
    }
}