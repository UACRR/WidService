using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public class RespFilePresenter
    {
        private const string _htmlHead = @"
<head>
    <meta charset='utf-8' />
    <title></title>
    <style>
        body {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-top: 0;
            margin-bottom: 0;
        }        
        h1 {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            text-decoration: underline;
            margin-top: 0;
            margin-bottom: 0;
        }
        
        h2 {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-left: 20px;
            margin-top: 10px;
            margin-bottom: 0;
        }
        h3 {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-left: 40px;
            margin-top: 0;
            margin-bottom: 0;
        }
        i {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
        }
        .error1 {
            margin-left: 20px;
            color: red;
        }
        .error2 {
            margin-left: 40px;
            color: red;
        }
       .label {
            font-weight: bold;
        }
        .labelPercent {
            font-style: italic;
            margin-left: 20px;
         }
    </style>
</head>
";

        public class RecBase
        {
            public int RecSeqNr { get; set; }
            public string RecType { get; set; }
            public List<string> ErrMsg { get; set; }

            public virtual string GetHtml() => "";

            public virtual string GerErrCssClass() => "";

            public string GetHtmlWithErrors() {
                var html = GetHtml();
                ErrMsg.ForEach(x =>
                {
                    html += $"<div class='{GerErrCssClass()}'>{x}</div>\r\n";
                });
                return html;
            }

        }

        public class Ssr : RecBase
        {
            public bool IsPer { get; set; }
            public decimal Shares { get; set; }
            public override string GerErrCssClass() => "error2";
            public override string GetHtml()
            {
                var lab = IsPer ? "Проценти пуб" : "Проценти мех";
                return $"<div><span class='labelPercent'>{lab}</span>: {Shares}</div>\r\n";
            }
        }

        public class Osr : RecBase
        {
            public bool IsPer { get; set; }
            public decimal Shares { get; set; }
            public override string GerErrCssClass() => "error2";
            public override string GetHtml()
            {
                var lab = IsPer ? "Проценти пуб" : "Проценти мех";
                return $"<div><span class='labelPercent'>{lab}</span>: {Shares}</div>\r\n";
            }
        }

        public class Sip : RecBase
        {
            public string Role { get; set; }
            public string RhName { get; set; }
            public override string GerErrCssClass() => "error1";
            public override string GetHtml()
            {
                return $"<div><span class='label'>Правовласник</span>: {RhName} ({Role}) - свій</div>\r\n";
            }
        }

        public class Oip : RecBase
        {
            public string Role { get; set; }
            public string RhName { get; set; }
            public override string GerErrCssClass() => "error1";
            public override string GetHtml()
            {
                return $"<div><span class='label'>Правовласник</span>: {RhName} ({Role}) - сторонній</div>\r\n";
            }
        }

        public class Alt : RecBase
        {
            public string Name { get; set; }
            public override string GerErrCssClass() => "error1";
            public override string GetHtml()
            {
                return $"<div><span class='label'>Варіант назви</span>: {Name}</div>\r\n";
            }
        }

        public class Per : RecBase
        {
            public string Name { get; set; }
            public override string GerErrCssClass() => "error1";
            public override string GetHtml()
            {
                return $"<div><span class='label'>Виконавець</span>: {Name}</div>\r\n";
            }
        }
        public class Wia : RecBase
        {
            public int ObjId { get; set; }
            public string Name { get; set; }
            public override string GerErrCssClass() => "error1";
            public override string GetHtml()
            {
                return $"<div><span class='label'>Назва твору</span>: {Name} ({ObjId})</div>\r\n";
            }
        }

        private int _respFileId;
        private int _objId;
        
        private int _submFileId;
        private int _grpSeqNr;
        private int _transSeqNr;

        private List<RecBase> _recs;

        public RespFilePresenter(int respFileId, int grpSeqNr, int objId)
        {
            _respFileId = respFileId;
            _grpSeqNr = grpSeqNr;
            _objId = objId;
        }

        public string GetHtml()
        {
            var hasRsp = LoadSubmRecords();
            if(!hasRsp)
            {
                return "Остання відповідь не містить інформації для даного твору";
            }
            return FormatHtml();
        }

        private bool LoadSubmRecords()
        {
            var hasRsp = false;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = @"
                    select t2.Id
                    from RecHdrRsp t1
                        join SubmFile t2 on t1.FileNameRef = t2.Name
                    where t1.respFileId = @respFileId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@respFileId", _respFileId);
                _submFileId = (int)cmd.ExecuteScalar();

                cmd.CommandText = @"
                    select cast(TransSeqNr as int)
                    from RecWia
                    where submFileId = @submFileId
                        and GrpSeqNr = @GrpSeqNr
                        and SubmWrkNr = @SubmWrkNr
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submFileId", _submFileId);
                cmd.Parameters.AddWithValue("@GrpSeqNr", _grpSeqNr);
                cmd.Parameters.AddWithValue("@SubmWrkNr", $"MS{_objId}");
                using(var r = cmd.ExecuteReader())
                {
                    if(!r.HasRows)
                    {
                        return;
                    }
                    hasRsp = true;
                    r.Read();
                    _transSeqNr = r.GetInt32(0);
                }

                _recs = new List<RecBase>();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submFileId", _submFileId);
                cmd.Parameters.AddWithValue("@GrpSeqNr", _grpSeqNr);
                cmd.Parameters.AddWithValue("@TransSeqNr", _transSeqNr);

                LoadWia(cmd);
                LoadSip(cmd);
                LoadOip(cmd);
                LoadSsr(cmd);
                LoadOsr(cmd);
                LoadAlt(cmd);
                LoadPer(cmd);

                _recs = _recs.OrderBy(x => x.RecSeqNr).ToList();
                _recs.ForEach(x => LoadErrMsg(cmd, x));
            });

            return hasRsp;
        }

        private void LoadWia(SqlCommand cmd)
          {
            cmd.CommandText = @"select RecType, cast(RecSeqNr as int), cast(substring(SubmWrkNr, 3, 1000) as int), WrkTtl
                from RecWia
                where SubmFileId = @submFileId
                    and GrpSeqNr = @GrpSeqNr
                    and TransSeqNr = @TransSeqNr
            ";
            using(var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _recs.Add(new Wia
                    {
                        RecType = r.GetString(0),
                        RecSeqNr = r.GetInt32(1),
                        ObjId = r.GetInt32(2),
                        Name = r.GetString(3),
                    });
                }
            }
        }
        private void LoadSip(SqlCommand cmd)
        {
            cmd.CommandText = @"select RecType, cast(RecSeqNr as int), IpRole, trim(concat(IpName, ' ', IpFstName))
                from RecSip
                where SubmFileId = @submFileId
                    and GrpSeqNr = @GrpSeqNr
                    and TransSeqNr = @TransSeqNr
            ";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _recs.Add(new Sip
                    {
                        RecType = r.GetString(0),
                        RecSeqNr = r.GetInt32(1),
                        Role = r.GetString(2),
                        RhName = r.GetString(3),
                    });
                }
            }
        }
        private void LoadOip(SqlCommand cmd)
        {
            cmd.CommandText = @"select RecType, cast(RecSeqNr as int), IpRole, trim(concat(IpName, ' ', IpFstName))
                from RecOip
                where SubmFileId = @submFileId
                    and GrpSeqNr = @GrpSeqNr
                    and TransSeqNr = @TransSeqNr
            ";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _recs.Add(new Oip
                    {
                        RecType = r.GetString(0),
                        RecSeqNr = r.GetInt32(1),
                        Role = r.GetString(2),
                        RhName = r.GetString(3),
                    });
                }
            }
        }
        private void LoadSsr(SqlCommand cmd)
        {
            cmd.CommandText = @"select RecType, cast(RecSeqNr as int), RightType, Shares
                from RecSsr
                where SubmFileId = @submFileId
                    and GrpSeqNr = @GrpSeqNr
                    and TransSeqNr = @TransSeqNr
            ";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _recs.Add(new Ssr
                    {
                        RecType = r.GetString(0),
                        RecSeqNr = r.GetInt32(1),
                        IsPer = r.GetString(2) == "PER",
                        Shares = decimal.Parse(r.GetString(3)) * 0.01m,
                    });
                }
            }
        }
        private void LoadOsr(SqlCommand cmd)
        {
            cmd.CommandText = @"select RecType, cast(RecSeqNr as int), RightType, Shares
                from RecOsr
                where SubmFileId = @submFileId
                    and GrpSeqNr = @GrpSeqNr
                    and TransSeqNr = @TransSeqNr
            ";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _recs.Add(new Osr
                    {
                        RecType = r.GetString(0),
                        RecSeqNr = r.GetInt32(1),
                        IsPer = r.GetString(2) == "PER",
                        Shares = decimal.Parse(r.GetString(3)) * 0.01m,
                    });
                }
            }
        }
        private void LoadAlt(SqlCommand cmd)
        {
            cmd.CommandText = @"select RecType, cast(RecSeqNr as int), AltTtl
                from RecAlt
                where SubmFileId = @submFileId
                    and GrpSeqNr = @GrpSeqNr
                    and TransSeqNr = @TransSeqNr
            ";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _recs.Add(new Alt
                    {
                        RecType = r.GetString(0),
                        RecSeqNr = r.GetInt32(1),
                        Name = r.GetString(2),
                    });
                }
            }
        }
        private void LoadPer(SqlCommand cmd)
        {
            cmd.CommandText = @"select RecType, cast(RecSeqNr as int), trim(concat(PerfArtistLstName, ' ', PerfArtistFstName))
                from RecPer
                where SubmFileId = @submFileId
                    and GrpSeqNr = @GrpSeqNr
                    and TransSeqNr = @TransSeqNr
            ";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _recs.Add(new Per
                    {
                        RecType = r.GetString(0),
                        RecSeqNr = r.GetInt32(1),
                        Name = r.GetString(2),
                    });
                }
            }
        }
        private void LoadErrMsg(SqlCommand cmd, RecBase rec)
        {
            cmd.CommandText = @"select t1.MsgTxt 
                from RecMsg t1
                join RecAck t2 on t1.RespFileId = t2.RespFileId
                    and t1.TransSeqNr = t2.TransSeqNr
                where t1.RespFileId = @respFileId 
                    and cast(t2.TransSeqNrRef as int) = @transSeqNr
                    and cast(t1.RecSeqNrRef as int) = @recSeqNr
                ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@respFileId", _respFileId);
            cmd.Parameters.AddWithValue("@transSeqNr", _transSeqNr);
            cmd.Parameters.AddWithValue("@recSeqNr", rec.RecSeqNr);
            using (var r = cmd.ExecuteReader())
            {
                rec.ErrMsg = new List<string>();
                while (r.Read())
                {
                    rec.ErrMsg.Add(r.GetString(0));
                }
            }
        }

        private string FormatHtml()
        {
            var html = $@"
                <!DOCTYPE html>
                <html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
                {_htmlHead}
                <body>
                {GetBodyHtml()}
                </body>
                </html>
            ";

            return html;
        }

        private string GetBodyHtml()
        {
            var html = "";
            _recs.ForEach(x =>
            {
                html += x.GetHtmlWithErrors();
            });
            return html;
        }
    }
}
