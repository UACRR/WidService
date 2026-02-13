using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls.UI;
using static DdexInvoicing.FormReportVsFoundWork;
using static System.Net.Mime.MediaTypeNames;

namespace DdexInvoicing
{
    public partial class FormReportVsFoundWork : Form
    {
        public struct Rgb
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
        }

        public class NamesPart
        {
            public string Name { get; set; }
            public string NameT { get; set; }
            public bool IsName { get; set; }
            public int MatchedIdx { get; set; }
        }

        private List<Rgb> _colorPalette;

        private TransLiterator _transLiterator;

        private int      _mwId;

        private string _sourceName;
        private string _sourceAuthors;
        private string _sourcePerformers;
        private int    _sourceObjId;
        private int    _sourceWic;

        private string _targetName;
        private string _targetAuthors;
        private string _targetPerformers;

        private string _sourceAuthorsHtml;
        private string _sourcePerformersHtml;
        private string _targetAuthorsHtml;
        private string _targetPerformersHtml;

        const string _style = @"
            body {font-family: tahoma; font-size: 10pt; background-color: aliceblue;}
            table {font-family: tahoma; font-size: 10pt; width: 100%; table-layout: fixed;}
            table, th, td { border: 1px solid black;}
            table {border-collapse: collapse;}
            td, th {padding: 10px;}
            .col1 { width: 80px;}
        ";

        private string   _html;

        public FormReportVsFoundWork()
        {
            InitializeComponent();

            CreateColorPalette();
            _transLiterator = new TransLiterator();
        }

        public FormReportVsFoundWork SetWork(int mwId)
        {
            _mwId = mwId ;

            Controls.Remove(wb);
            wb.Dispose();

            this.wb = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            this.wb.AllowNavigation = false;
            this.wb.AllowWebBrowserDrop = false;
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(800, 450);
            this.wb.TabIndex = 0;
            this.wb.WebBrowserShortcutsEnabled = false;
            Controls.Add(this.wb);
            this.ResumeLayout(false);

            ShowHtml();

            this.Width++;
            Refresh();
            this.Width--;

            return this;
        }

        private void ShowHtml()
        {
            CreateHtml();
            wb.DocumentText = _html;
        }

        private void CreateColorPalette()
        {
            _colorPalette = new List<Rgb>();
            Random random = new Random();
            for (int i = 0; i < 256; i++)
            {
                _colorPalette.Add(new Rgb{ 
                    R = random.Next(200, 250), 
                    G = random.Next(200, 250), 
                    B = random.Next(200, 250),
                });
            }
        }

        private string FormatWord(string text, int idx)
        {
            var rgb = _colorPalette[idx];
            return
                $@"
                    <span style=""background-color: rgb({rgb.R}, {rgb.G}, {rgb.B}); padding: 3px 3px 3px 3px;"">
                        {text}
                        <span style=""font-size: 8pt; background-color: white; border: black 1px solid; padding: 0px 3px 0px 3px; vertical-align:top"">
                            {idx}
                        </span>
                    </span>                      
                "
            ;
        }

        private List<NamesPart> SplitText(string text)
        {
            var retVal = new List<NamesPart>();
            
            if(text == "")
            {
                return retVal;
            }
            
            var word = "";
            var isSearchingLetter = char.IsLetter(text[0]);
            foreach (var curChar in text)
            {
                if (char.IsLetter(curChar) && isSearchingLetter)
                {
                    word += curChar;
                }
                else if (char.IsLetter(curChar) && !isSearchingLetter)
                {
                    retVal.Add(new NamesPart
                    {
                        Name = word,
                        IsName = isSearchingLetter,
                        MatchedIdx = 0,
                    });
                    word = "" + curChar;
                    isSearchingLetter = !isSearchingLetter;
                }
                else if (!char.IsLetter(curChar) && !isSearchingLetter)
                {
                    word += curChar;
                }
                else if (!char.IsLetter(curChar) && isSearchingLetter)
                {
                    retVal.Add(new NamesPart
                    {
                        Name = word,
                        IsName = isSearchingLetter,
                        MatchedIdx = 0,
                    });
                    word = "" + curChar;
                    isSearchingLetter = !isSearchingLetter;
                }
            }
            if(word != "")
            {
                retVal.Add(new NamesPart
                {
                    Name = word,
                    IsName = isSearchingLetter,
                    MatchedIdx = 0,
                });
            }
            return retVal;
        }

