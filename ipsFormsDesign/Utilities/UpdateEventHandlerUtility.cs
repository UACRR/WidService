using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Utilities
{
    /// <summary>
    /// Wrapper for events
    /// </summary>
    public class IpsEventWrap<T> where T : class
    {
        public event EventHandler<T> UpdateEventHandler;
        public void Raise(T value)
        {
            UpdateEventHandler?.Invoke(null, value);
        }
    }

    public static class UpdateEventHandlerUtility<T> where T : class
    {
        private static Dictionary<Type, IpsEventWrap<T>> Events { get; } = new Dictionary<Type, IpsEventWrap<T>>();

        public static void InvokeEvent(T value)
        {
            if (Events.ContainsKey(typeof(T)))
                Events[typeof(T)].Raise(value);
        }

        public static IpsEventWrap<T> GetEventWrap()
        {
            CreateEvent();
            return Events[typeof(T)];
        }

        private static void CreateEvent()
        {
            if (!Events.ContainsKey(typeof(T)))
                Events.Add(typeof(T), new IpsEventWrap<T>());
        }
    }
}
