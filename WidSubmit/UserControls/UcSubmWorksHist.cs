using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidSubmit.Properties;

namespace WidSubmit.UserControls
{
    public partial class UcSubmWorksHist : UserControl
    {
        public class Submission
        {
            public int      Id          { get;set; }
            public DateTime StartedAt   { get;set; }
            public DateTime EndedAt     { get;set; }
            public DateTime CreatedAt   { get;set; }
        }

        private int _selectedSubmId;
        private List<Submission> _submissions;

        private bool _ignoreEvents;

        public UcSubmWorksHist()
        {
            InitializeComponent();

            ucSubmWorks.SetHistoryMode();
        }

        private void UcSubmWorksHist_Load(object sender, EventArgs e)
        {
            
        }

        private void Configure()
        {

        }

        private void InitProperties()
        {
        }

        public void UpdateProperties()
        {
        }

        public void UpdateContent()
        {
            _ignoreEvents = true;
            LoadSubmissions();
            FillCbSubmissions();
            _ignoreEvents = false;
        }

        private void LoadSubmissions()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
                           Id         
                         , StartedAt
                         , EndedAt  
                         , CreatedAt
                         , UpdatedAt
                    from Submission
                    order by EndedAt desc
                ";
                using(var r = cmd.ExecuteReader())
                {
                    _submissions = new List<Submission>();
                    while(r.Read())
                    {
                        var idx = 0;
                        var subm = new Submission();
                        subm.Id           = r.GetInt32(idx); idx++;  
                        subm.StartedAt    = r.GetDateTime(idx); idx++;
                        subm.EndedAt      = r.GetDateTime(idx); idx++;
                        subm.CreatedAt    = r.GetDateTime(idx); idx++;
                        _submissions.Add(subm);
                    }
                }
            });
        }
    
        private void FillCbSubmissions()
        {
            var curSubmId = cbSubmissions.SelectedIndex == -1 ? 0 : _submissions[cbSubmissions.SelectedIndex].Id;

            cbSubmissions.Items.Clear();
            cbSubmissions.Items.Add($"({_submissions[0].Id}) Поточний");
            for(var idx = 1; idx < _submissions.Count; idx++)
            {
                var subm = _submissions[idx];
                var year = subm.EndedAt.Year;
                var month = subm.EndedAt.Month;
                var day = subm.EndedAt.Day;
                var hour = subm.EndedAt.Hour;
                var minute = subm.EndedAt.Minute;
                var second = subm.EndedAt.Second;
                if(subm.StartedAt.Year == 1900)
                    cbSubmissions.Items.Add($"({subm.Id}) Початковий");
                else         
                    cbSubmissions.Items.Add($"({subm.Id}) Завершений {year}-{month}-{day} о {hour} год {minute} хв {second} сек");
                if(idx > 50)
                {
                    break;
                }
            }

            
            if(curSubmId == 0)
            {
                cbSubmissions.SelectedIndex = 0;
                ucSubmWorks.UpdateContent(_submissions[cbSubmissions.SelectedIndex].Id);
            }
            else
            {
                for(var idx = 0; idx < _submissions.Count; idx++)
                {
                    var subm = _submissions[idx];
                    if(subm.Id == curSubmId)
                    {
                        cbSubmissions.SelectedIndex = idx;
                        break;
                    }
                }
            }

        }

        private void cbSubmissions_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(_ignoreEvents) return;

           ucSubmWorks.SetDirty();
           ucSubmWorks.UpdateContent(_submissions[cbSubmissions.SelectedIndex].Id);
        }
    }
}
