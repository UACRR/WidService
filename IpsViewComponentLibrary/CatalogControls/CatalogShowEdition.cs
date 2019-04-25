using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls.Export;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        private GridViewSpreadExport spreadExporter;
        public CatalogShowEdition(CatalogFile file)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            spreadExporter = new GridViewSpreadExport(gridDetailInfo);
            catalogFileBindingSource.DataSource = file;
            pubСatalogItemBindingSource.DataSource = FillGridDetail();
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

        private List<PubСatalogItem> FillGridDetail()
        {
            return new List<PubСatalogItem> {
                new PubСatalogItem {
                    ItemCode = "itemCode",
                    Iswc = "iswc",
                    ObjName = "objName",
                    GenreName = "genreName",
                    RoleName = "roleName",
                    AuthorMusic = "AuthorMusic",
                    AuthorText = "AuthorText",
                    Performer = "Performer",
                    Comment = "comment",
                    CmName = "cmName",
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

        private void CatalogShowEdition_Load(object sender, EventArgs e)
        {

        }
    }
}
