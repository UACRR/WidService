namespace LanguageLibrary.Model.LanguageDataNested
{
    public class CopyrightRequestLD
    {
        public CopyrightRequestLD()
        {
            UIbtnSave = new LanguageItem();
            UIbtnCancel = new LanguageItem();
        }

        public LanguageItem UIbtnSave { get; set; }
        public LanguageItem UIbtnCancel { get; set; }
    }
}
