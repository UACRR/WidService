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

namespace WidExport
{
    public partial class UcWidSubmWorkResp : UserControl
    {
        private int? _groupId;
        private int? _respFileId;
        private int? _grpSeqNr;

        public UcWidSubmWorkResp()
        {
            InitializeComponent();
        }

        private void UcWidSubmWorkResp_Load(object sender, EventArgs e)
        {
        }

        public void SetGroupAndObjId(int? groupId, int? objId)
        {
            _groupId = groupId;
            try
            {
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandText = @"
                        declare @LastWiaRecId int = (
                            select isnull(max(t2.Id), 0) as LastWiaRecId
                            from WidSubmGroupWork t1
                                join RecWia t2 on t1.RecWiaId = t2.Id
                            where t1.WidSubmGroupId = @GroupId
                                and t1.ObjId = @objId
                        )

                        declare @SubmFileId int = (select SubmFileId from RecWia where Id = @LastWiaRecId)
                        declare @SubmFileName varchar(max) = (select Name from SubmFile where Id = @SubmFileId)
                        declare @GrpSeqNr int = (select GrpSeqNr from RecWia where Id = @LastWiaRecId)
                        select RespFileId, @GrpSeqNr from RecHdrRsp where FileNameRef = @SubmFileName
                    ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@objId", objId);

                    using(var r = cmd.ExecuteReader())
                    {
                        if(!r.HasRows)
                        {
                            _respFileId = null;
                            _grpSeqNr = null;
                        }
                        else
                        {
                            r.Read();
                            _respFileId = r.GetInt32(0);
                            _grpSeqNr = r.GetInt32(1);
                        }
                    }
                    var presenter = new RespFilePresenter((int)_respFileId, (int)_grpSeqNr, (int)objId);
                    wbErrors.DocumentText = presenter.GetHtml();
                });
            }
            catch(Exception ex)
            {
                wbErrors.DocumentText = ex.Message;
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlElement element = (HtmlElement)sender;
            string value = element.GetAttribute("value");
            MessageBox.Show(this, "Selected: " + value);
        }
    }
}
