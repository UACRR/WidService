namespace LanguageLibrary.Model
{
    public class LanguageItem
    {
        private string _content;
        public string Content
        {
            get
            {
                if (string.IsNullOrEmpty(_content))
                    return OriginalContent;

                return _content;
            }
            internal set => _content = value;
        }

        public string Description { get; internal set; }

        public string OriginalContent { get; internal set; }
    }
}
