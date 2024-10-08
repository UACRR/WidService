using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppleSearch
{
    public partial class FormSelectAuthor : Form
    {
        private string _filter;

        public int? CustId;
        public string AuthorName;

        public FormSelectAuthor()
        {
            InitializeComponent();

        }

        private void FormSelectParty_Load(object sender, EventArgs e)
        {
            _filter = "";
            labFilter.Text = "Перші 100 авторів, чиї ім'я задовільняють шаблону:";

            lvParties.Columns.Add("#", 30);
            lvParties.Columns.Add("CustId", 100);
            lvParties.Columns.Add("Name", 300);
            lvParties.Columns.Add("Source", 100);

            RefreshControls();
        }

        private void RefreshControls()
        {
            if(!_filter.Equals(tbFilter.Text, StringComparison.OrdinalIgnoreCase))
            {
                lvParties.Items.Clear();
            }
            btnSearch.Enabled = !string.IsNullOrEmpty(tbFilter.Text.Trim()) 
                && !_filter.Equals(tbFilter.Text, StringComparison.OrdinalIgnoreCase);
            btnSelect.Enabled = lvParties.SelectedItems.Count == 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Helpers.RunSqlApple(cmd =>
                {
                    cmd.CommandText = @"
                        ; with CustNames as (
                            select 
                                  custId
                                , trim(concat(lastName, ' ', firstName, ' ', surName)) as Name
                                , 'AnketaPerson' as Source
                            from MediaService..AnketaPerson
    
                            union
                            select
                                  custId
                                , trim(shortName)	  as Name
                                , 'AnketaCompanyShort' as Source
                            from MediaService..AnketaCompany
    
                            union
                            select
                                  custId
                                , trim(authorName)  as Name
                                , 'Authors' as Source
                            from MediaService..Authors
                        )
                        select distinct *
                        from CustNames
                        where custId is not null
                            and Name like @authorName
                        order by Name
                    ";
                    cmd.Parameters.AddWithValue("@authorName", $"%{tbFilter.Text}%");
                    using(var r = cmd.ExecuteReader())
                    {
                        lvParties.Items.Clear();
                        var rowIdx = 1;
                        while(r.Read())
                        {
                            var item = lvParties.Items.Add(rowIdx.ToString());
                            var colIdx = 0;
                            item.SubItems.Add(r.GetInt32(colIdx++).ToString());
                            item.SubItems.Add(r.GetString(colIdx++));
                            item.SubItems.Add(r.GetString(colIdx++));
                            rowIdx++;
                        }
                    }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                _filter = tbFilter.Text;
                RefreshControls();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void lvParties_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void lvParties_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void SelectAndClose()
        {
            var item = lvParties.SelectedItems[0];
            CustId = int.Parse(item.SubItems[1].Text);
            AuthorName = item.SubItems[2].Text;

            Close();
        }
    }
}
