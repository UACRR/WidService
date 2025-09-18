using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CwrTools.MetaData;

namespace CwrTools
{
    public partial class FormMain : Form
    {
        private Dictionary<string, BulkUploadToSql> _bulkLoaders;

        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 0;
            ucOutputFiles.RefreshData();
        }

        private void DropAllGeneratedTables()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = $"select Name from Sys.Tables where left(name, 3) = 'Rec'";
                var tableNames = new List<string>();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        tableNames.Add(r.GetString(0));
                    }
                }

                var failed = true;
                while (failed)
                {
                    failed = false;
                    tableNames.ForEach(x =>
                     {
                         try
                         {
                             cmd.CommandText = $"drop table if exists {x}";
                             cmd.ExecuteNonQuery();
                         }
                         catch
                         {
                             failed = true;
                         }
                     });
                }
            });
        }

        private void CreateTable(MetaData.SpecRecord specRecord)
        {
            var tableName = specRecord.TableName;
            var sw = new StringWriter();

            sw.WriteLine($@"
                create table {tableName} ( 
                      {tableName}Id int primary key identity(1, 1)
                    , CwrFileId int
            ");

            switch (specRecord.RecordType)
            {
                case "HDR":
                    break;
                case "GRH":
                    sw.WriteLine(", RecHdrId int null");
                    break;
                case "GRT":
                    sw.WriteLine(", RecGrhId int null");
                    break;
                case "TRL":
                    sw.WriteLine(", RecHdrId int null");
                    break;
                default:
                    if (specRecord.IsTran)
                    {
                        sw.WriteLine(", BaseRecTranId int null");
                        sw.WriteLine(", TranSeqNr int not null");
                    }
                    else
                    {
                        sw.WriteLine(", BaseRecTranId int null");
                        sw.WriteLine(", TranRecordType char(3)");
                        sw.WriteLine(", TranSeqNr int not null");
                        sw.WriteLine(", RecSeqNr int not null");
                    }
                    break;
            }

            specRecord.SpecFields.ForEach(spec =>
            {
                if (string.Compare(spec.Field, "RecordPrefix", StringComparison.OrdinalIgnoreCase) != 0 &&
                    string.Compare(spec.Field, "RecordType", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    var sqlType = "";
                    switch (spec.Fmt)
                    {
                        case "A": sqlType = $"varchar({spec.Size})"; break;
                        case "B": sqlType = "bit"; break;
                        case "D": sqlType = "date"; break;
                        case "F": sqlType = "bit"; break;
                        case "L": sqlType = $"varchar({spec.Size})"; break;
                        case "N": sqlType = $"varchar({spec.Size})"; break;
                        case "T": sqlType = "time"; break;
                    }

                    sw.WriteLine($", {spec.ColName} {sqlType}");
                }
            });

            sw.WriteLine(")");

            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = sw.ToString();
                cmd.ExecuteNonQuery();

                switch (specRecord.RecordType)
                {
                    case "HDR":
                        cmd.CommandText = "alter table RecHdr add constraint fk_RecHdr_CwrFile foreign key (CwrFileId) references CwrFiles(CwrFileId)";
                        break;
                    case "GRH":
                        cmd.CommandText = "alter table RecGrh add constraint fk_RecGrh_RecHdr foreign key (RecHdrId) references RecHdr(RecHdrId)";
                        break;
                    case "GRT":
                        cmd.CommandText = "alter table RecGrt add constraint fk_RecGrt_RecGrh foreign key (RecGrhId) references RecGrh(RecGrhId)";
                        break;
                    case "TRL":
                        cmd.CommandText = "alter table RecTrl add constraint fk_RecTrl_RecHdr foreign key (RecHdrId) references RecHdr(RecHdrId)";
                        break;
                    default:
                        cmd.CommandText = $"alter table {tableName} add constraint fk_{tableName}_BaseRecTran foreign key (BaseRecTranId) references BaseRecTran(BaseRecTranId)";
                        break;
                }
                cmd.ExecuteNonQuery();

            });

        }

        private void CreateTables()
        {
            var recordSpecs = MetaData.GetSpecRecords();
            recordSpecs.ForEach(x =>
            {
                CreateTable(x);
            });
        }

        private void CreateClass(MetaData.SpecRecord specRecord)
        {
            var className = specRecord.TableName;
            var baseClassText = specRecord.IsTran ? " : BaseRecTran" :
                specRecord.IsDetail ? " : BaseRecDetail" :
                " : BaseRec";
            var sw = new StringWriter();

            sw.WriteLine("using System;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine("using System.IO;");
            sw.WriteLine("");

            sw.WriteLine("namespace CwrTools");
            sw.WriteLine("{");
            sw.WriteLine($"    public class {className}{baseClassText}");
            sw.WriteLine("    {");

            specRecord.SpecFields.ForEach(spec =>
            {
                if (string.Compare(spec.Field, "RecordPrefix", StringComparison.OrdinalIgnoreCase) != 0 &&
                    string.Compare(spec.Field, "RecordType", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    var dataType = "";
                    switch (spec.Fmt)
                    {
                        case "A": dataType = "string"; break;
                        case "B": dataType = "bool"; if (!spec.IsMandatory) dataType += '?'; break;
                        case "D": dataType = "DateTime"; if (!spec.IsMandatory) dataType += '?'; break;
                        case "F": dataType = "char"; if (!spec.IsMandatory) dataType += '?'; break;
                        case "L": dataType = "string"; break;
                        case "N": dataType = "string"; break;
                        case "T": dataType = "TimeSpan"; if (!spec.IsMandatory) dataType += '?'; break;
                    }

                    sw.WriteLine($"        public {dataType} {spec.ColName} {{ get; set; }}");
                }
            });

            switch (specRecord.RecordType)
            {
                case "HDR":
                    sw.WriteLine("");
                    sw.WriteLine("        public RecTrl RecTrl { get; set; }");
                    sw.WriteLine("        public List<RecGrh> GroupList { get; set; }");
                    break;
                case "GRH":
                    sw.WriteLine("");
                    sw.WriteLine("        public RecGrt RecGrt { get; set; }");
                    sw.WriteLine("        public List<BaseRecTran> TranList { get; set; }");
                    break;
                default:
                    break;
            }

            sw.WriteLine("");
            sw.WriteLine("        public override void FromLine(string line)");
            sw.WriteLine("        {");
            specRecord.SpecFields.ForEach(spec =>
            {
                if (string.Compare(spec.Field, "RecordPrefix", StringComparison.OrdinalIgnoreCase) != 0 &&
                    string.Compare(spec.Field, "RecordType", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    var dataType = "";
                    switch (spec.Fmt)
                    {
                        case "A": dataType = "string"; break;
                        case "B": dataType = "bool"; if (!spec.IsMandatory) dataType += '?'; break;
                        case "D": dataType = "DateTime"; if (!spec.IsMandatory) dataType += '?'; break;
                        case "F": dataType = "char"; if (!spec.IsMandatory) dataType += '?'; break;
                        case "L": dataType = "string"; break;
                        case "N": dataType = "string"; break;
                        case "T": dataType = "TimeSpan"; if (!spec.IsMandatory) dataType += '?'; break;
                    }

                    sw.WriteLine($"            {spec.ColName} = ({dataType})Parse{spec.Fmt}(line.Substring({spec.Start - 1}, {spec.Size}));");
                }
            });
            sw.WriteLine("        }");

            sw.WriteLine("");
            sw.WriteLine("        public override string ToFileLine(int tranSeqNr, int recSeqNr)");
            sw.WriteLine("        {");
            sw.WriteLine("            var sw = new StringWriter();");
            sw.WriteLine($"            sw.Write(\"{specRecord.RecordType}\");");
            if(specRecord.IsTran || specRecord.IsDetail)
            {
                sw.WriteLine("            sw.Write(FormatSeqNr(tranSeqNr, 8));");
                sw.WriteLine("            sw.Write(FormatSeqNr(recSeqNr, 8));");
            }
            specRecord.SpecFields.ForEach(spec =>
            {
                if (string.Compare(spec.Field, "RecordPrefix", StringComparison.OrdinalIgnoreCase) != 0 &&
                    string.Compare(spec.Field, "RecordType", StringComparison.OrdinalIgnoreCase) != 0)
                {
                    sw.WriteLine($"            sw.Write(FormatField{spec.Fmt}({spec.ColName}, {spec.Size}));");
                }
            });
            sw.WriteLine("            return sw.ToString();");
            sw.WriteLine("        }");

            sw.WriteLine("    }");
            sw.WriteLine("}");

            var res = sw.ToString();
            var fileName = $@"D:\OlegM\Sources\WidService\CwrTools\Entities\{className}.cs";
            File.WriteAllText(fileName, res);
        }
        
        private void CreateClasses()
        {
            var recordSpecs = MetaData.GetSpecRecords();
            recordSpecs.ForEach(x =>
            {
                CreateClass(x);
            });
        }

        private void CreateProcedures()
        {
            var recordTypeCap = "";
            Helpers.RunSqlCwr(cmd =>
            {
                MetaData.GetSpecTranRecords().ForEach(x =>
                {
                    recordTypeCap = x.RecordType.ToLower();
                    recordTypeCap = char.ToUpper(recordTypeCap[0]) + recordTypeCap.Substring(1);
                    cmd.CommandText = $@"
create or alter procedure spCreateReferences{recordTypeCap}
	@cwrFileId int
as
begin
	declare @rowNumberShift int = (select isnull(max(BaseRecTranId), 0) from BaseRecTran)
	drop table if exists #BaseRecTranRows
	select 
		    @rowNumberShift + row_number() over (order by TranSeqNr) as BaseRecTranId
		, t2.RecGrhId
        , '{x.RecordType}' as RecordType
		, t1.TranSeqNr
		, t1.Rec{recordTypeCap}Id as RecId
	into #BaseRecTranRows
	from {x.TableName} t1
		join RecGrh t2 on t2.TranType = '{x.RecordType}'
		    and t1.CwrFileId = t2.CwrFileId
	where t1.CwrFileId = @cwrFileId

	insert BaseRecTran(BaseRecTranId, CwrFileId, RecGrhId, RecordType, TranSeqNr)
	select BaseRecTranId, @cwrFileId, RecGrhId, RecordType, TranSeqNr
	from #BaseRecTranRows

	update t2
	set t2.BaseRecTranId = t1.BaseRecTranId
	from #BaseRecTranRows t1
		join {x.TableName} t2 on t1.RecId = t2.Rec{recordTypeCap}Id
end 
";
                    cmd.ExecuteNonQuery();
                });

                MetaData.GetSpecDetailRecords().ForEach(x =>
                {
                    recordTypeCap = x.RecordType.ToLower();
                    recordTypeCap = char.ToUpper(recordTypeCap[0]) + recordTypeCap.Substring(1);
                    cmd.CommandText = $@"
create or alter procedure spCreateReferences{recordTypeCap}
	@cwrFileId int
as
    begin
    update t2
    set t2.BaseRecTranId = t1.BaseRecTranId
    from BaseRecTran t1
	    join {x.TableName} t2 on t1.CwrFileId = t2.CwrFileId
		    and t1.RecordType = t2.TranRecordType
		    and t1.TranSeqNr = t2.TranSeqNr
    where t1.CwrFileId = @cwrFileId
end 
";
                    cmd.ExecuteNonQuery();
                });
            });
        }

        private void btnImportSpecs_Click(object sender, EventArgs e)
        {
            var form = new FormSpecImport();
            form.ShowDialog();

        }

        private void btnCreateTables_Click(object sender, EventArgs e)
        {
            DropAllGeneratedTables();
            CreateTables();
        }

        private void btnCreateProcedures_Click(object sender, EventArgs e)
        {
            CreateProcedures();
        }

        private void btnCreateClasses_Click(object sender, EventArgs e)
        {
            CreateClasses();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var reader = new CwrFileReader();
            reader.LoadFile(@"D:\OlegM\Sources\WidService\CwrTools\TestData\CW250029117_117.V21", "IN");
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            var reader = new CwrFileReader();
            reader.ReadFile(@"D:\OlegM\Sources\WidService\CwrTools\TestData\CW250029117_117.V21");
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            var reader = new CwrFileReader();
            var crwFile = reader.ReadFile(@"D:\OlegM\Sources\WidService\CwrTools\TestData\CW250029117_117.V21");
            var writer = new CwrFileWriter();
            writer.WriteFile(crwFile, @"D:\OlegM\Sources\WidService\CwrTools\TestData\Out\");
        }

        private void btnTestFile_Click(object sender, EventArgs e)
        {
            var source = File.ReadAllLines(@"D:\OlegM\Sources\WidService\CwrTools\TestData\CW250029117_117.V21");
            var target = File.ReadAllLines(@"D:\OlegM\Sources\WidService\CwrTools\TestData\Out\CW250029117_117.V21");

            for (var idx = 0; idx < source.Length; idx++)
            {
                if(source[idx] != target[idx])
                {
                    break;
                }
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            var form = new FormCreateFile();
            form.ShowDialog();
         }

        private void btnSendFile_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMain.SelectedIndex)
            {
                case 0:
                    ucInputFiles.RefreshData();
                    break;
                case 1:
                    ucOutputFiles.RefreshData();
                    break;
            }
        }
    }
}
