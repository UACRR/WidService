using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Dictionary;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CommunityService
    {
        private readonly ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "community/";

        /// <summary>
        /// Отримати VIEW у вигляді списку елементів 
        /// </summary>
        /// <typeparam name="T">Бажаний тип</typeparam>
        /// <param name="nameView">назва View</param>
        /// <returns>необхідна View</returns>
        public List<T> GetView<T>(Type typeResult, string viewName, int? custId = null) where T:class
        {
            string url = _prefix;
            List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("viewName", viewName) };
            if (custId != null)
                param.Add(new KeyValuePair<string, string>("custId", custId.ToString()));
            var list = _webApi.GetTypedList(typeResult, url, param.ToArray());

            var typeList = new List<T>();
            foreach (var temp in list)
                typeList.Add(temp as T);
            return typeList;
        }

    }
}
