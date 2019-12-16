using LanguageLibrary.Model;

namespace LanguageService.Controls.CreateLanguage
{
    public class CreateLanguageModel
    {
        public string SpecificationCode { get; set; }
        public string LanguageName { get; set; }
        public LanguageInfo LanguageInfo { get; set; }
    }
}
