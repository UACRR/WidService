using ipsFormsDesign.ViewModels.Fixations;
using System;
using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public class FixationStageStatusMenuFactory
    {
        public static RadDropDownMenu Create(FixationStageStatuses currentStatus, EventHandler onClickHandler)
        {
            var availableStageStatuses = new Dictionary<string, FixationStageStatuses>();

            switch (currentStatus)
            {
                case FixationStageStatuses.New:
                    availableStageStatuses.Add("На узгодження до фіксації", FixationStageStatuses.NegotiationBeforeFixationOnNegotioation);
                    break;
                case FixationStageStatuses.NegotiationBeforeFixationRejected:
                    availableStageStatuses.Add("На фіксацію", FixationStageStatuses.FixationNotScheduled);
                    break;
                case FixationStageStatuses.FixationFixationCompleted:
                    availableStageStatuses.Add("На ідентифікацію", FixationStageStatuses.RightholderIdentificationOnIdentification);
                    break;
                case FixationStageStatuses.RightholderIdentificationOnIdentification:
                    availableStageStatuses.Add("На узгодження після фіксації", FixationStageStatuses.NegotiationAfterFixationOnNegotioation);
                    break;
                case FixationStageStatuses.NegotiationAfterFixationRejected:
                    availableStageStatuses.Add("В судову роботу", FixationStageStatuses.JudicalWorkOnJudicalWork);
                    break;
                case FixationStageStatuses.JudicalWorkWinned:
                    availableStageStatuses.Add("На моніторинг", FixationStageStatuses.IncomeMonitoring);
                    break;
                case FixationStageStatuses.IncomeMonitoring:
                    availableStageStatuses.Add("Закрити (кошти надійшли)", FixationStageStatuses.ClosedIncomeRecieved);
                    break;
            }

            var menu = new RadDropDownMenu();

            foreach (var keyValue in availableStageStatuses)
            {
                var menuItem = new RadMenuItem { Text = keyValue.Key, Tag = keyValue.Value };
                menuItem.Click += onClickHandler;
                menu.Items.Add(menuItem);
            }

            return menu;
        }
    }
}
