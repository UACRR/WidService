using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public class FixationQuery
    {
        public FixationStages? Stage { get; set; }
        public FixationStageStatuses? StageStatus { get; set; }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (Stage.HasValue)
                parameters.Add(new KeyValuePair<string, string>("stage", ((int)Stage.Value).ToString()));

            if (StageStatus.HasValue)
                parameters.Add(new KeyValuePair<string, string>("stageStatus", ((int)StageStatus.Value).ToString()));

            return parameters.ToArray();
        }
    }
}
