using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.Utilities
{
    /// <summary>
    /// Класс для виводу Успіхи чи Помилки для Діалогів
    /// </summary>
    public class SuccessErrorMsg
    {
        public string Success { get; }
        public string Error { get; }
        public SuccessErrorMsg( string successMsg, string errorMsg )
        {
            Success = successMsg;
            Error = errorMsg;
        }
    }
}
