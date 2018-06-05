using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public class viewAction
    {
        /// <summary>
        /// View для вставки в панель
        /// </summary>
        public Control view { get; set; }
        /// <summary>
        /// Функція з параметром при возвраті керування
        /// </summary>
        public Action<object> doneActionWithParam { get; set; }
        /// <summary>
        /// Функція без параметром при возвраті керування
        /// </summary>
        public Action doneAction { get; set; }
        /// <summary>
        /// Признак, що потрібно визивати при возвраті метод з параметром 
        /// </summary>
        public Type TypeParam { get; set; }
    }

    public static class ViewStack
    {
        private static Stack<viewAction> _stack = new Stack<viewAction>();
        public static int Count { get { return _stack.Count; } }
        public static void Push(viewAction item )
        {
            _stack.Push(item);
        }
        public static viewAction Pop()
        {
            return _stack.Pop();
        }
    }

}
