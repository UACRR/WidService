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

namespace WidExport
{
        public partial class UcWidSubmWorksChanges : UserControl
    {
        private const string _html = @"
<!DOCTYPE html>

<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta charset='utf-8' />
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css'>
    <title></title>
    <style>
        body {
            font-family: Tahoma;
            font-size: small;
            font-weight: bold;
            padding: 10 10 10 10;
        }

        h1 {
            font-family: Tahoma;
            font-size: small;
            font-weight: bold;
            margin-top: 0;
            margin-bottom: 0;
        }

        h2 {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-left: 40px;
            text-decoration: underline;
            margin-top: 10px;
            margin-bottom: 0;
        }

        h3 {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            text-decoration: underline dotted;
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
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-left: 40px;
            margin-top: 0;
            margin-bottom: 0;
        }

        .error2 {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-left: 60px;
            margin-top: 0;
            margin-bottom: 0;
        }

        .action2 {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-left: 60px;
            margin-top: 0;
            margin-bottom: 10px;
        }

        table {
            font-weight: normal;
            margin-left: 40px;
            border: double 1px black;
        }

        th {
            font-weight: bold;
            padding: 0px 10px 0px 10px;
        }

        td {
            padding: 0px 10px 0px 10px;
            white-space: nowrap;
        }

        .td-top {
            padding: 0px 10px 0px 10px;
            border-top: solid 1px;
            white-space: nowrap;
        }

        .td-top-dotted {
            padding: 0px 10px 0px 10px;
            border-top: dotted 1px;
            white-space: nowrap;
        }

        .label {
            font-family: Tahoma;
            font-size: small;
            font-weight: normal;
            margin-left: 40px;
            margin-top: 0;
            margin-bottom: 0;
        }
    </style>
</head>
";

        private WorksComparer _wCmp;

        private bool _ignoreCbFilterSelectedIndex = true;

        public UcWidSubmWorksChanges()
        {
            InitializeComponent();
        }

        private void UcWidSubmWorksChanges_Load(object sender, EventArgs e)
        {
            lvWorks.Columns.Add("№", 40);
            lvWorks.Columns.Add("Що змінилось", 90);
            lvWorks.Columns.Add("Код твору", 80);
            lvWorks.Columns.Add("Попередня назва", 300);
            lvWorks.Columns.Add("Нова назва", 300);
            lvWorks.Columns.Add("Назіва змінилась?", 120);

            cbFilter.Items.Add("Всі твори");
            cbFilter.Items.Add("Додані твори");
            cbFilter.Items.Add("Змінені твори");
            cbFilter.Items.Add("Видалені твори");
        }

        public void RefreshControls(bool forceRefresh = false)
        {
            if(!forceRefresh && _wCmp != null)
            {
                return;
            }
            _wCmp = new WorksComparer();
            _wCmp.LoadWorks();

            _ignoreCbFilterSelectedIndex = true;
            cbFilter.SelectedIndex = 0;
            _ignoreCbFilterSelectedIndex = false;

            FillLvWorks();
            timerFillWCtrl.Enabled = true;
        }

        private void FillLvWorks()
        {
            SetHtml("");
            lvWorks.Items.Clear();
            for(var idx = 1; idx <= _wCmp.Works.Count; idx++)
            {
                var work = _wCmp.Works[idx - 1];

                switch (cbFilter.SelectedIndex)
                {
                    case 1:
                        if(work.OldName != null) continue;
                        break;
                    case 2:
                        if(work.OldName == null || work.NewName == null) continue;
                        break;
                    case 3:
                        if(work.NewName != null) continue;
                        break;
                }

                var item = lvWorks.Items.Add(idx.ToString());
                item.SubItems.Add(work.OldName == null ? "Твір Додано" : work.NewName == null ? "Твір Видалено" : "Твір Змінено");
                item.SubItems.Add(work.ObjId.ToString());
                item.SubItems.Add(work.OldName == null ? "" : work.OldName);
                item.SubItems.Add(work.NewName == null ? "" : work.NewName);
                item.SubItems.Add(work.OldName != null && 
                    work.NewName != null && 
                    !work.OldName.Equals(work.NewName, StringComparison.OrdinalIgnoreCase) ? "Так" : "Ні");
                item.Tag = work;
            }

            if(lvWorks.Items.Count > 0)
            {
                lvWorks.Items[0].Selected = true;

            }
        }

