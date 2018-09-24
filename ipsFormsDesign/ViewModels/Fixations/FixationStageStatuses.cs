using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public enum FixationStageStatuses
    {
        New = 1,
        NegotiationBeforeFixationOnNegotioation = 2,
        NegotiationBeforeFixationDirectedToConsumer = 3,
        NegotiationBeforeFixationRejected = 4,
        FixationNotScheduled = 5,
        FixationScheduled = 6,
        FixationFixation = 7,
        FixationFixationCompleted = 8,
        RightholderIdentificationOnIdentification = 9,
        RightholderIdentificationOnCorrection = 10,
        NegotiationAfterFixationOnNegotioation = 11,
        NegotiationAfterFixationDirectedToConsumer = 12,
        NegotiationAfterFixationRejected = 13,
        JudicalWorkOnJudicalWork = 14,
        JudicalWorkOnCorrection = 15,
        JudicalWorkWinned = 16,
        IncomeMonitoring = 17,
        ClosedAgreedBeforeFixation = 18,
        ClosedAgreedAfterFixation = 19,
        ClosedByCourt = 20,
        ClosedIncomeRecieved = 21,
        ClosedWithoutViolation = 22
    }
}
