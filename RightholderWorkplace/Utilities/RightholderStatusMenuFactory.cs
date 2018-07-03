using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace RightholderWorkplace.Utilities
{
    public static class RightholderStatusMenuFactory
    {
        public static RadDropDownMenu Create(RightholderStatusType currentStatus, EventHandler onClickHandler)
        {
            var menu = new RadDropDownMenu();

            if (currentStatus == RightholderStatusType.Active)
            {
                AddMenuItem(menu, "Оформлення спадщини", (int)RightholderStatusType.Inheritance, onClickHandler);
                AddMenuItem(menu, "Заблокований", (int)RightholderStatusType.Blocked, onClickHandler);
                AddMenuItem(menu, "Закритий", (int)RightholderStatusType.Closed, onClickHandler);
            }
            else if (currentStatus == RightholderStatusType.Closed)
            {
                AddMenuItem(menu, "Діючий", (int)RightholderStatusType.Active, onClickHandler);
            }
            else
            {
                AddMenuItem(menu, "Діючий", (int)RightholderStatusType.Active, onClickHandler);
                AddMenuItem(menu, "Закритий", (int)RightholderStatusType.Closed, onClickHandler);
            }

            return menu;
        }

        private static void AddMenuItem(RadDropDownMenu menu, string text, object tag, EventHandler onClickHandler)
        {
            var menuItem = new RadMenuItem { Text = text, Tag = tag};
            menuItem.Click += onClickHandler;
            menu.Items.Add(menuItem);
        }
    }
}
