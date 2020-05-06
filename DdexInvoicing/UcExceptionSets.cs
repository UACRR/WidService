using InvoicingLib;
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
    public partial class UcExceptionSets : UserControl
    {
        public enum Mode
        {
            Edit, Assign
        }

        private Mode mode;

        public UcExceptionSets()
        {
            InitializeComponent();
        }

        public void Init(Mode mode)
        {
            this.mode = mode;
            radBtnNewExc.Visible = 
            radGrid.Columns["Show"].IsVisible =
            radGrid.Columns["Delete"].IsVisible =
            radGrid.Columns["Clone"].IsVisible =
                mode == Mode.Edit;
           FillExceptionSets();
        }

        public int GetSetCode()
        {
            if (radGrid.CurrentRow == null)
                return 0;
            int setCode = (int)radGrid.CurrentRow.Cells["setCode"].Value;
            return setCode;
        }

        private void FillExceptionSets()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select setCode
                        , t1.setName setName
                        , t2.name setStatus
                        , case when isUsed = 0 then 'Ні' else 'Так' end isUsed
                        , dateCreated
                        , dateUpdated
                    , 'Показати' Show
                    , 'Видалити' [Delete]
                    , 'Створити копію' Clone
                    , 'Застосувати' Apply
                    from ExceptionSet t1
                        join ExceptionSetStatus t2 on t2.codeI = t1.setStatus
                    order by setCode
                ";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                radGrid.DataSource = dt;
            });
        }

        private void AddExceptionSet()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    insert ExceptionSet (
                            setName
                          , setComment
                          , setStatus
                          , isUsed
                          , dateCreated
                          , dateUpdated)
                    select 'Нова конфігурація'
                          , ''
                          , 0
                          , 0
                          , GetDate()
                          , GetDate()";
                cmd.ExecuteNonQuery();
                FillExceptionSets();
                radGrid.Rows[radGrid.Rows.Count - 1].IsCurrent = true;
            });
        }

        private void CloneExceptionSet(int setCode)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "spCopyExceptionSet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.ExecuteNonQuery();
                FillExceptionSets();
                radGrid.Rows[radGrid.Rows.Count - 1].IsCurrent = true;
            });
        }

        private void DeleteExceptionSet(int setCode)
        {
            if (MessageBox.Show("Видалити?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select setStatus from ExceptionSet where setCode = @setCode";
                cmd.Parameters.AddWithValue("@setCode", setCode);
                int setStatus = (int)cmd.ExecuteScalar();
                if (setStatus != 0)
                {
                    MessageBox.Show("Дану конфігурацію виключень не можна видаляти", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                cmd.CommandText = "spDeleteExceptionSet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.Parameters.AddWithValue("@membersOnly", false);
                cmd.ExecuteNonQuery();
                FillExceptionSets();
            });
        }

        private void ShowExceptionSet(int setCode)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select setStatus from ExceptionSet where setCode = @setCode";
                cmd.Parameters.AddWithValue("@setCode", setCode);
                int setStatus = (int)cmd.ExecuteScalar();
                var curRowIndex = radGrid.CurrentRow.Index;
                var form = new FormExceptionSet(setCode, setStatus == 0 ? FormExceptionSet.Mode.Edit : FormExceptionSet.Mode.View);
                form.ShowDialog();
                FillExceptionSets();
                radGrid.CurrentRow = radGrid.Rows[curRowIndex];
            });
        }

        private void ApplyExceptionSet(int setCode)
        {

        }

        private void radBtnNewExc_Click(object sender, EventArgs e)
        {
            AddExceptionSet();
        }

        private void radGrid_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int setCode = (int)e.Row.Cells["setCode"].Value;

            if (e.Column.FieldName.Equals("Show", StringComparison.OrdinalIgnoreCase))
            {
                ShowExceptionSet(setCode);
            }
            else if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                DeleteExceptionSet(setCode);
            }
            else if (e.Column.FieldName.Equals("Clone", StringComparison.OrdinalIgnoreCase))
            {
                CloneExceptionSet(setCode);
            }
            else if (e.Column.FieldName.Equals("Apply", StringComparison.OrdinalIgnoreCase))
            {
                ApplyExceptionSet(setCode);
            }
        }
    }
}
