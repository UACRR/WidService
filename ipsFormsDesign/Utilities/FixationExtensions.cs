using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Utilities
{
    public static class FixationExtensions
    {
        public static FixationStages GetStage(this Fixation fixation)
        {
            return (FixationStages)IpsGlobal.AnketaDictionaties.fixStageStatus.First(ss => ss.CodeI == fixation.StageStatus).StageCode;
        }
    }
}
