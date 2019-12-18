namespace LanguageLibrary.Model.LanguageDataNested
{
    public class LauncherLD
    {
        public LauncherLD()
        {
            RH_OR = new LanguageItem();
            ReportsAndRoyalty = new LanguageItem();
            AnalyticsAndReports = new LanguageItem();
            OperativeReporting = new LanguageItem();
            Clients_WP = new LanguageItem();
            Theatres_WP = new LanguageItem();
            Partner_WP = new LanguageItem();
            FixationOfViolations = new LanguageItem();
            SystemDictionaries = new LanguageItem();
            AnketaOfTheCompany = new LanguageItem();
        }

        public LanguageItem RH_OR { get; set; }
        public LanguageItem ReportsAndRoyalty { get; set; }
        public LanguageItem AnalyticsAndReports { get; set; }
        public LanguageItem OperativeReporting { get; set; }
        public LanguageItem Clients_WP { get; set; }
        public LanguageItem Theatres_WP { get; set; }
        public LanguageItem Partner_WP { get; set; }
        public LanguageItem FixationOfViolations { get; set; }
        public LanguageItem SystemDictionaries { get; set; }
        public LanguageItem AnketaOfTheCompany { get; set; }
    }
}
