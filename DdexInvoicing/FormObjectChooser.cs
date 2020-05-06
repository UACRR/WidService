using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DdexInvoicing
{
    public partial class FormObjectChooser : Form
    {
        private const string IdentityFieldName = "IPInr";
        private const string NameFieldName = "memberName";

        private DataTable dtLeft;
        private DataTable dtRight;
        
        public FormObjectChooser(DataTable dtLeft, DataTable dtRight)
        {
            InitializeComponent();
            dtLeft.AcceptChanges();
            dtRight.AcceptChanges();
            this.dtLeft = dtLeft;
            this.dtRight = dtRight;
        }

        public DataTable GetRightTable() => (DataTable)radGridRight.DataSource;

        private void FormObjectChooser_Load(object sender, EventArgs e)
        {
            radGridLeft.MasterView.TableSearchRow.ShowCloseButton = false;
            radGridRight.MasterView.TableSearchRow.ShowCloseButton = false;

            FillSelected();
            FillAvailable();

        }

        private void radBtnShow_Click(object sender, EventArgs e)
        {
            FillAvailable();
        }

        private void FillAvailable()
        {
            if(dtLeft.Rows.Count > 0)
                dtLeft = dtLeft.Select("", $"{NameFieldName} asc").CopyToDataTable();
            radGridLeft.DataSource = dtLeft;
        }

        private void FillSelected()
        {
            Dictionary<string, DataRow> leftInterCodes = new Dictionary<string, DataRow>();
            foreach(DataRow row in dtLeft.Rows)
            {
                leftInterCodes.Add((string)row[IdentityFieldName], row);
            }

            foreach (DataRow row in dtRight.Rows)
            {
                string key = (string)row[IdentityFieldName];
                if (leftInterCodes.ContainsKey(key))
                    dtLeft.Rows.Remove(leftInterCodes[key]);
            }

            if(dtRight.Rows.Count > 0)
                dtRight = dtRight.Select("", $"{NameFieldName} asc").CopyToDataTable();
            radGridRight.DataSource = dtRight;
        }

        private void MoveRow(RadGridView sourceGrid, RadGridView targetGrid)
        {
            if (sourceGrid.CurrentRow == null)
                return;

            DataTable sourceDt = (DataTable)sourceGrid.DataSource;
            DataTable targetDt = (DataTable)targetGrid.DataSource;

            DataRow sourceRow = ((DataRowView)sourceGrid.CurrentRow.DataBoundItem).Row;
            targetDt.ImportRow(sourceRow);
            
            int sourceRowIndex = sourceGrid.CurrentRow.Index;
            string sourceIdentityValue = (string)sourceDt.Rows[sourceRowIndex][IdentityFieldName];
            int nextSourceRowIndex = -1;
            if (sourceRowIndex < sourceGrid.Rows.Count - 1)
                nextSourceRowIndex = sourceRowIndex;
            else if (sourceRowIndex > 0)
                nextSourceRowIndex = sourceRowIndex - 1;

            sourceDt.Rows.RemoveAt(sourceRowIndex);

            if (nextSourceRowIndex != -1)
                sourceGrid.CurrentRow = sourceGrid.Rows[nextSourceRowIndex];

            targetDt = targetDt.Select("", $"{NameFieldName} asc").CopyToDataTable();
            targetGrid.DataSource = targetDt;

            int targetRowIndex = 0;
            foreach(DataRow row in targetDt.Rows)
            {
                if (((string)row[IdentityFieldName]).Equals(sourceIdentityValue, StringComparison.OrdinalIgnoreCase))
                    break;
                targetRowIndex++;
            }
            targetGrid.CurrentRow = targetGrid.Rows[targetRowIndex];
        }

        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            MoveRow(radGridLeft, radGridRight);
        }

        private void radBtnRemove_Click(object sender, EventArgs e)
        {
            MoveRow(radGridRight, radGridLeft);
        }

        private void radGridLeft_DoubleClick(object sender, EventArgs e)
        {
           MoveRow(radGridLeft, radGridRight);
        }

        private void radGridRight_DoubleClick(object sender, EventArgs e)
        {
            MoveRow(radGridRight, radGridLeft);
        }

        private void radGridLeft_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
                MoveRow(radGridLeft, radGridRight);
        }

        private void radGridRight_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                MoveRow(radGridRight, radGridLeft);
        }

        private void radBtnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