        private void FillWb()
        {
            var work = GetSelectedWork();
            if(work == null)
            {
                SetHtml("");
                return;
            }

            //_wCmp.LoadWorkDetails(work);
            SetHtml(CreateHtml(work));
        }

        private WorksComparer.Work GetSelectedWork()
        {
            return lvWorks.SelectedItems.Count == 1 ? (WorksComparer.Work)lvWorks.SelectedItems[0].Tag : null;
        }

        private void SetHtml(string html)
        {
            wb.DocumentText = html;
        }

        private void AppendHtmlShareStatusText(StringWriter sw, WorksComparer.Share share)
        {
            switch(share.ChangeStatus)
            {
                case WorksComparer.ChangeStatus.Added:
                    sw.WriteLine($"           <td class='td-top' colspan='11' style='background-color: yellow;'><i>Додано</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Updated:
                    sw.WriteLine($"           <td class='td-top' colspan='11' style='background-color: yellow;'><i>Змінено</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Deleted:
                    sw.WriteLine($"           <td class='td-top' colspan='11' style='background-color: yellow;'><i>Видалено</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Unchanged:
                    sw.WriteLine($"           <td class='td-top' colspan='11'><i>Без змін</i></td>");
                    break;
                default:
                    break;
            }
        }
        private void AppendHtmlAltNameStatusText(StringWriter sw, WorksComparer.AltName altName)
        {
            switch(altName.ChangeStatus)
            {
                case WorksComparer.ChangeStatus.Added:
                    sw.WriteLine($"           <td class='td-top' style='background-color: yellow;'><i>Додано</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Updated:
                    sw.WriteLine($"           <td class='td-top' style='background-color: yellow;'><i>Змінено</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Deleted:
                    sw.WriteLine($"           <td class='td-top' style='background-color: yellow;'><i>Видалено</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Unchanged:
                    sw.WriteLine($"           <td class='td-top'><i>Без змін</i></td>");
                    break;
                default:
                    break;
            }
        }

        private void AppendHtmlPerformerStatusText(StringWriter sw, WorksComparer.Performer performer)
        {
            switch(performer.ChangeStatus)
            {
                case WorksComparer.ChangeStatus.Added:
                    sw.WriteLine($"           <td class='td-top' style='background-color: yellow;'><i>Додано</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Updated:
                    sw.WriteLine($"           <td class='td-top' style='background-color: yellow;'><i>Змінено</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Deleted:
                    sw.WriteLine($"           <td class='td-top' style='background-color: yellow;'><i>Видалено</i></td>");
                    break;
                case WorksComparer.ChangeStatus.Unchanged:
                    sw.WriteLine($"           <td class='td-top'><i>Без змін</i></td>");
                    break;
                default:
                    break;
            }
        }

        private void AppendHtmlSharesTableHead(StringWriter sw)
        {
            sw.WriteLine($"   <thead>");
            sw.WriteLine($"       <tr>");
            sw.WriteLine($"           <th></th>");
            sw.WriteLine($"           <th>Код</th>");
            sw.WriteLine($"           <th>IpBaseNr</th>");
            sw.WriteLine($"           <th>IpNameNr</th>");
            sw.WriteLine($"           <th>Тип</th>");
            sw.WriteLine($"           <th>Роль</th>");
            sw.WriteLine($"           <th>Пуб. %</th>");
            sw.WriteLine($"           <th>Мех. %</th>");
            sw.WriteLine($"           <th>Дог. з товариством</th>");
            sw.WriteLine($"           <th>Пуб. дог. в IPI</th>");
            sw.WriteLine($"           <th>Мех. дог. в IPI</th>");
            sw.WriteLine($"       </tr>");
            sw.WriteLine($"   </thead>");
        }

        private string AsHtml(string value)
        {
            return string.IsNullOrEmpty(value) ? "<i><Не визначено></i>" : value;
        }

        private void AppendHtmlNewShareCell(StringWriter sw, string oldValue, string newValue)
        {
            var cellColor = "white";
            if(!string.IsNullOrEmpty(oldValue))
            {
                cellColor = oldValue == newValue ? "white" : "yellow";
            }
            sw.WriteLine($"           <td class='td-top-dotted' style='background-color: {cellColor}'>{AsHtml(newValue)}</td>");
        }

        private void AppendHtmlOldShareValuesRows(StringWriter sw, WorksComparer.Share share, string prefix)
        {
            var sepClass = "td-top";
            if(share.OldCustId != "" && share.NewCustId != "")
            {
                sw.WriteLine($"       <tr>");
                AppendHtmlShareStatusText(sw, share);
                sw.WriteLine($"       </tr>");
                sepClass = "td-top-dotted";
            }

             var backColor = share.IsDeleted() ? "yellow" : "white";

            sw.WriteLine($"       <tr>");
            sw.WriteLine($"           <td class='{sepClass}' style='background-color: {backColor}'><i>{prefix}</i></td>");
            sw.WriteLine($"           <td colspan='10' class='{sepClass}'>{AsHtml(share.OldCustName)}</td>");
            sw.WriteLine($"       </tr>");

            sw.WriteLine($"       <tr>");
            sw.WriteLine($"           <td class='td-top-dotted'></td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldCustId)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldIpBaseNr)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldIpNameNr)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldRhType)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldRhRole)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldPerShr)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldMecShr)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldAgrLocal)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldAgrIpiPer)}</td>");
            sw.WriteLine($"           <td class='td-top-dotted'>{AsHtml(share.OldAgrIpiMec)}</td>");
            sw.WriteLine($"       </tr>");
        }

        private void AppendHtmlNewShareValuesRows(StringWriter sw, WorksComparer.Share share, string prefix)
        {
            var sepClass = "td-top";
            if(share.OldCustId != "" && share.NewCustId != "")
            {
                sepClass = "td-top-dotted";
            }

            var backColor = share.IsAdded() || share.IsUpdated() ? "yellow" : "white";

            sw.WriteLine($"       <tr>");
            sw.WriteLine($"           <td class='{sepClass}' style='background-color: {backColor};'><i>{prefix}</i></td>");
            sw.WriteLine($"           <td colspan='10' class='{sepClass}'>{AsHtml(share.NewCustName)}</td>");
            sw.WriteLine($"       </tr>");

            sw.WriteLine($"       <tr>");
            sw.WriteLine($"           <td class='td-top-dotted'></td>");
            AppendHtmlNewShareCell(sw, share.OldCustId   , share.NewCustId   );
            AppendHtmlNewShareCell(sw, share.OldIpBaseNr , share.NewIpBaseNr );
            AppendHtmlNewShareCell(sw, share.OldIpNameNr , share.NewIpNameNr );
            AppendHtmlNewShareCell(sw, share.OldRhType   , share.NewRhType   );
            AppendHtmlNewShareCell(sw, share.OldRhRole   , share.NewRhRole   );
            AppendHtmlNewShareCell(sw, share.OldPerShr   , share.NewPerShr   );
            AppendHtmlNewShareCell(sw, share.OldMecShr   , share.NewMecShr   );
            AppendHtmlNewShareCell(sw, share.OldAgrLocal , share.NewAgrLocal );
            AppendHtmlNewShareCell(sw, share.OldAgrIpiPer, share.NewAgrIpiPer);
            AppendHtmlNewShareCell(sw, share.OldAgrIpiMec, share.NewAgrIpiMec);
            sw.WriteLine($"       </tr>");
        }

        private void AppendHtmlAltValueRow(StringWriter sw, WorksComparer.AltName altName)
        {
            var cntSymbolsOldTxt = altName.OldName.Length > 0 ? $"&nbsp;<i>({altName.OldName.Length} символів)</i>" : "&nbsp";
            var cntSymbolsNewTxt = altName.NewName.Length > 0 ? $"&nbsp;<i>({altName.NewName.Length} символів)</i>" : "&nbsp";
            sw.WriteLine($"       <tr>");
            AppendHtmlAltNameStatusText(sw, altName);
            sw.WriteLine($"           <td class='td-top'>{AsHtml(altName.SeekObjectId)}</td>");
            sw.WriteLine($"           <td class='td-top'>{AsHtml(altName.OldName)}{cntSymbolsOldTxt}</td>");
            sw.WriteLine($"           <td class='td-top'>{AsHtml(altName.NewName)}{cntSymbolsNewTxt}</i></td>");
            sw.WriteLine($"       </tr>");
        }

        private void AppendHtmlPerformerRow(StringWriter sw, WorksComparer.Performer performer)
        {
            var cntSymbolsOldTxt = performer.OldName.Length > 0 ? $"&nbsp;<i>({performer.OldName.Length} символів)</i>" : "&nbsp";
            var cntSymbolsNewTxt = performer.NewName.Length > 0 ? $"&nbsp;<i>({performer.NewName.Length} символів)</i>" : "&nbsp";
            sw.WriteLine($"       <tr>");
            AppendHtmlPerformerStatusText(sw, performer);
            sw.WriteLine($"           <td class='td-top'>{AsHtml(performer.SeekObjectId)}</td>");
            sw.WriteLine($"           <td class='td-top'>{AsHtml(performer.OldName)}{cntSymbolsOldTxt}</td>");
            sw.WriteLine($"           <td class='td-top'>{AsHtml(performer.NewName)}{cntSymbolsNewTxt}</td>");
            sw.WriteLine($"       </tr>");
        }

        private void ApendHtmlAltWorks(StringWriter sw)
        {
            sw.WriteLine($"<div class='label' style='margin-top:10px;'>Альтернативні назви:</div>");
            sw.WriteLine($"<table>");
            sw.WriteLine($"   <thead>");
            sw.WriteLine($"       <tr>");
            sw.WriteLine($"           <th></th>");
            sw.WriteLine($"           <th>Код</th>");
            sw.WriteLine($"           <th>Поточна назва</th>");
            sw.WriteLine($"           <th>Нова назва</th>");
            sw.WriteLine($"       </tr>");
            sw.WriteLine($"   </thead>");
            sw.WriteLine($"   <tbody>");

            _wCmp.AltNames.ForEach( altName =>
            {
                AppendHtmlAltValueRow(sw, altName);
            });

            sw.WriteLine($"   </tbody>");
            sw.WriteLine($"</table>");
        }

        private void ApendHtmlPerformers(StringWriter sw)
        {
            sw.WriteLine($"<div class='label' style='margin-top:10px;'>Виконавці:</div>");
            sw.WriteLine($"<table>");
            sw.WriteLine($"   <thead>");
            sw.WriteLine($"       <tr>");
            sw.WriteLine($"           <th></th>");
            sw.WriteLine($"           <th>Код</th>");
            sw.WriteLine($"           <th>Поточна назва</th>");
            sw.WriteLine($"           <th>Нова назва</th>");
            sw.WriteLine($"       </tr>");
            sw.WriteLine($"   </thead>");
            sw.WriteLine($"   <tbody>");

            _wCmp.Performers.ForEach( performer =>
            {
                AppendHtmlPerformerRow(sw, performer);
            });

            sw.WriteLine($"   </tbody>");
            sw.WriteLine($"</table>");
        }

        private void ApendHtmlWorkAdded(StringWriter sw, WorksComparer.Work work)
        {
            sw.WriteLine($"<body>");
            sw.WriteLine($"<h1>{AsHtml(work.NewName)}<i style='margin-left: 10px;'>Додано</i></h1>");
            sw.WriteLine($"<div class='label'>Код твору: <span style='background-color: white'>{AsHtml(work.ObjId.ToString())}</span></div>");
            sw.WriteLine($"<div class='label'>Назва твору: <span style='background-color: white'>{AsHtml(work.NewName)}</span></div>");
            sw.WriteLine($"<div class='label' style='margin-top:10px;'>Правовласники:</div>");
            sw.WriteLine($"<table>");
            AppendHtmlSharesTableHead(sw);
            sw.WriteLine($"   <tbody>");

            _wCmp.Shares.ForEach( share =>
            {
                AppendHtmlNewShareValuesRows(sw, share, "Додано");
            });

            sw.WriteLine($"   </tbody>");
            sw.WriteLine($"</table>");

            ApendHtmlAltWorks(sw);
            ApendHtmlPerformers(sw);

            sw.WriteLine($"</body>");
         }

        private void ApendHtmlWorkUpdated(StringWriter sw, WorksComparer.Work work)
        {
            sw.WriteLine($"<body>");
            sw.WriteLine($"<h1>{work.OldName}<i style='margin-left: 10px;'>Змінений</i></h1>");
            sw.WriteLine($"    <div class='label'>ObjId: {work.ObjId}</div>");
            sw.WriteLine($"    <div class='label'>Стара назва: <span style='background-color: white;'>{AsHtml(work.OldName)}</span>&nbsp;<i>({work.OldName.Length} символів)</i></div>");
            var color = work.OldName.Equals(work.NewName, StringComparison.OrdinalIgnoreCase) ? "white" : "yellow";
            sw.WriteLine($"    <div class='label'>Нова назва: <span style='background-color: {color}'>{AsHtml(work.NewName)}</span>&nbsp;<i>({work.NewName.Length} символів)</i></div>");
            sw.WriteLine($"<div class='label'>Правовласники:</div>");
            sw.WriteLine($"<table>");
            AppendHtmlSharesTableHead(sw);
            sw.WriteLine($"   <tbody>");

            _wCmp.Shares.ForEach( share =>
            {
                if(share.IsAdded())
                {
                    AppendHtmlNewShareValuesRows(sw, share, "Додано");
                }
                else if(share.IsUpdated() || share.IsUnchanged())
                {
                    AppendHtmlOldShareValuesRows(sw, share, "Поточні значення");
                    AppendHtmlNewShareValuesRows(sw, share, "Нові значення");
                }
                else if(share.IsDeleted())
                {
                    AppendHtmlOldShareValuesRows(sw, share, "Видалено");
                }
            });

            sw.WriteLine($"   </tbody>");
            sw.WriteLine($"</table>");

            ApendHtmlAltWorks(sw);
            ApendHtmlPerformers(sw);

            sw.WriteLine($"</body>");
        }

        private void ApendHtmlWorkDeleted(StringWriter sw, WorksComparer.Work work)
        {
            sw.WriteLine($"<body>");
            sw.WriteLine($"<h1>{AsHtml(work.NewName)}<i style='margin-left: 10px;'>Видалений</i></h1>");
            sw.WriteLine($"<div class='label'>Код твору: <span style='background-color: white'>{AsHtml(work.ObjId.ToString())}</span></div>");
            sw.WriteLine($"<div class='label'>Назва твору: <span style='background-color: white'>{AsHtml(work.OldName)}</span></div>");
            sw.WriteLine($"<div class='label'>Правовласники:</div>");
            sw.WriteLine($"<table>");
            AppendHtmlSharesTableHead(sw);
            sw.WriteLine($"   <tbody>");

            _wCmp.Shares.ForEach( share =>
            {
                AppendHtmlOldShareValuesRows(sw, share, "Видалений");
            });

            sw.WriteLine($"   </tbody>");
            sw.WriteLine($"</table>");

            ApendHtmlAltWorks(sw);
            ApendHtmlPerformers(sw);

            sw.WriteLine($"</body>");
        }

        private void ApendHtmlWork(StringWriter sw, WorksComparer.Work work)
        {
            _wCmp.LoadWorkDetails(work);
            if (work.OldName != null && work.NewName != null)
            {
                ApendHtmlWorkUpdated(sw, work);
            }
            else if (work.OldName != null)
            {
                ApendHtmlWorkDeleted(sw, work);
            }
            else
            {
                ApendHtmlWorkAdded(sw, work);
            }
        }

        private string CreateHtml(WorksComparer.Work work)
        {
            var sw = new StringWriter();

            sw.WriteLine(_html);

            ApendHtmlWork(sw, work);

            sw.WriteLine("</html>");

           return sw.ToString();
        }

        private string CreateHtmlAll()
        {
            var sw = new StringWriter();

            sw.WriteLine(_html);
            _wCmp.Works.ForEach( work =>
            {
                ApendHtmlWork(sw, work);
                sw.WriteLine("<div style='background-color: lightgrey; width: 100%; margin-top: 10px;'>&nbsp;</div>");
            });

            sw.WriteLine("</html>");

           return sw.ToString();
        }

        private void lvWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillWb();
        }

        private void btnSaveHtml_Click(object sender, EventArgs e)
        { 
            var res = saveFileDialog.ShowDialog();
            if(res == DialogResult.Cancel)
            {
                return;
            }
            var fileFullName = saveFileDialog.FileName;
            var html = CreateHtmlAll();
            File.WriteAllText(fileFullName, html);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ignoreCbFilterSelectedIndex)
            {
                return;
            }

            FillLvWorks();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            RefreshControls(true);
        }

        private void timerFillWCtrl_Tick(object sender, EventArgs e)
        {
            timerFillWCtrl.Enabled = false;
            FillWb();
        }
    }
}
