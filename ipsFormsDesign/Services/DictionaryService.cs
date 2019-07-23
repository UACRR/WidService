using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class DictionaryService
    {
        private readonly ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "dictionary/";
        private const string _prefixExtra = "dictionary/extra";

        private static DictionaryService _service;

        private readonly Dictionary<Type, string> _urls = new Dictionary<Type, string>
        {
            {typeof(CopyrightKind), "copyrightkind"},
            {typeof(Country), "country"},
            {typeof(CreativeRoleType), "creativeroletype"},
            {typeof(GenreType), "genretype"},
            {typeof(KlR030), "kl_r030"},
            {typeof(SystemConstant), "systemconstant"},
            {typeof(TypePlace), "typeplace"},
            {typeof(RelGenrePercent), "relgenrepercent"},
        };

        private DictionaryService() { }

        public static DictionaryService GetInstance()
        {
            if (_service == null)
                _service = new DictionaryService();

            return _service;
        }

        public AnketaDictionaties GetAnketaDictionaties()
        {
            var anketaDic = _webApi.GetItemById<AnketaDictionaties>("dictionary", "anketa");
            return anketaDic;
        }

        public ObjectRightDictionaries GetObjectRightDictionaries()
        {
            var dictionaries = _webApi.GetItemById<ObjectRightDictionaries>("dictionary", "objectright");
            return dictionaries;
        }

        #region * * * ПРОСТІ ДОВІДНИКИ * * *

        /// <summary>
        /// Отримати список записів простого довідника
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<DictBaseTypeI> GetSimpleDictionaryList(string url)
        {
            var result = _webApi.GetList<DictBaseTypeI>(url);
            return result;
        }

        /// <summary>
        /// Додати запис до простого довідника
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CreateSimpleDictionaryRecord(string url, DictBaseTypeI data)
        {
            var result = _webApi.NewItem(url, data);
            return result;
        }

        /// <summary>
        /// Оновити запис простого довідника
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateSimpleDictionaryRecord(string url, DictBaseTypeI data)
        {
            bool result = _webApi.UpdateItem(url, data.CodeI.ToString(), data);
            return result;
        }

        /// <summary>
        /// Видалити запис із простого довідника
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSimpleDictionaryRecord(string url, string id)
        {
            bool result = _webApi.DeleteItem(url, id);
            return result;
        }

        #endregion

        #region * * * СКЛАДНІ ДОВІДНИКИ * * *

        /// <summary>
        /// Отримати список записів складного довідника
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<T> GetExtraDictionaryList<T>(string url)
        {
            var result = _webApi.GetList<T>(url);
            return result;
        }

        /// <summary>
        /// Додати запис до складного довідника
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sors"></param>
        /// <returns></returns>
        public bool CreateExtraDictionaryRecord<T>(T sors) where T : class
        {
            if (!_urls.ContainsKey(typeof(T)))
                return false;

            string url = $"{_prefixExtra}/create/{_urls[typeof(T)]}";
            return _webApi.NewItem(url, sors);
        }

        /// <summary>
        /// Оновити запис складного довідника
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool UpdateExtraDictionaryRecord<T>(T source) where T : class
        {
            if (!_urls.ContainsKey(typeof(T)))
                return false;

            string url = $"{_prefixExtra}/update/{_urls[typeof(T)]}";
            return _webApi.UpdateItem(url, null, source);
        }

        /// <summary>
        /// Видалити запис із складного довідника
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteExtraDictionaryRecord<T>(int id) where T : class
        {
            if (!_urls.ContainsKey(typeof(T)))
                return false;

            string url = $"{_prefixExtra}/delete/{_urls[typeof(T)]}";
            return _webApi.DeleteItem(url, id.ToString());
        }

        /// <summary>
        /// Видалити запис із складного довідника
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool DeleteExtraDictionaryRecord<T>(string data) where T : class
        {
            if (!_urls.ContainsKey(typeof(T)))
                return false;

            string url = $"{_prefixExtra}/delete/{_urls[typeof(T)]}/{data}";
            return _webApi.DeleteItem(url);
        }

        #endregion

        // TODO: повидаляти  . . . .
        // Country BEGIN ********************
        public Country GetCountry(int id)
        {
            string url = string.Concat(_prefix, "extra/country");
            return _webApi.GetItemById<Country>(url, id.ToString());
        }

        public Country CreateCountry(Country sors)
        {
            string url = string.Concat(_prefix, "extra/country");
            return _webApi.NewItemWithResult(url, sors);
        }

        public Country UpdateCountry(Country sors)
        {
            string url = string.Concat(_prefix, "extra/country");
            return _webApi.UpdateItemWithResult(url, sors.CountryCode, sors);
        }

        public bool DeleteCountry(int id)
        {
            string url = string.Concat(_prefix, "extra/country");
            return _webApi.DeleteItem(url, id.ToString());
        }

        // CreativeRoleType BEGIN ********************
        public CreativeRoleType GetCreativeRoleType(int id)
        {
            string url = string.Concat(_prefix, "extra/creativeroletype");
            return _webApi.GetItemById<CreativeRoleType>(url, id.ToString());
        }

        public CreativeRoleType CreateCreativeRoleType(CreativeRoleType sors)
        {
            string url = string.Concat(_prefix, "extra/creativeroletype");
            return _webApi.NewItemWithResult(url, sors);
        }

        public CreativeRoleType UpdateCreativeRoleType(CreativeRoleType sors)
        {
            string url = string.Concat(_prefix, "extra/creativeroletype");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteCreativeRoleType(int id)
        {
            string url = string.Concat(_prefix, "extra/creativeroletype");
            return _webApi.DeleteItem(url, id.ToString());
        }

        // GenreType BEGIN ********************
        public GenreType GetGenreType(int id)
        {
            string url = string.Concat(_prefix, "extra/genretype");
            return _webApi.GetItemById<GenreType>(url, id.ToString());
        }

        public GenreType CreateGenreType(GenreType sors)
        {
            string url = string.Concat(_prefix, "extra/genretype");
            return _webApi.NewItemWithResult(url, sors);
        }

        public GenreType UpdateGenreType(GenreType sors)
        {
            string url = string.Concat(_prefix, "extra/genretype");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteGenreType(int id)
        {
            string url = string.Concat(_prefix, "extra/genretype");
            return _webApi.DeleteItem(url, id.ToString());
        }

        // KlR030 BEGIN ********************
        public KlR030 GetKlR030(int id)
        {
            string url = string.Concat(_prefix, "extra/kl_r030");
            return _webApi.GetItemById<KlR030>(url, id.ToString());
        }

        public KlR030 CreateKlR030(KlR030 sors)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.NewItemWithResult(url, sors);
        }

        public KlR030 UpdateKlR030(KlR030 sors)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.UpdateItemWithResult(url, sors.R030, sors);
        }

        public bool DeleteKlR030(int id)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.DeleteItem(url, id.ToString());
        }

        // SystemConstant BEGIN ********************
        public SystemConstant GetSystemConstant(int id)
        {
            string url = string.Concat(_prefix, "extra/systemconstant");
            return _webApi.GetItemById<SystemConstant>(url, id.ToString());
        }

        public SystemConstant CreateSystemConstant(SystemConstant sors)
        {
            string url = string.Concat(_prefix, "extra/systemconstant");
            return _webApi.NewItemWithResult(url, sors);
        }

        public SystemConstant UpdateSystemConstant(SystemConstant sors)
        {
            string url = string.Concat(_prefix, "extra/systemconstant");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteSystemConstant(int id)
        {
            string url = string.Concat(_prefix, "extra/systemconstant");
            return _webApi.DeleteItem(url, id.ToString());
        }

        // TypePlace BEGIN ********************
        public TypePlace GetTypePlace(int id)
        {
            string url = string.Concat(_prefix, "extra/typeplace");
            return _webApi.GetItemById<TypePlace>(url, id.ToString());
        }

        public TypePlace CreateTypePlace(TypePlace sors)
        {
            string url = string.Concat(_prefix, "extra/typeplace");
            return _webApi.NewItemWithResult(url, sors);
        }

        public TypePlace UpdateTypePlace(TypePlace sors)
        {
            string url = string.Concat(_prefix, "extra/typeplace");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteTypePlace(int id)
        {
            string url = string.Concat(_prefix, "extra/typeplace");
            return _webApi.DeleteItem(url, id.ToString());
        }
    }
}
