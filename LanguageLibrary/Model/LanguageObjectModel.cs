using LanguageLibrary.Model.LanguageDataNested;

namespace LanguageLibrary.Model
{
    public sealed class LanguageObjectModel
    {
        public CopyrightRequestLD CopyrightRequestLD { get; set; } = new CopyrightRequestLD();
        public RegisterCurrencyChangeLD RegisterCurrencyChangeLD { get; set; } = new RegisterCurrencyChangeLD();
        public RegisterItemCCIDTypeLD  RegisterItemCcidTypeLD { get; set; } = new RegisterItemCCIDTypeLD();
        public LauncherLD LauncherLD { get; set; } = new LauncherLD();
        public SmRoPermitLD SmRoPermitLD { get; set; } = new SmRoPermitLD();
        public SearchControlLD SearchControlLD { get; set; } = new SearchControlLD();
        public CopyrightAdminWorkplaceLD CopyrightAdminWorkplaceLD { get; set; } = new CopyrightAdminWorkplaceLD();
        public ReportWorkplaceLD ReportWorkplaceLD { get; set; } = new ReportWorkplaceLD();
        public RightholdersListLD RightholdersListLD { get; set; } = new RightholdersListLD();
        public ObjectsRightListLD ObjectsRightListLD { get; set; } = new ObjectsRightListLD();
        public CommunitiesListLD CommunitiesListLD { get; set; } = new CommunitiesListLD();
        public ReportsSRListLD ReportsSRListLD { get; set; } = new ReportsSRListLD();
        public LicenseBRListLD LicenseBRListLD { get; set; } = new LicenseBRListLD();
    }
}
