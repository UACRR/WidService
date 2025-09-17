using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    public partial class FormSpecImport : Form
    {
        public FormSpecImport()
        {
            InitializeComponent();
        }

        private void FormSpecImport_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            Helpers.RunSqlCwrT(cmd =>
            {
                cmd.CommandText = "select RecordType from SpecRecords order by SeqNr";
                using (var r = cmd.ExecuteReader())
                {
                    cbRecordType.Items.Clear();
                    while (r.Read())
                    {
                        cbRecordType.Items.Add(r.GetString(0));
                    }
                }
            });
            cbRecordType.SelectedIndex = 0;
        }

        private void ImportFieldSpecs(string recordType, string fieldsInfo)
        {
            var lines = fieldsInfo.Split('\n');
            const int fieldSpecColCnt = 6;
            try
            {
                Helpers.RunSqlCwrT(cmd =>
                {
                    cmd.CommandText = "delete FieldSpecs where RecordType = @RecordType";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@RecordType", recordType);
                    cmd.ExecuteNonQuery();

                    var idxLine = 0;
                    cmd.CommandText = @"
                        insert FieldSpecs (
                              RecordType
	                        , Field
	                        , Start
	                        , Size
	                        , Fmt
	                        , Req
	                        , Description
                        )
                        values (
                              @RecordType
	                        , @Field
	                        , @Start
	                        , @Size
	                        , @Fmt
	                        , @Req
	                        , @Description
                        ) 
                    ";
                    for (var idxField = 0; idxField < lines.Length / fieldSpecColCnt; idxField++) 
                    {
                        var field           = lines[idxLine++]
                                                .TrimEnd('\r')
                                                .Replace(" ", "")
                                                .Replace("-", "")
                                                .Replace("/", "");
                        var start           = int.Parse(lines[idxLine++]);
	                    var size            = int.Parse(lines[idxLine++]);
                        var fmt             = lines[idxLine++].TrimEnd('\r');
	                    var req             = lines[idxLine++].TrimEnd('\r');
	                    var description     = lines[idxLine++].TrimEnd('\r');

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@RecordType"   , recordType  );
                        cmd.Parameters.AddWithValue("@Field"        , field       );
                        cmd.Parameters.AddWithValue("@Start"        , start       );
                        cmd.Parameters.AddWithValue("@Size"         , size        );
                        cmd.Parameters.AddWithValue("@Fmt"          , fmt         );
                        cmd.Parameters.AddWithValue("@Req"          , req         );
                        cmd.Parameters.AddWithValue("@Description"  , description );

                        cmd.ExecuteNonQuery();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Імпорт специфікації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string recordType = cbRecordType.Text;
            string fieldsInfo = tbFields.Text;
            if(string.IsNullOrEmpty(recordType) || string.IsNullOrEmpty(fieldsInfo))
            {
                MessageBox.Show("Не вказана інформація для імпорту", "Імпорт специфікації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var isImported = false;
            Helpers.RunSqlCwrT(cmd =>
            {
                cmd.CommandText = "select * from FieldSpecs where RecordType = @RecordType";
                cmd.Parameters.AddWithValue("@RecordType", recordType);
                using (var r = cmd.ExecuteReader())
                {
                    if(r.HasRows)
                    {
                        isImported = true;
                    }
                }
            });

            if (isImported)
            {
                if (DialogResult.OK != MessageBox.Show("Специфікаії полей вже імпортовані. Повторити?", "Імпорт специфікації", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return;
                }
            }

            ImportFieldSpecs(recordType, fieldsInfo);

            tbFields.Text = "";
            cbRecordType.SelectedIndex = cbRecordType.SelectedIndex < cbRecordType.Items.Count - 1 ? cbRecordType.SelectedIndex++ : -1;
        }
    }
}
