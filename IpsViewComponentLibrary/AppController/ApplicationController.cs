using ipsFormsDesign.EventAggregator;

namespace IpsViewComponentLibrary.AppController
{
    public class ApplicationController
    {
        private static ApplicationController _instance;
        public static ApplicationController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationController();
                }

                return _instance;
            }
        }

        private IEventAggregator _ea;
        public IEventAggregator EventAggregator
        {
            get
            {
                if (_ea == null)
                {
                    _ea = new EventAggregator();
                }

                return _ea;
            }
        }
    }
}
