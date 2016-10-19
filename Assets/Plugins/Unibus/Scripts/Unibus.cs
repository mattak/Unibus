using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UnibusEvent
{
    public static class Unibus
    {
        public static void Subscribe<T>(OnEvent<T> eventCallback)
        {
            UnibusObject.Instance.Subscribe<T>(eventCallback);
        }

        public static void Subscribe<T>(object tag, OnEvent<T> eventCallback)
        {
            UnibusObject.Instance.Subscribe<T>(tag, eventCallback);
        }

        public static void Unsubscribe<T>(OnEvent<T> eventCallback)
        {
            UnibusObject.Instance.Unsubscribe<T>(UnibusObject.DefaultTag, eventCallback);
        }

        public static void Unsubscribe<T>(object tag, OnEvent<T> eventCallback)
        {
            UnibusObject.Instance.Unsubscribe<T>(tag, eventCallback);
        }

        public static void Dispatch<T>(T action)
        {
            UnibusObject.Instance.Dispatch(UnibusObject.DefaultTag, action);
        }

        public static void Dispatch<T>(object tag, T action)
        {
            UnibusObject.Instance.Dispatch(tag, action);
        }
    }
}