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
            UpdateEventHandler?.Invoke(new object(), value);
        }
    }

    /// <summary>
    /// Тип, який дає змогу підписатися на подію 'необхідності оновлення даних' в UserContols & Forms
    /// </summary>
    /// <typeparam name="T">Тип, що змінюється</typeparam>
    /// <example> Використовується об'єкт зі списку об'єктів, об'єкт змінюється та список необхідно оновити:
    /// 1) Об'єкт змінився, необхідно сповістити підписаних:
    /// <code>
    /// UpdateEventHandlerUtility<Т>.InvokeEvent();
    /// </code>
    /// 2) Підписатись на сповіщення можливих змін:
    /// <code>
    /// UpdateEventHandlerUtility<T>.GetEventWrap().UpdateEventHandler += UpdateNeed_EventHandler;
    /// </code>
    /// </example>
    public static class UpdateEventHandlerUtility<T> where T : class
    {
        private static Dictionary<Type, IpsEventWrap<T>> Events { get; } = new Dictionary<Type, IpsEventWrap<T>>();

        public static void InvokeEvent()
        {
            if (Events.ContainsKey(typeof(T)))
                Events[typeof(T)].Raise(null);
        }

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