        private void MatchParts(List<NamesPart> sourceParts, List<NamesPart> targetParts)
        {
            var matchIdx = 1;
            foreach (var tp in targetParts)
            {
                if (!tp.IsName)
                {
                    continue;
                }

                var hasMatch = false;
                for(var spIdx = 0; spIdx < sourceParts.Count; spIdx++)
                {
                    var sp = sourceParts[spIdx];
                    if(!(sp.IsName && 
                        sp.MatchedIdx == 0 &&
                        (
                            TransLiterator.Contains(sp.Name, tp.Name) == 1 ||
                            TransLiterator.Contains(tp.Name, sp.Name) == 1 ||
                            tp.Name.ToUpper() == sp.Name.ToUpper())
                        )
                    )
                    {
                        continue;
                    }

                    sourceParts[spIdx].MatchedIdx = matchIdx;
                    hasMatch = true;
                }
                
                if (hasMatch)
                {
                    matchIdx++;
                }
            }

            foreach (var sp in sourceParts)
            {
                if (sp.MatchedIdx == 0)
                {
                    continue;
                }

                for(var tpIdx = 0; tpIdx < targetParts.Count; tpIdx++)
                {
                    var tp = targetParts[tpIdx];
                    if(!(tp.IsName && tp.MatchedIdx == 0 &&
                        (
                            TransLiterator.Contains(sp.Name, tp.Name) == 1 || 
                            TransLiterator.Contains(tp.Name, sp.Name) == 1 || 
                            tp.Name.ToUpper() == sp.Name.ToUpper())
                        )
                    )
                    {
                        continue;
                    }

                    targetParts[tpIdx].MatchedIdx = sp.MatchedIdx;
                }
                
           }
         }

        private string CreateHtmlFromParts(List<NamesPart> parts)
        {
            var sb = new StringBuilder();
            parts.ForEach(part =>
            {
                var mi = part.MatchedIdx;
                sb.Append(mi != 0 ? FormatWord(part.Name, mi): part.Name);
            });
            return sb.ToString();
        }

        private void CreateAuthorPerformerHtmls()
        {
            var sourceAuthorParts = SplitText(_sourceAuthors);
            var targetAuthorParts = SplitText(_targetAuthors);

            MatchParts(sourceAuthorParts, targetAuthorParts);
            _sourceAuthorsHtml = CreateHtmlFromParts(sourceAuthorParts);
            _targetAuthorsHtml = CreateHtmlFromParts(targetAuthorParts);

            var sourcePerformerParts = SplitText(_sourcePerformers);
            var targetPerformerParts = SplitText(_targetPerformers);

            MatchParts(sourcePerformerParts, targetPerformerParts);
            _sourcePerformersHtml = CreateHtmlFromParts(sourcePerformerParts);
            _targetPerformersHtml = CreateHtmlFromParts(targetPerformerParts);
        }

        private void CreateHtml()
        {
            /*var sw = new StringWriter();

            var idx = 1;
            _colorPalette.ForEach(x =>
            {
                sw.Write(
                    $@"{FormatWord("aadfsasfa aadfs s", x.R, x.G, x.B, idx++)}"
                );
            });

            _html = sw.ToString();
            return;*/

            ReadData();
            CreateAuthorPerformerHtmls();

            var foundIn = "Твір зайдено в БД ";
            if (_sourceObjId != 0) foundIn += "СМАРТ"; else foundIn += "WID";

            _html = $@"
            <html>
                <style>{_style}</style>
                <body>
                    {foundIn}
                <table>
                    <tr><td class = ""col1""></td><td>Значення у звіті</td><td>Значення в БД</td></tr>
                    <tr><td class = ""col1"">Назва</td><td>{_sourceName}</td><td>{_targetName}</td></tr>
                    <tr>
                        <td class = ""col1"">Автори</td>
                        <td style=""line-height: 2"">{_sourceAuthorsHtml}</td>
                        <td style=""line-height: 2"">{_targetAuthorsHtml}</td></tr>
                    <tr><td class = ""col1"">Виконавці</td>
                        <td style=""line-height: 2"">{_sourcePerformersHtml}</td>
                        <td style=""line-height: 2"">{_targetPerformersHtml}</td></tr>
                </table>
                </body>
            </html>";
        }

