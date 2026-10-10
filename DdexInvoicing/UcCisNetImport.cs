using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DdexInvoicing
{

    public partial class UcCisNetImport : UserControl
    {
        private CisNetSingleWorkImporter _cisNetSingleWorkImporter;

        public class ObjIdSelectedEventArgs : EventArgs
        {
            public int ObjId { get; set; }
        }
        public event EventHandler<ObjIdSelectedEventArgs> ObjIdSelectedEvent;

        public UcCisNetImport()
        {
            InitializeComponent();
        }

        private void UcCisNetImport_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvShares.FullRowSelect = true;
            lvShares.GridLines = true;
            lvShares.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvShares.MultiSelect = false;
            lvShares.View = View.Details;

            lvShares.Columns.Clear();
            lvShares.Columns.Add("№", 40);
            lvShares.Columns.Add("Назва", 200);
            lvShares.Columns.Add("Базовий код", 90);
            lvShares.Columns.Add("Код назви", 90);
            lvShares.Columns.Add("Роль", 40);
            lvShares.Columns.Add("Пуб Тов", 60);
            lvShares.Columns.Add("Пуб %", 60);
            lvShares.Columns.Add("Мех Тов", 60);
            lvShares.Columns.Add("Мех %", 60);

            lvAltNames.FullRowSelect = true;
            lvAltNames.GridLines = true;
            lvAltNames.HeaderStyle = ColumnHeaderStyle.None;
            lvAltNames.MultiSelect = false;
            lvAltNames.View = View.Details;

            lvAltNames.Columns.Add("Назва", 300);

            lvPerformers.FullRowSelect = true;
            lvPerformers.GridLines = true;
            lvPerformers.HeaderStyle = ColumnHeaderStyle.None;
            lvPerformers.MultiSelect = false;
            lvPerformers.View = View.Details;

            lvPerformers.Columns.Add("Назва", 300);

            //btnApply.Enabled = false;

            _cisNetSingleWorkImporter = new CisNetSingleWorkImporter();

        }

        private void FillControls(CisNetSingleWorkImporter.Work work)
        {
            tbWorkName.Text = work.Name;
            tbWorkIswc.Text = work.Iswc;
            tbCisNetCode.Text = $"{work.SocCode}_{work.SourceDb}_{work.SocWorkCode}";

            var seqNr = 1;
            lvShares.Items.Clear();
            work.Shares.ForEach(s =>
            {
                var item = lvShares.Items.Add(seqNr.ToString());
                item.SubItems.Add(s.IpName);
                item.SubItems.Add(s.IpBaseNr);
                item.SubItems.Add(s.IpNameNr);
                item.SubItems.Add(s.IpRole);
                item.SubItems.Add(s.PerSoc);
                item.SubItems.Add(s.PerShr);
                item.SubItems.Add(s.MecSoc);
                item.SubItems.Add(s.MecShr);
                seqNr++;
            });

            lvAltNames.Items.Clear();
            work.AltNames.ForEach(n =>
            {
                lvAltNames.Items.Add(n);
            });

            lvPerformers.Items.Clear();
            work.Performers.ForEach(p =>
            {
                lvPerformers.Items.Add(p);
            });
            lvPerformers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        public void ClearControls()
        {
            tbWorkName.Text = "";
            tbWorkIswc.Text = "";
            tbCisNetCode.Text = "";

            lvShares.Items.Clear();
            lvAltNames.Items.Clear();
            lvPerformers.Items.Clear();
        }

        private void GetWork()
        {
            Helpers.RunProtected(() =>
            {
                var work = _cisNetSingleWorkImporter.LoadDownloadedFile();
                if(work == null) return;

                FillControls(work);
                //btnPaste.Enabled = false;
                //btnApply.Enabled = true;
            });
        }

        private int ApplyWork()
        {
           var res = 0;
           Helpers.RunProtected(() =>
            {
                res = _cisNetSingleWorkImporter.ApplyImportedWork();
                //btnApply.Enabled = false;
            });
            return res;
        }

        private void btnGetWork_Click(object sender, EventArgs e)
        {
            GetWork();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var objId = ApplyWork();
            if( objId != 0)
            {
                if (ObjIdSelectedEvent != null)
                {
                    ObjIdSelectedEvent(sender, new ObjIdSelectedEventArgs { ObjId = (int)objId, });
                }
            }
        }
    }
}
