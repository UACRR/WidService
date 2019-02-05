using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Interfaces
{
    public interface IUniqueChecker
    {
        bool CheckOKPOIsUnique(string okpo, int? custId);
        bool CheckIPIIsUnique(string ipi, int? custId);
        bool CheckINNIsUnique(string okpo, int? custId);
    }
}
