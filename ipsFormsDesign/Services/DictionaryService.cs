using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class DictionaryService
    {
        private readonly ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "dictionary/";
        private static DictionaryService _service;

        private readonly Dictionary<Type, string> _urls = new Dictionary<Type, string>
        {
            {typeof(CopyrightKind), "" },

        };

        private DictionaryService() { }

        public static DictionaryService GetInstance()
        {
            if (_service == null)
                _service = new DictionaryService();

            return _service;
        }

        public T GetObj<T>(int id)
        {
            string url = string.Concat(_prefix, "extra/copyrightkind");
            url = $"{_prefix}extra/{_urls[typeof(T)]}";
            return _webApi.GetItemById<T>(url, id.ToString());
        }

        public T UpdateObj<T>(T sors, int codeI) where T:class
        {
            if (!_urls.ContainsKey(typeof(T)))
                throw new ArgumentException("");

            string url = string.Concat(_prefix, "extra/copyrightkind");
            url = $"{_prefix}extra/{_urls[typeof(T)]}";
            return _webApi.UpdateItemWithResult(url, codeI.ToString(), sors);
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

        // CopyRightKind BEGIN ********************

        public List<CopyrightKind> GetCopyrightKindList(string url)
        {
            var result = _webApi.GetList<CopyrightKind>(url);
            return result;
        }

        public CopyrightKind GetCopyrightKind( int id )
        {
            string url = string.Concat( _prefix, "extra/copyrightkind");
            return _webApi.GetItemById<CopyrightKind>(url, id.ToString());
        }

        public CopyrightKind CreateCopyrightKind( CopyrightKind sors )
        {
            string url = string.Concat(_prefix, "extra/copyrightkind");
            return _webApi.NewItemWithResult(url, sors);
        }

        public CopyrightKind UpdateCopyrightKind(CopyrightKind sors)
        {
            string url = string.Concat(_prefix, "extra/copyrightkind");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteCopyrightKind(int id)
        {
            string url = string.Concat(_prefix, "extra/copyrightkind");
            return _webApi.DeleteItem(url, id.ToString());
        }

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
            string url = string.Concat(_prefix, "extra/klr030");
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
