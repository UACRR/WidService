using System.Collections.Generic;
using LanguageLibrary.Model.LanguageDataNested;
using CC = LanguageLibrary.Model.ComponentCategory;

namespace LanguageLibrary.Model
{
    public static class ComponentCategoryResource
    {
        private static readonly Dictionary<string, CC> ComponentCategories = new Dictionary<string, CC>
        {
            [""] = CC.Other,

            //[""] = ComponentCategory.Buttons,
            [nameof(CopyrightRequestLD.UIbtnSave)] = CC.Buttons,
            [nameof(CopyrightRequestLD.UIbtnCancel)] = CC.Buttons,

            //[""] = ComponentCategory.StaticText,

            //[""] = ComponentCategory.Column,

            //[""] = ComponentCategory.MenuAndTab,

            //[""] = ComponentCategory.SystemMessages,

            //[""] = ComponentCategory.ToolTipText,
        };

        public static CC GetComponentCategory(string name)
        {
            if (!ComponentCategories.ContainsKey(name))
                return CC.Other;

            return ComponentCategories[name];
        }
    }

    public enum ComponentCategory
    {
        Buttons,
        StaticText,
        Column,
        MenuAndTab,
        SystemMessages, 
        ToolTipText,
        Other,
    }
}