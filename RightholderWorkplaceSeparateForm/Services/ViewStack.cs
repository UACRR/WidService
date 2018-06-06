using System.Collections.Generic;

namespace RightholderWorkplaceSeparateForm.Services
{
    public static class ViewStack
    {
        private static Stack<ViewAction> _stack = new Stack<ViewAction>();

        public static int Count
        {
            get => _stack.Count;
        }

        public static void Push(ViewAction item )
        {
            _stack.Push(item);
        }

        public static ViewAction Pop()
        {
            return _stack.Pop();
        }
    }

}
