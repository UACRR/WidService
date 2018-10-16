using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.Fixations;
using System;
using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public class FixationStageStatusMenuFactory
    {
        public static RadDropDownMenu Create(IEnumerable<FixationStageStatuses> fixationStageStatuses, EventHandler onClickHandler)
        {
            var menu = new RadDropDownMenu();

            foreach (var ss in fixationStageStatuses)
            {
                var menuItem = new RadMenuItem { Text = EnumUtility.GetDescription(ss), Tag = ss };
                menuItem.Click += onClickHandler;
                menu.Items.Add(menuItem);
            }

            return menu;
        }
    }
}
