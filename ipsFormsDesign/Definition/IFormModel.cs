using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsFormsDesign.Definition
{
    public interface IFormModel<T>
    {
        Task<List<T>> getData();
    }
}
