using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleSearch
{
    public class SuccessSearchParams
    {
         public int         Id                   {get; set;}
         public int         CustId               {get; set;}
         public string      LocalAuthor         {get; set;}
         public string      AppleName         {get; set;}
         public string      AppleAuthor       {get; set;}
         public string      ApplePerformer    {get; set;}
         public DateTime    LastSearchedAt  {get; set;}
    }
}
