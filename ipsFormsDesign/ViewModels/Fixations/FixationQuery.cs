using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public class FixationQuery
    {
        public FixationStages? Stage { get; set; }
        public FixationStageStatuses? StageStatus { get; set; }
    }
}
