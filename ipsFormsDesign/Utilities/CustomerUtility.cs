using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Utilities
{
    public static class CustomerUtility
    {
        public static string CustomerName(Customer customer)
        {
            if (customer.CustType == 3) // Jur
                return customer.Company.AnketaCompany.Where(rec => rec.Version == customer.AnkVersion).FirstOrDefault()?.Name;
            else
            {
                var anketa = customer.Person.AnketaPerson.Where(rec => rec.Version == customer.AnkVersion).FirstOrDefault();
                return $"{anketa.FirstName} {anketa.SurName} {anketa.LastName}";
            }
        }
    }
}
