using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Export;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class ctrlCatalogEdition : UserControl
    {
        public EventHandler back;
        private GridViewSpreadExport spreadExporter;
        public ctrlCatalogEdition()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            spreadExporter = new GridViewSpreadExport(gridDetail);
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
