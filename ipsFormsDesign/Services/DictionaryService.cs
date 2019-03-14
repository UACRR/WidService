using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class DictionaryService
    {
        private ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "dictionary/";

        // CopyRightKind BEGIN ********************
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
        public GenreType GetKlR030(int id)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.GetItemById<GenreType>(url, id.ToString());
        }

        public GenreType CreateKlR030(GenreType sors)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.NewItemWithResult(url, sors);
        }

        public GenreType UpdateKlR030(GenreType sors)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteKlR030(int id)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.DeleteItem(url, id.ToString());
        }

        // TypePlace BEGIN ********************
        public TypePlace GetTypePlace(int id)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.GetItemById<TypePlace>(url, id.ToString());
        }

        public TypePlace CreateTypePlace(TypePlace sors)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.NewItemWithResult(url, sors);
        }

        public TypePlace UpdateTypePlace(TypePlace sors)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.UpdateItemWithResult(url, sors.CodeI.ToString(), sors);
        }

        public bool DeleteTypePlace(int id)
        {
            string url = string.Concat(_prefix, "extra/klr030");
            return _webApi.DeleteItem(url, id.ToString());
        }
    }
}
