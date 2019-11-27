using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Data
{
    public class ApplicationSettings
    {
        private static ApplicationSettings _applicationSettings;

        private ApplicationSettings()
        {
            ApplicationCulture = new CultureInfo("uk-UA");
        }

        public static ApplicationSettings GetInstance()
        {
            if (_applicationSettings == null)
                _applicationSettings = new ApplicationSettings();

            return _applicationSettings;
        }

        public CultureInfo ApplicationCulture { get; private set; }
    }
}
