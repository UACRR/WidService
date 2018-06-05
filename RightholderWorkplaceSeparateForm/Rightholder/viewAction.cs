using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public class viewAction
    {
        public Control view { get; set; }
        public Action<object> backAction { get; set; }
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
