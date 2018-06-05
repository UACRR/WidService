using System.Collections.Generic;

namespace RightholderWorkplaceSeparateForm.Services
{
    public class ViewStack
    {
        private Stack<ViewAction> _stack = new Stack<ViewAction>();
        private static ViewStack _instance;

        private ViewStack()
        {
        }

        public static ViewStack GetInstance()
        {
            if (_instance == null)
                _instance = new ViewStack();

            return _instance;
        }

        public int Count
        {
            get => _stack.Count;
        }

        public void Push(ViewAction item )
        {
            _stack.Push(item);
        }

        public ViewAction Pop()
        {
            return _stack.Pop();
        }
    }
}
