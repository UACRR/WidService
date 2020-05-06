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
    public partial class FormExceptionSet : Form
    {
        public class GenericRightHolder
        {
            public DataTable dtRightHolders = new DataTable();
            public DataTable dtAddCommunities = new DataTable();
        }

        public enum Mode
        {
            View, Edit
        }

        private int setCode;
        private Mode mode;

        private DataTable dtCommunities= new DataTable();
        private DataTable dtGenericRightHolders = new DataTable();

        private Dictionary<string, GenericRightHolder> genericRightHolders = new Dictionary<string, GenericRightHolder>(StringComparer.OrdinalIgnoreCase);

        private string oldGRHName;
        private bool isDirty = false;

        public FormExceptionSet(int setCode, Mode mode)
        {
            InitializeComponent();
            this.setCode = setCode;
            this.mode = mode;
        }

        private void FormExceptionSet_Load(object sender, EventArgs e)
        {
            FillCodeAndName();
            LoadCommunities();
            LoadGenericRightHolders();
            LoadRightHolders();
            LoadAddCommunities();

            FillCommunities();
            FillGenericRightHolders();
            FillRightHolders();
            FillAddCommunities();

            SetDirty(false);

            /*
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select setStatus from ExceptionSet where setCode = @setCode";
                cmd.Parameters.AddWithValue("@setCode", setCode);
                int setStatus = (int)cmd.ExecuteScalar();
                isViewMode = setStatus != 0;
            });
            */

            radTbName.ReadOnly = mode != Mode.Edit;
            radBtnEditExcCommunities.Enabled = 
            radBtnAddRightHolder.Enabled = 
            radBtnEditRightHolders.Enabled = 
            radBtnEditRhCommunities.Enabled = 

            radGridCommunities.Columns["Delete"].IsVisible = 
            radGridGenericRightHolders.Columns["Delete"].IsVisible = 
            radGridRightHolders.Columns["Delete"].IsVisible = 
            radGridAddCommunities.Columns["Delete"].IsVisible = mode == Mode.Edit;
        }

        private void SetDirty(bool isDirty)
        {
            this.isDirty = isDirty;
            radBtnSave.Enabled = isDirty;
        }

        private void LoadCommunities()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select *
                    from ExceptionMember
                    where setCode = @setCode and excType = 1
                ";
                cmd.Parameters.AddWithValue("@setCode", setCode);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCommunities);
                if(dtCommunities.Rows.Count > 0)
                    dtCommunities = dtCommunities.Select("", "memberName asc").CopyToDataTable();
            });
        }

        private void LoadGenericRightHolders()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select distinct nameForSeek, 0 excType
                    from ExceptionMember
                    where setCode = @setCode and excType in (2, 3)
                ";
                cmd.Parameters.AddWithValue("@setCode", setCode);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtGenericRightHolders);
                if(dtGenericRightHolders.Rows.Count > 0)
                    dtGenericRightHolders = dtGenericRightHolders.Select("", "nameForSeek asc").CopyToDataTable();
                foreach (DataRow row in dtGenericRightHolders.Rows)
                {
                    genericRightHolders.Add((string)row["nameForSeek"], new GenericRightHolder());
                }
            });
        }

        private void LoadRightHolders()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.Parameters.AddWithValue("@nameForSeek", "");

                foreach (DataRow row in dtGenericRightHolders.Rows)
                {
                    cmd.CommandText = $@"
                        select *
                        from ExceptionMember
                        where setCode = @setCode and excType in (2, 3)
                            and nameForSeek = @nameForSeek
                    ";
                    cmd.Parameters["@nameForSeek"].Value = row["nameForSeek"];
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        dt = dt.Select("", "memberName asc").CopyToDataTable();
                    genericRightHolders[(string)row["nameForSeek"]].dtRightHolders = dt;
                }
            });
        }

        private void LoadAddCommunities()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.Parameters.AddWithValue("@nameForSeek", "");

                foreach (DataRow row in dtGenericRightHolders.Rows)
                {
                    cmd.CommandText = $@"
                        select distinct 
                              cast(0 as int) id
                            , cast(0 as int) excId
                            , cast(0 as int) custId
                            , t1.interCode interCode
                            , t1.name memberName
                            , t1.name nameForSeek
                            , t1.interCode IPInr
                            , cast(GetDate() as datetime) dateCreated
                        from ExceptionAdd t1
                            join ExceptionMember t2 on t2.Id = t1.excId
                        where t2.setCode = @setCode and t2.excType in (2, 3)
                            and t2.nameForSeek = @nameForSeek
                    ";
                    cmd.Parameters["@nameForSeek"].Value = row["nameForSeek"];
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        dt = dt.Select("", "memberName asc").CopyToDataTable();
                    genericRightHolders[(string)row["nameForSeek"]].dtAddCommunities = dt;
                    row["excType"] = dt.Rows.Count > 0 ? 3 : 2;
                }
            });
        }

        private void FillCodeAndName()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select setCode
                        , setName
                    from ExceptionSet
                    where setCode = @setCode
                ";
                cmd.Parameters.AddWithValue("@setCode", setCode);
                SqlDataReader r = cmd.ExecuteReader();
                r.Read();
                radTbNumber.Text = r.GetInt32(0).ToString();
                radTbName.Text = r.GetString(1);
            });
        }

        private void FillCommunities()
        {
            radGridCommunities.DataSource = dtCommunities;
        }

        private void FillGenericRightHolders()
        {
            radGridGenericRightHolders.DataSource = dtGenericRightHolders;
        }

        private void FillRightHolders()
        {
            var curRow = radGridGenericRightHolders.CurrentRow;
            if (curRow  == null)
                return;
            string key = (string)((DataRowView)radGridGenericRightHolders.CurrentRow.DataBoundItem).Row["nameForSeek"];
            radGridRightHolders.DataSource = genericRightHolders[key].dtRightHolders;
        }

        private void FillAddCommunities()
        {
            var curRow = radGridGenericRightHolders.CurrentRow;
            if (curRow == null)
                return;
            string key = (string)((DataRowView)radGridGenericRightHolders.CurrentRow.DataBoundItem).Row["nameForSeek"];
            radGridAddCommunities.DataSource = genericRightHolders[key].dtAddCommunities;
        }

        private void AddGenericRightHolder(string genericRightHolder, bool addRow = true)
        {
            var newGenericRightHolder = addRow ? new GenericRightHolder() : genericRightHolders[genericRightHolder];

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select 0 id
                        , cast('20190101' as Date) dateBegin
                        , cast('20191231' as Date) dateEnd
                        , @setCode setCode
                        , cast(null as int) rHolderType
                        , NAME memberName
                        , cast(null as varchar(100)) nameForSeek  
                        , IP_BASE_NR interCode
                        , 2 excType
                        , cast(null as int) custId
                        , cast(null as varchar(100)) comment
                        , IP_NAME_NR IPInr 
                        , GetDate() dateCreated 
                    from WID_IPI..TBLIPINAME 
                    where name like @nameForSeek
                ";
                cmd.Parameters.AddWithValue("@nameForSeek", $"%{genericRightHolder}%");
                cmd.Parameters.AddWithValue("@setCode", setCode);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    dt = dt.Select("", "memberName asc").CopyToDataTable();
                newGenericRightHolder.dtRightHolders = dt;

                cmd.CommandText = $@"
                    select distinct 
                              cast(0 as int) id
                            , cast(0 as int) excId
                            , cast(0 as int) custId
                            , interCode interCode
                            , name memberName
                            , name nameForSeek
                            , interCode IPInr
                            , cast(GetDate() as datetime) dateCreated
                    from ExceptionAdd
                    where id = -1
                ";
                dt = new DataTable();
                da.Fill(dt);
                newGenericRightHolder.dtAddCommunities = dt;
            });

            if (addRow)
            {
                genericRightHolders.Add(genericRightHolder, newGenericRightHolder);
                DataRow row = dtGenericRightHolders.NewRow();
                row["nameForSeek"] = genericRightHolder;
                dtGenericRightHolders.Rows.Add(row);
            }

            if (dtGenericRightHolders.Rows.Count > 0)
                dtGenericRightHolders = dtGenericRightHolders.Select("", "nameForSeek asc").CopyToDataTable();

            FillGenericRightHolders();
            FillRightHolders();

            GridViewRowInfo gridRow = radGridGenericRightHolders.Rows
                .Where(r => r.Cells["nameForSeek"].Value.ToString().Equals(genericRightHolder))
                .First();

            radGridGenericRightHolders.Rows[gridRow.Index].IsCurrent = true;

            SetDirty(true);

        }

        private void DeleteGenericRightHolder(string name)
        {
            genericRightHolders.Remove(name);
            FillRightHolders();
            FillAddCommunities();
            SetDirty(true);

        }

        private void EditExcCommunities()
        {
            DataTable dtLeft = new DataTable();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.CommandText = $@"
                    select
                          0 id
                        , dateBegin dateBegin
                        , dateEnd dateEnd
                        , @setCode setCode
                        , rHolderType rHolderType
                        , Name memberName
                        , Name nameForSeek
                        , interCode interCode
                        , 1 excType
                        , custId custId
                        , '' comment
                        , interCode IPInr
                        , GetDate() dateCreated
                    from vMSCommunity
                ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLeft);
            });
            var form = new FormObjectChooser(dtLeft, dtCommunities);
            if(form.ShowDialog() == DialogResult.Cancel)
                return;
            dtCommunities = form.GetRightTable();
            if (dtCommunities.Rows.Count > 0)
                dtCommunities = dtCommunities.Select("", "memberName asc").CopyToDataTable();
            radGridCommunities.DataSource = dtCommunities;
            SetDirty(true);

        }

        private void EditRhCommunities()
        {
            if (radGridGenericRightHolders.CurrentRow == null)
                return;
            DataTable dtLeft = new DataTable();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.CommandText = $@"
                    select
                          0 id
                        , 0 excId
                        , 0 custId
                        , interCode interCode
                        , name memberName
                        , name nameForSeek
                        , interCode IPInr
                        , GetDate() dateCreated
                  from vMSCommunity
                ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLeft);
            });
            string key = (string)radGridGenericRightHolders.CurrentRow.Cells["nameForSeek"].Value;
            DataTable dtRight = genericRightHolders[key].dtAddCommunities;
            var form = new FormObjectChooser(dtLeft, dtRight);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;
            DataTable dtRhCommunities = form.GetRightTable();
            if(dtRhCommunities.Rows.Count > 0)
                dtRhCommunities = dtRhCommunities.Select("", "memberName asc").CopyToDataTable();
            genericRightHolders[key].dtAddCommunities = dtRhCommunities;
            FillAddCommunities();
            radGridGenericRightHolders.CurrentRow.Cells["excType"].Value = dtRhCommunities.Rows.Count > 0 ? 3 : 2;
            SetDirty(true);
        }

        private void EditRightHolders()
        {
            if (radGridGenericRightHolders.CurrentRow == null)
                return;
            string key = (string)radGridGenericRightHolders.CurrentRow.Cells["nameForSeek"].Value;
            DataTable dtLeft = new DataTable();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select  '2019-01-01' dateBegin
                        , '2019-12-31' dateEnd
                        , 1 setCode
                        , null rHolderType
                        , NAME memberName
                        , cast(null as varchar(100)) nameForSeek  
                        , IP_BASE_NR interCode
                        , null excType
                        , null custId
                        , null comment
                        , IP_NAME_NR IPInr 
                        , GetDate() dateCreated 
                    from WID_IPI..TBLIPINAME 
                    where name like @nameForSeek
                ";
                cmd.Parameters.AddWithValue("@nameForSeek", $"%{key}%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLeft);
             });

            DataTable dtRight = genericRightHolders[key].dtRightHolders;
            var form = new FormObjectChooser(dtLeft, dtRight);
            //var form = new FormObjectChooser(dtLeft, dtRight, "interCode", "interCode");
            if (form.ShowDialog() == DialogResult.Cancel)
                return;
            DataTable dtRightHolders = form.GetRightTable();
            if (dtRightHolders.Rows.Count > 0)
                dtRightHolders = dtRightHolders.Select("", "memberName asc").CopyToDataTable();
            genericRightHolders[key].dtRightHolders = dtRightHolders;
            FillRightHolders();
            SetDirty(true);

        }

        private void Save()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                int excId = 1;
                int addId = 1;

                dtCommunities.AcceptChanges();
                DataTable dtExceptionMember = dtCommunities.Copy();
                foreach (DataRow row in dtExceptionMember.Rows)
                {
                    row["id"] = excId;
                    row["excType"] = 1;
                    excId++;
                }

                DataTable dtExceptionAdd = null;
                foreach (var pair in genericRightHolders)
                {
                    string grhName = pair.Key;
                    var grh = pair.Value;
                    int rhType = grh.dtAddCommunities.Rows.Count > 0 ? 3 : 2;
                    grh.dtRightHolders.AcceptChanges();
                    DataTable dtExcRightHolders = grh.dtRightHolders.Copy();

                    if (dtExceptionAdd == null)
                        dtExceptionAdd = grh.dtAddCommunities.Clone();
                    grh.dtAddCommunities.AcceptChanges();
                    DataTable dtCurAddCommunities = grh.dtAddCommunities.Copy();

                    foreach (DataRow row in dtExcRightHolders.Rows)
                    {
                        row["id"] = excId;
                        row["dateBegin"] =  new DateTime(2019, 1, 1);
                        row["dateEnd"] = new DateTime(2019, 12, 31);
                        row["setCode"] = setCode;
                        row["rHolderType"] = DBNull.Value;
                        row["nameForSeek"] = grhName;
                        row["excType"] = rhType;
                        row["custId"] = DBNull.Value;
                        row["comment"] = DBNull.Value;

                        foreach (DataRow rowAdd in dtCurAddCommunities.Rows)
                        {
                            rowAdd["id"] = addId;
                            rowAdd["excId"] = excId;
                            rowAdd["custId"] = DBNull.Value;
                            rowAdd["dateCreated"] = DateTime.Now;
                            addId++;
                        }
                        dtExceptionAdd.Merge(dtCurAddCommunities);
                        excId++;
                    }
                    dtExceptionMember.Merge(dtExcRightHolders);
                }

                cmd.CommandText = @"spSaveExceptionSet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.Parameters.AddWithValue("@newSetName", radTbName.Text);
                cmd.Parameters.Add("@ExceptionMember", SqlDbType.Structured).Value = dtExceptionMember;
                cmd.Parameters.AddWithValue("@ExceptionAdd", SqlDbType.Structured).Value = dtExceptionAdd;
                cmd.ExecuteNonQuery();
            });

            SetDirty(false);
        }

        private void radBtnAddRightHolder_Click(object sender, EventArgs e)
        {
            var form = new FormRightHolderGroup(genericRightHolders);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;
            AddGenericRightHolder(form.genericRightHolder);
        }

        private void radBtnEditExcCommunities_Click(object sender, EventArgs e)
        {
            EditExcCommunities();
        }

        private void radBtnEditRhCommunities_Click(object sender, EventArgs e)
        {
            EditRhCommunities();
        }

        private void radBtnEditRightHolders_Click(object sender, EventArgs e)
        {
            EditRightHolders();
        }

        private void radGridGenericRightHolders_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            FillRightHolders();
            FillAddCommunities();
        }

        private void radGridGenericRightHolders_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("excType", StringComparison.OrdinalIgnoreCase))
            {
                if (e.CellElement.Value == null || e.CellElement.Value is DBNull)
                    e.CellElement.Text = "Ні";
                else
                    e.CellElement.Text = (int)e.CellElement.Value == 3 ? "Так" : "Ні";
           }
            else if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Видалити";
            }
        }

        private void radGridGenericRightHolders_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                if (MessageBox.Show("Видалити правовласників даної групи із списку виключень?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string key = (string)((DataRowView)e.Row.DataBoundItem).Row["nameForSeek"];
                e.Row.Delete();
                DeleteGenericRightHolder(key);
            }

        }

        private void radBtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            if (isDirty && MessageBox.Show("Зберегти останні зміни?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Save();
            Close();
        }

        private void radGridGenericRightHolders_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.FieldName.Equals("excType", StringComparison.OrdinalIgnoreCase))
            {
                e.Cancel = true;
                return;
            }
            oldGRHName = (string)radGridGenericRightHolders.CurrentCell.Value;
        }

        private void radGridGenericRightHolders_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            string newGRHName = (string)radGridGenericRightHolders.CurrentCell.Value;
            if (newGRHName.Equals(oldGRHName, StringComparison.OrdinalIgnoreCase))
                return;
            if (genericRightHolders.ContainsKey(newGRHName))
            {
                MessageBox.Show("Дана загальна назва вже використовується", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                radGridGenericRightHolders.CurrentCell.Value = oldGRHName;
                return;
            }
            genericRightHolders.Add(newGRHName, genericRightHolders[oldGRHName]);
            genericRightHolders.Remove(oldGRHName);
            AddGenericRightHolder(newGRHName, false);
        }

        private void radGridRightHolders_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Видалити";
            }
        }

        private void radGridRightHolders_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                e.Row.Delete();
                SetDirty(true);
            }
        }

        private void radGridCommunities_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Видалити";
            }
        }

        private void radGridCommunities_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                e.Row.Delete();
                SetDirty(true);
            }
        }

        private void radGridAddCommunities_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Видалити";
            }
        }

        private void radGridAddCommunities_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                e.Row.Delete();
                SetDirty(true);
            }
        }

        private void radTbName_TextChanged(object sender, EventArgs e)
        {
            SetDirty(true);
        }
    }
}