        private void ReadSourceData(SqlCommand cmd)
        {
            cmd.CommandText = @"
                    select 
	                      isnull(Title, '')
	                    , isnull(ComposerAuthor, '')
	                    , isnull(DisplayArtistName, '')
	                    , isnull(ObjId, 0)
	                    , isnull(Wic, 0)
                    from IdentMw
                    where Id = @mwId
                ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mwId", _mwId);

            using (var r = cmd.ExecuteReader())
            {
                if (r.HasRows)
                {
                    r.Read();
                    _sourceName         = r.GetString(0);
                    _sourceAuthors      = r.GetString(1);
                    _sourcePerformers   = r.GetString(2);
                    _sourceObjId        = r.GetInt32(3);
                    _sourceWic          = r.GetInt32(4);
                }
                else
                {
                    _sourceName         = "";
                    _sourceAuthors      = "";
                    _sourcePerformers   = "";
                    _sourceObjId        = 0;
                    _sourceWic          = 0;
                }
            }
        }

        private void ReadTargetNameMs(SqlCommand cmd)
        {
            cmd.CommandText = "select Name from MediaService..ObjectRight where ObjId = @objId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@objId", _sourceObjId);
            using(var r = cmd.ExecuteReader())
            {
                if(r.HasRows)
                {
                    r.Read();
                    _targetName = r.GetString(0);
                }
                else
                {
                    _targetName = "";
                }
            }
        }

        private void ReadTargetAuthorsMs(SqlCommand cmd)
        {
            cmd.CommandText = @"
                select distinct t2.Name 
                from MediaService..CopyRight t1
	                join MediaService..vCustomerNameLastFirstSur t2 on t1.CustId = t2.CustId
                where ObjId = @objId
                order by t2.Name 
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@objId", _sourceObjId);
            using(var r = cmd.ExecuteReader())
            {
                _targetAuthors = "";
                while(r.Read())
                {
                    _targetAuthors += r.GetString(0) + ";";
                }
            }
        }

        private void ReadTargetPerformersMs(SqlCommand cmd)
        {
            cmd.CommandText = @"
                select distinct Name 
                from MediaService..SeekObject
                where ObjId = @objId
	                and codeI = 2
                order by Name 
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@objId", _sourceObjId);
            using(var r = cmd.ExecuteReader())
            {
                _targetPerformers = "";
                while(r.Read())
                {
                    _targetPerformers += r.GetString(0) + ";";
                }
            }
        }

        private void ReadTargetDataMs(SqlCommand cmd)
        {
            ReadTargetNameMs(cmd);
            ReadTargetAuthorsMs(cmd);
            ReadTargetPerformersMs(cmd);
        }

        private void ReadTargetNameWid(SqlCommand cmd)
        {
            cmd.CommandText = "select WrkTtl from SocWid..WidTitle where Wic = @wic";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", _sourceWic);
            using(var r = cmd.ExecuteReader())
            {
                if(r.HasRows)
                {
                    r.Read();
                    _targetName = r.GetString(0);
                }
                else
                {
                    _targetName = "";
                }
            }
        }

        private void ReadTargetAuthorsWid(SqlCommand cmd)
        {
            cmd.CommandText = @"
                select distinct concat(t2.Name, ' ', t2.FstName, ';'), t2.Name
                from SocWid..widIntrPty t1
	                join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
                where t1.Wic = @wic
	                and t1.IpRole <> 'E'
                order by t2.Name
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", _sourceWic);
            using(var r = cmd.ExecuteReader())
            {
                _targetAuthors = "";
                while(r.Read())
                {
                    _targetAuthors += r.GetString(0);
                }
            }
        }

        private void ReadTargetPerformersWid(SqlCommand cmd)
        {
            cmd.CommandText = @"
                select distinct concat(PerfArtistLstName, ' ', PerfArtistFstName, ';'), PerfArtistLstName
                from SocWid..widArtist
                where Wic = @wic
                order by PerfArtistLstName
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", _sourceWic);
            using(var r = cmd.ExecuteReader())
            {
                _targetPerformers = "";
                while(r.Read())
                {
                    _targetPerformers += r.GetString(0);
                }
            }
        }

        private void ReadTargetDataWid(SqlCommand cmd)
        {
            ReadTargetNameWid(cmd);
            ReadTargetAuthorsWid(cmd);
            ReadTargetPerformersWid(cmd);
        }

        private void ReadTargetData(SqlCommand cmd)
        {
            if(_sourceObjId != 0)
            {
                ReadTargetDataMs(cmd);
            }
            else
            {
                ReadTargetDataWid(cmd);
            }
        }

        private void ReadData()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                ReadSourceData(cmd);
                ReadTargetData(cmd);
            });
        }
    }
}
