namespace LanguageLibrary.Model.LanguageDataNested
{
    public class RegisterCurrencyChangeLD
    {
        public RegisterCurrencyChangeLD()
        {
            UITitle = new LanguageItem();
            UICurrency = new LanguageItem();
        }

        public LanguageItem UITitle { get; set; }
        public LanguageItem UICurrency { get; set; }
    }
}
