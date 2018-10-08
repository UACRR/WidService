using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ipsFormsDesign.Utilities
{
    public static class FixationExtensions
    {
        public static FixationStages GetStage(this Fixation fixation)
        {
            return (FixationStages)IpsGlobal.AnketaDictionaties.fixStageStatus.First(ss => ss.CodeI == fixation.StageStatus).StageCode;
        }

        public static Register GetRegister(this Fixation fixation)
        {
            return fixation.Lic.PaidPeriod.First().RegisterRatedList.First().Register.First();
        }

        public static IEnumerable<FixationStageStatuses> GetAvailableStageStatuses(this FixationListViewModel fixationViewModel)
        {
            var currentStageStatus = (FixationStageStatuses)fixationViewModel.StageStatusId;

            return GetAvailableStageStatuses(currentStageStatus);
        }

        public static IEnumerable<FixationStageStatuses> GetAvailableStageStatuses(this Fixation fixation)
        {
            var currentStageStatus = (FixationStageStatuses)fixation.StageStatus;

            return GetAvailableStageStatuses(currentStageStatus);
        }

        private static IEnumerable<FixationStageStatuses> GetAvailableStageStatuses(FixationStageStatuses currentStageStatus)
        {
            var availableStageStatuses = new Collection<FixationStageStatuses>();

            switch (currentStageStatus)
            {
                case FixationStageStatuses.New:
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationBeforeFixationOnNegotioation);
                    break;

                case FixationStageStatuses.NegotiationBeforeFixationOnNegotioation:
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationBeforeFixationDirectedToConsumer);
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationBeforeFixationRejected);
                    availableStageStatuses.Add(FixationStageStatuses.ClosedAgreedBeforeFixation);
                    availableStageStatuses.Add(FixationStageStatuses.ClosedWithoutViolation);
                    break;

                case FixationStageStatuses.NegotiationBeforeFixationDirectedToConsumer:
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationBeforeFixationRejected);
                    availableStageStatuses.Add(FixationStageStatuses.ClosedAgreedBeforeFixation);
                    availableStageStatuses.Add(FixationStageStatuses.ClosedWithoutViolation);
                    break;

                case FixationStageStatuses.NegotiationBeforeFixationRejected:
                    availableStageStatuses.Add(FixationStageStatuses.FixationNotScheduled);
                    break;

                case FixationStageStatuses.FixationNotScheduled:
                    availableStageStatuses.Add(FixationStageStatuses.FixationScheduled);
                    break;

                case FixationStageStatuses.FixationScheduled:
                    availableStageStatuses.Add(FixationStageStatuses.FixationFixation);
                    break;

                case FixationStageStatuses.FixationFixation:
                    availableStageStatuses.Add(FixationStageStatuses.FixationFixationCompleted);
                    break;

                case FixationStageStatuses.FixationFixationCompleted:
                    availableStageStatuses.Add(FixationStageStatuses.RightholderIdentificationOnIdentification);
                    break;

                case FixationStageStatuses.RightholderIdentificationOnIdentification:
                    availableStageStatuses.Add(FixationStageStatuses.RightholderIdentificationOnCorrection);
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationAfterFixationOnNegotioation);
                    break;

                case FixationStageStatuses.RightholderIdentificationOnCorrection:
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationAfterFixationOnNegotioation);
                    break;

                case FixationStageStatuses.NegotiationAfterFixationOnNegotioation:
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationAfterFixationDirectedToConsumer);
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationAfterFixationRejected);
                    availableStageStatuses.Add(FixationStageStatuses.ClosedAgreedAfterFixation);
                    break;

                case FixationStageStatuses.NegotiationAfterFixationDirectedToConsumer:
                    availableStageStatuses.Add(FixationStageStatuses.NegotiationAfterFixationRejected);
                    availableStageStatuses.Add(FixationStageStatuses.ClosedAgreedAfterFixation);
                    break;

                case FixationStageStatuses.NegotiationAfterFixationRejected:
                    availableStageStatuses.Add(FixationStageStatuses.JudicalWorkOnJudicalWork);
                    break;

                case FixationStageStatuses.JudicalWorkOnJudicalWork:
                    availableStageStatuses.Add(FixationStageStatuses.JudicalWorkOnCorrection);
                    availableStageStatuses.Add(FixationStageStatuses.JudicalWorkWinned);
                    availableStageStatuses.Add(FixationStageStatuses.ClosedByCourt);
                    break;

                case FixationStageStatuses.JudicalWorkOnCorrection:
                    availableStageStatuses.Add(FixationStageStatuses.JudicalWorkOnJudicalWork);
                    break;

                case FixationStageStatuses.JudicalWorkWinned:
                    availableStageStatuses.Add(FixationStageStatuses.IncomeMonitoring);
                    break;

                case FixationStageStatuses.IncomeMonitoring:
                    availableStageStatuses.Add(FixationStageStatuses.ClosedIncomeRecieved);
                    break;

                case FixationStageStatuses.ClosedAgreedBeforeFixation:
                    break;

                case FixationStageStatuses.ClosedAgreedAfterFixation:
                    break;

                case FixationStageStatuses.ClosedByCourt:
                    break;

                case FixationStageStatuses.ClosedIncomeRecieved:
                    break;

                case FixationStageStatuses.ClosedWithoutViolation:
                    break;
            }

            return availableStageStatuses;
        }
    }
}
