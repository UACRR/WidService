using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsViewComponentLibrary.ControlsHelpers.Base;

namespace IpsViewComponentLibrary.ControlsHelpers.Derived
{
    public class ViewLicenseBRHelper : LicenseBRHelper
    {
        public override Task<bool> SaveAsync()
        {
            // empty method
            return new Task<bool>(() => true);
        }
    }
}
