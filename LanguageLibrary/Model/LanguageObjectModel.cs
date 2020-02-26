using LanguageLibrary.Model.LanguageDataNested;

namespace LanguageLibrary.Model
{
    public sealed class LanguageObjectModel
    {
        public LanguageObjectModel()
        {
            CopyrightRequestLD = new CopyrightRequestLD();
            RegisterCurrencyChangeLD = new RegisterCurrencyChangeLD();
            RegisterItemCcidTypeLD = new RegisterItemCCIDTypeLD();
            LauncherLD = new LauncherLD();
            SmRoPermitLD = new SmRoPermitLD();
        }

        public CopyrightRequestLD CopyrightRequestLD { get; set; }
        public RegisterCurrencyChangeLD RegisterCurrencyChangeLD { get; set; }
        public RegisterItemCCIDTypeLD  RegisterItemCcidTypeLD { get; set; }
        public LauncherLD LauncherLD { get; set; }
        public SmRoPermitLD SmRoPermitLD { get; set; }
    }
}
