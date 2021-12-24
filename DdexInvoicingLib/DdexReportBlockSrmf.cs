using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportBlockSrmf : DdexReportBlock
    {
        private string[] fields;

        public string blockId        { get => fields[1];  }
        public string id             { get => fields[2];  }
        public string title          { get => fields[3];  }
        public string artist         { get => fields[4];  }
        public string album          { get => fields[5];  }
        public string label          { get => fields[6];  }
        public string isrc           { get => fields[7];  }
        public string comp_id        { get => fields[8];  }
        public string comp_title     { get => fields[9];  }
        public string comp_iswc      { get => fields[10]; }
        public string comp_writers   { get => fields[11]; }
        public string comp_custom_id { get => fields[12]; }
        public string quantile       { get => fields[13]; }

        public DdexReportBlockSrmf(DdexReport report, bool doFiltering) : base(report, doFiltering) { }

        public override bool Init(StreamReader streamReader, ref string line)
        {
            fields = line.Split('\t');
            if(int.Parse(blockId) % 10000 == 0)
                Logger.WriteLine($"Обробка блоків - останнім оброблено блок {blockId}");
            return true;
        }

        public override void Process(DdexReportActionBase action, StreamReader streamReader, ref string firstLine)
        {
            action.ProcessBlock(this);
        }

        public override bool IsProcessed(int lastProcessedBlockId) => int.Parse(blockId) < lastProcessedBlockId;
    }
}
