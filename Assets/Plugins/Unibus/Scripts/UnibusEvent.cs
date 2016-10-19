using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Unibus
{
    public static class UnibusEvent
    {
        public static void Subscribe<T>(OnEvent<T> eventCallback)
        {
            UnibusEventObject.Instance.Subscribe<T>(eventCallback);
        }

        public static void Subscribe<T>(object tag, OnEvent<T> eventCallback)
        {
            UnibusEventObject.Instance.Subscribe<T>(tag, eventCallback);
        }

        public static void Unsubscribe<T>(OnEvent<T> eventCallback)
        {
            UnibusEventObject.Instance.Unsubscribe<T>(UnibusEventObject.DefaultTag, eventCallback);
        }

        public static void Unsubscribe<T>(object tag, OnEvent<T> eventCallback)
        {
            UnibusEventObject.Instance.Unsubscribe<T>(tag, eventCallback);
        }

        public static void Dispatch<T>(T action)
        {
            UnibusEventObject.Instance.Dispatch(UnibusEventObject.DefaultTag, action);
        }

        public static void Dispatch<T>(object tag, T action)
        {
            UnibusEventObject.Instance.Dispatch(tag, action);
        }
    }
}