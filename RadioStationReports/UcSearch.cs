using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class UcSearch : UserControl
    {

        public class FoundWork
        {
            public string Code       { get; set; }
            public string Name       { get; set; }
            public string Authors    { get; set; }
            public string Performers { get; set; }
        }

        private string _name;
        private string _performers;
        private List<FoundWork> _foundWorks;

        private bool _isWebControlInitialized;
        public UcSearch()
        {
            InitializeComponent();
        }

        private void UcSearch_Load(object sender, EventArgs e)
        {
            _isWebControlInitialized = false;
        }

        public async void SetNamePerformer(string name, string performers)
        {
            await InitWebControl();
            _name = name;
            _performers = performers;

            LoadFoundWorks();
            FillControls();
        }

        private async Task InitWebControl()
        {
            if(!_isWebControlInitialized)
            {
                await wvFoundWorks.EnsureCoreWebView2Async();
                _isWebControlInitialized = true;
            }
        }

        private void LoadFoundWorks()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "MediaService..spSearchWorks";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", _name);

                using (var r = cmd.ExecuteReader())
                {
                    _foundWorks = new List<FoundWork>();
                    while (r.Read())
                    {
                        var foundWork = new FoundWork();
                        
                        var idx = 0;

                        foundWork.Code       = r.GetString(idx++);
                        foundWork.Name       = r.GetString(idx++);
                        foundWork.Authors    = r.GetString(idx++);
                        foundWork.Performers = r.GetString(idx++);

                         _foundWorks.Add(foundWork);
                    }
                }
            });
        }

        private string RefineString(string source)
        {
            var retVal = new StringWriter();
            for (var idx = 0; idx < source.Length; idx++)
            {
                var curChar = source[idx];
                retVal.Write(Char.IsLetterOrDigit(curChar) ? curChar : ' ');
            }
            return retVal.ToString();
        }

        private List<string> CreatePerformerFragments()
        {
            var fragments = tbFilterTextFragment.Text
                    .Split(' ')
                    .Where(x => x.Trim() != "")
                    .Distinct()
                    .ToList();
            return fragments;
        }

        private void FillControls()
        {
            tbReportWorkName.Text = _name;
            tbReportWorkPerformers.Text = _performers;

            tbFilterName.Text = _name;
            tbFilterTextFragment.Text = RefineString(_performers);

            var fragments = CreatePerformerFragments();
            var htmlHelper = new UcSearchHelper(_foundWorks, fragments);
            var html = htmlHelper.GetHtml();            
            wvFoundWorks.NavigateToString(html);
        }

        private void wvFoundWorks_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {

        }
    }
}
