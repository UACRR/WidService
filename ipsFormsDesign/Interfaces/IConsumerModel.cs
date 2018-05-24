using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    /*
     +		array	{[
  {
    "custId": 134,
    "innokpo": "3334445557",
    "name": "Ресторанний комплекс на Дніпрі",
    "countAgree": 1,
    "undistribamount": 0.0
  },
  {
    "custId": 135,
    "innokpo": "09876543",
    "name": "Дрім Тоун",
    "countAgree": 1,
    "undistribamount": 0.0
  }
]}	Newtonsoft.Json.Linq.JArray

         */
    public class ConsumerMainView
    {
        public int custId { get; set; }
        public string innokpo { get; set; }
        public string name { get; set;  }
        public int countAgree { get; set; }
        public decimal undistribamount { get; set; }
    }
    public interface IConsumerModel : IModel
    {
        IList<ConsumerMainView> getMainView();
    }
}
