using System.Collections.Generic;
using LanguageLibrary.Model.LanguageDataNested;

namespace LanguageLibrary.Model
{
    public static class ComponentCategoryResource
    {
        private static readonly Dictionary<string, ComponentCategory> ComponentCategories = new Dictionary<string, ComponentCategory>
        {
            [""] = ComponentCategory.Other,

            //[""] = ComponentCategory.Buttons,
            [nameof(CopyrightRequestLD.UIbtnSave)] = ComponentCategory.Buttons,
            [nameof(CopyrightRequestLD.UIbtnCancel)] = ComponentCategory.Buttons,

            //[""] = ComponentCategory.StaticText,

            //[""] = ComponentCategory.Column,

            //[""] = ComponentCategory.MenuAndTab,

            //[""] = ComponentCategory.SystemMessages,

            //[""] = ComponentCategory.ToolTipText,
        };

        public static ComponentCategory GetComponentCategory(string name)
        {
            if (!ComponentCategories.ContainsKey(name))
                return ComponentCategory.Other;

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