using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsTestExp
{
    public interface IDicRow
    {
        int Code { get; }
        int? ParentCode { get; }
        string NameEn { get; set; }
        string Nameuk { get; set; }
        string NameRu { get; set; }

    }

    internal class DicKind : IDicRow
    {
        private CopyrightKind _body;
        public DicKind(CopyrightKind body)
        {
            _body = body;
        }
        public int Code => (int)_body.CrGroupCode * 100 + _body.CodeI;

        public int? ParentCode => (int)_body.CrGroupCode*100;

        public string NameEn { get => getNameTrRow("En").Name; set => getNameTrRow("En").Name = value; }
        public string Nameuk { get => getNameTrRow("Uk").Name; set => getNameTrRow("Uk").Name = value; }
        public string NameRu { get => getNameTrRow("Ru").Name; set => getNameTrRow("Ru").Name = value; }

        private CopyrightKindTr getNameTrRow(string lang)
        {
            CopyrightKindTr trRow = _body.CopyrightKindTr.Where(row => row.Lang == lang).SingleOrDefault();
            if (trRow != null) return trRow;
            trRow = new CopyrightKindTr { CodeI = _body.CodeI, Lang = lang, Name = "" };
            _body.CopyrightKindTr.Add(trRow);
            return trRow;
        }
    }

    internal class DicGroup : IDicRow
    {
        private CrkindGroup _body;

        public List<IDicRow> getDicItems()
        {
            List<IDicRow> list = new List<IDicRow> { this };
            var listKind = from item in _body.CopyrightKind
                           select new DicKind(item);
            list.AddRange(listKind);
            return list;
        }

        public DicGroup(CrkindGroup body)
        {
            _body = body;
        }
        public int Code => _body.CodeI * 100;

        public int? ParentCode => null;

        public string NameEn { get => getNameTrRow("En").Name; set => getNameTrRow("En").Name = value; }
        public string Nameuk { get => getNameTrRow("Uk").Name; set => getNameTrRow("Uk").Name = value; }
        public string NameRu { get => getNameTrRow("Ru").Name; set => getNameTrRow("Ru").Name = value; }

        private CrkindGroupTr getNameTrRow(string lang)
        {
            CrkindGroupTr trRow = _body.CrkindGroupTr.Where(row => row.Lang == lang).SingleOrDefault();
            if (trRow != null) return trRow;
            trRow = new CrkindGroupTr { CodeI = _body.CodeI, Lang = lang, Name = "" };
            _body.CrkindGroupTr.Add(trRow);
            return trRow;
        }
    }

}
