namespace IPSViewComponentLibraryWPF.Controls.SearchControl.Model
{
    public class SearchItem
    {
        public SearchItem() { }

        public SearchItem(string key, string name)
        {
            KeyField = key;
            NameField = name;
        }

        public string KeyField { get; set; }
        public string NameField { get; set; }
    }
}