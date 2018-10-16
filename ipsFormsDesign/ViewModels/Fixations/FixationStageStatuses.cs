using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public enum FixationStageStatuses
    {
        [Description("Нове")]
        New = 1,

        [Description("На узгодження до фіксації")]
        NegotiationBeforeFixationOnNegotioation = 2,

        [Description("Направлене користувачу")]
        NegotiationBeforeFixationDirectedToConsumer = 3,

        [Description("Відмова")]
        NegotiationBeforeFixationRejected = 4,

        [Description("На фіксацію")]
        FixationNotScheduled = 5,

        [Description("Заплановане")]
        FixationScheduled = 6,

        [Description("Фіксація")]
        FixationFixation = 7,

        [Description("Зафіксоване")]
        FixationFixationCompleted = 8,

        [Description("На ідентифікацію")]
        RightholderIdentificationOnIdentification = 9,

        [Description("На доопрацювання")]
        RightholderIdentificationOnCorrection = 10,

        [Description("На узгодження після фіксації")]
        NegotiationAfterFixationOnNegotioation = 11,

        [Description("Направлене користувачу")]
        NegotiationAfterFixationDirectedToConsumer = 12,

        [Description("Відмова")]
        NegotiationAfterFixationRejected = 13,

        [Description("В судову роботу")]
        JudicalWorkOnJudicalWork = 14,

        [Description("На доопрацювання")]
        JudicalWorkOnCorrection = 15,

        [Description("Вигране")]
        JudicalWorkWinned = 16,

        [Description("На моніторинг")]
        IncomeMonitoring = 17,

        [Description("Закрити (до фіксації)")]
        ClosedAgreedBeforeFixation = 18,

        [Description("Закрити (після фіксації)")]
        ClosedAgreedAfterFixation = 19,

        [Description("Закрити (по суду)")]
        ClosedByCourt = 20,

        [Description("Закрити (кошти надійшли)")]
        ClosedIncomeRecieved = 21,

        [Description("Закрити (порушення відсутнє)")]
        ClosedWithoutViolation = 22
    }
}
