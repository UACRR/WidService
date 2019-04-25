using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls.Export;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        public EventHandler back;
        private GridViewSpreadExport spreadExporter;
        public CatalogShowEdition()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            spreadExporter = new GridViewSpreadExport(gridDetail);
            //catalogFileBindingSource.DataSource = FillFileData();
            bsPubCatalog.DataSource = FillGridDetail();
        }

        private void btnGetExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "exportFile";
            spreadExporter.ExportFormat = SpreadExportFormat.Xlsx;
            dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SpreadExportRenderer renderer = new SpreadExportRenderer();
                spreadExporter.RunExport(dialog.FileName, renderer);
            }
        }

        private List<PubCatalogItem> FillGridDetail()
        {
            return new List<PubCatalogItem> {
                new PubCatalogItem {
                    ItemCode = "itemCode",
                    Iswc = "iswc",
                    ObjName = "objName",
                    GenreName = "genreName",
                    RoleName = "roleName",
                    AuthorMusic = "AuthorMusic",
                    AuthorText = "AuthorText",
                    Performer = "Performer",
                    Comment = "comment",
                    ErrComment = "ErrComment"
                }
            };
        }

        private List<CatalogFile> FillFileData()
        {
            return new List<CatalogFile> {
                new CatalogFile {

                }
            };
        }

        private void btnControl_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            back.Invoke(sender, e);
        }
    }
}
