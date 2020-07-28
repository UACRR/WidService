using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.DataBindingModel
{
    public class ChangeAmountBindingModel
    {
        public ChangeAmountBindingModel()
        {
            
        }

        public ChangeAmountBindingModel(decimal amount)
        {
            Amount = amount;
        }

        public ChangeAmountBindingModel(decimal? amount)
        {
            Amount = amount;
        }

        public decimal? Amount { get; set; }
    }
}
