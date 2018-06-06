using System;
using System.Windows.Forms;

namespace RightholderWorkplaceSeparateForm.Services
{
    public class ViewAction
    {
        /// <summary>
        /// View для вставки в панель
        /// </summary>
        public Control View { get; set; }
        /// <summary>
        /// Функція з параметром при возвраті керування
        /// </summary>
        public Action<object> DoneActionWithParam { get; set; }
        /// <summary>
        /// Функція без параметром при возвраті керування
        /// </summary>
        public Action DoneAction { get; set; }
        /// <summary>
        /// Признак, що потрібно визивати при возвраті метод з параметром 
        /// </summary>
        public Type TypeParam { get; set; }
    }

}
