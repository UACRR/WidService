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
        }

        public CopyrightRequestLD CopyrightRequestLD { get; set; }
        public RegisterCurrencyChangeLD RegisterCurrencyChangeLD { get; set; }
        public RegisterItemCCIDTypeLD  RegisterItemCcidTypeLD { get; set; }
    }
}
