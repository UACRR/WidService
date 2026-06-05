using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RadioStationReports
{

    public partial class UcCisNetImport : UserControl
    {
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
            lvShares.Columns.Add("Пуб %", 60);
            lvShares.Columns.Add("Пуб Тов", 60);
            lvShares.Columns.Add("Мех %", 60);
            lvShares.Columns.Add("Мех Тов", 60);

            lvAltNames.View = View.Tile;
            lvAltNames.TileSize = new Size(100, 20);

            lvPerformers.View = View.Tile;
            lvPerformers.TileSize = new Size(100, 20);
           
        }

        private void FillControls(CisNetSingleWorkImporter.Work work)
        {
            tbWorkName.Text = work.Name;
            tbWorkIswc.Text = work.Iswc;
            tbCisNetCode.Text = $"{work.SocCode}_{work.SourceDb}_{work.SocWorkCode}";

            var seqNr = 1;
            lvShares.Items.Clear();
            work.Shares.ForEach(s => {
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
            work.AltNames.ForEach(n => {
                lvAltNames.Items.Add(n);
            });

            lvPerformers.Items.Clear();
            work.Performers.ForEach(p => {
                lvPerformers.Items.Add(p);
            });

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                var cisNetSingleWorkImporter = new CisNetSingleWorkImporter();
                var work = cisNetSingleWorkImporter.LoadDownloadedFile();
                FillControls(work);
            });
        }

    }
}
