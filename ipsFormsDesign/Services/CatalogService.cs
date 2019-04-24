using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CatalogService
    {
        private ApiConnector _apiConnector;
        private static CatalogService _service;

        private CatalogService()
        {
            _apiConnector = new ApiConnector();
        }

        public static CatalogService GetInstance()
        {
            if (_service == null)
                _service = new CatalogService();

            return _service;
        }
    }
}
